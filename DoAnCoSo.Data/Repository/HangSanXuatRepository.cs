using DoAnCoSo.Data.ModelHelper;
using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class HangSanXuatRepository : RepositoryBase
	{
		public HangSanXuatRepository() : base() { }
		public List<HangSanXuat> DanhSach()
		{
			return db.HangSanXuats.OrderByDescending(x => x.Id).ToList();
		}

		public async Task Create(string name, string duongDanAnhDaiDien)
		{
			HangSanXuat newHangSanXuat = new HangSanXuat()
			{
				TenHang = name,
				AnhDaiDien = duongDanAnhDaiDien
			};
			await db.HangSanXuats.AddAsync(newHangSanXuat);
			await Save();
		}

		public async Task<HangSanXuat> ThongTinHangSanXuat(int id)
		{
			HangSanXuat chiTiet = await db.HangSanXuats.FindAsync(id);
			if(chiTiet != null)
			{
				return chiTiet;
			}
			else
			{
				return new HangSanXuat();
			}
		}

		public async Task ChinhSuaTen(int id, string tenHang)
		{
			HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
			if(hangSanXuat != null)
			{
				hangSanXuat.TenHang = tenHang;
			}
			await Save();
		}

		public async Task ChinhSuaAnhDaiDien(int id, string duongDanAnh)
		{
			HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
			if(hangSanXuat != null)
			{
				hangSanXuat.AnhDaiDien = duongDanAnh;
			}
			await Save();
		}

		public async Task<bool> XoaHangSanXuat(int id)
		{
			HangSanXuat hangSX = db.HangSanXuats.Find(id);
			if(hangSX != null)
			{
				db.HangSanXuats.Remove(hangSX);
				await Save();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<List<DanhSachHangSanXuatCollectionClientModel>> GetDanhSachDanhMucCollection()
		{
			var model = await db.HangSanXuats.AsNoTracking()
				.OrderByDescending(x => x.ChiTietSanPhamNavigation.Count)
				.Select(x => new DanhSachHangSanXuatCollectionClientModel()
				{
					Id = x.Id,
					AnhDaiDien = x.AnhDaiDien,
					TenHangSanXuat = x.TenHang
				})
				.ToListAsync();
			return model;
		}

		public async Task<List<SanPhamReviewClientModel>> SanPhamThuocHang(int id)
		{
			var model = await db.HangSanXuats
				.Where(x => x.Id == id)
				.SelectMany(x => x.ChiTietSanPhamNavigation)
				.Where(x => x.NgayXoa == null)
				.Select(x => new SanPhamReviewClientModel()
				{
					Id = x.Id,
					AnhDaiDien = x.AnhDaiDien,
					TenSanPham = x.TenSanPham,
					GiaKhuyenMai = x.GiamGia??0,
					GiaGoc = x.GiaGocSanPham ?? 0,
					RAM = x.DanhSachThongSo.Where(x => x.TenThongSo == "RAM")
					.Select(x => x.MoTa).FirstOrDefault(),
					DungLuong = x.DanhSachThongSo.Where(x => x.TenThongSo == "Dung lượng")
					.Select(x => x.MoTa).FirstOrDefault()
				})
				.OrderBy(x => x.Id)
				.ToListAsync();
			foreach(var item in model)
			{
				item.GiaHienTai = item.GiaGoc - item.GiaKhuyenMai;
			}

			return model;
		}
	}
}
