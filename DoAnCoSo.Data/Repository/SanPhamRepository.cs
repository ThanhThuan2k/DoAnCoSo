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
	public class SanPhamRepository : RepositoryBase
	{
		public SanPhamRepository() : base() { }
		public SanPhamRepository(DoAnCoSoDbContext _db) : base(_db) { }

		public async Task<List<ChiTietSanPham>> AllSanPham()
		{
			return await db.ChiTietSanPhams.Where(x => x.NgayXoa == null).ToListAsync();
		}
		public MauSac getMau(int id)
		{
			MauSac result = db.MauSacs.Find(id);
			if (result != null)
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		public async Task<ChiTietSanPham> GetSanPham(int id)
		{
			ChiTietSanPham sanPham = await db.ChiTietSanPhams.FindAsync(id);
			if (sanPham != null)
			{
				return sanPham;
			}
			return null;
		}

		public ThongSoKyThuat TimThongSo(int id)
		{
			return db.ThongSoKyThuats.Find(id);
		}

		public DanhMuc TimDanhMuc(int id)
		{
			return db.DanhMucs.Find(id);
		}

		public HangSanXuat TimHangSanXuat(int id)
		{
			return db.HangSanXuats.Find(id);
		}

		public ChiTietSanPham getSanPham(int id)
		{
			var x = db.ChiTietSanPhams.Include(x => x.DanhMuc)
				.Include(x => x.HangSanXuat)
				.SingleOrDefault(x => x.Id == id);
			return x;
		}

		public async Task<bool> Add(ChiTietSanPham model)
		{
			try
			{
				await db.ChiTietSanPhams.AddAsync(model);
				await db.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> Submit(string username, string password)
		{
			return await db.TaiKhoanAdmins.AnyAsync(x => x.Username == username && x.Password == password);
		}

		public async Task XoaSanPham(int id, string nguoiXoa)
		{
			ChiTietSanPham chiTietSanPham = await db.ChiTietSanPhams.FindAsync(id);
			chiTietSanPham.NgayXoa = DateTime.Now;
			chiTietSanPham.NguoiXoa = nguoiXoa;
			await db.SaveChangesAsync();
		}

		public async Task<string> GetHoTen(string username)
		{
			TaiKhoanAdmin taiKhoan = await db.TaiKhoanAdmins.Where(x => x.Username == username).FirstOrDefaultAsync();
			if (taiKhoan != null)
			{
				return taiKhoan.TenHienThi;
			}
			return null;
		}

		public async Task<List<DanhMuc>> GetDanhMuc()
		{
			var result = await db.DanhMucs.ToListAsync();
			return result;
		}

		public async Task<List<DanhMucCountClientModel>> GetHangSanXuatCount()
		{
			var danhMucList = await db.HangSanXuats
				.Include(x => x.ChiTietSanPhamNavigation)
				.AsNoTracking()
				.Select(x => new DanhMucCountClientModel()
				{
					TenHang = x.TenHang,
					AnhDaiDien = x.AnhDaiDien,
					Id = x.Id,
					SanPhamCount = x.ChiTietSanPhamNavigation.Count
				})
				.ToListAsync();
			return danhMucList;
		}

		public async Task<List<SanPhamReviewClientModel>> GetSanPhamBanChayNhat()
		{
			var result = await db.ChiTietSanPhams
				.Where(x => x.NgayXoa == null)
				.Select(x => new SanPhamReviewClientModel()
				{
					Id = x.Id,
					AnhDaiDien = x.AnhDaiDien,
					TenSanPham = x.TenSanPham,
					GiaGoc = x.GiaGocSanPham ?? 0,
					GiaKhuyenMai = x.GiamGia ?? 0,
					RAM = x.DanhSachThongSo.Where(x => x.TenThongSo == "RAM")
					.Select(x => x.MoTa).FirstOrDefault(),
					DungLuong = x.DanhSachThongSo.Where(x => x.TenThongSo == "Dung lượng")
					.Select(x => x.MoTa).FirstOrDefault()
				})
				.OrderByDescending(x => x.Id)
				.ToListAsync();
			foreach (var item in result)
			{
				item.GiaHienTai = item.GiaGoc - item.GiaKhuyenMai;
			}
			return result;
		}

		public async Task<List<SanPhamReviewClientModel>> GetSanPhamYeuThichNhat()
		{
			var model = await db.ChiTietSanPhams
				.Where(x => x.NgayXoa == null)
				.OrderByDescending(x => x.LuotThich)
				.AsNoTracking()
				.Select(x => new SanPhamReviewClientModel()
				{
					Id = x.Id,
					TenSanPham = x.TenSanPham,
					AnhDaiDien = x.AnhDaiDien,
					GiaGoc = x.GiaGocSanPham ?? 0,
					GiaKhuyenMai = x.GiamGia ?? 0,
					RAM = x.DanhSachThongSo.Where(x => x.TenThongSo == "RAM")
					.Select(x => x.MoTa).FirstOrDefault(),
					DungLuong = x.DanhSachThongSo.Where(x => x.TenThongSo == "Dung lượng")
					.Select(x => x.MoTa).FirstOrDefault()
				})
				.Take(5)
				.ToListAsync();

			foreach (var item in model)
			{
				item.GiaHienTai = item.GiaGoc - item.GiaKhuyenMai;
			}
			return model;
		}

		public async Task<List<SanPhamReviewClientModel>> GetSanPhamCoNhieuLuotXemNhat()
		{
			var model = await db.ChiTietSanPhams.AsNoTracking()
				.Where(x => x.NgayXoa == null)
				.OrderByDescending(x => x.LuotXem)
				.Select(x => new SanPhamReviewClientModel()
				{
					Id = x.Id,
					AnhDaiDien = x.AnhDaiDien,
					TenSanPham = x.TenSanPham,
					GiaGoc = x.GiaGocSanPham ?? 0,
					GiaKhuyenMai = x.GiamGia ?? 0,
					RAM = x.DanhSachThongSo.Where(x => x.TenThongSo == "RAM")
					.Select(x => x.MoTa).FirstOrDefault(),
					DungLuong = x.DanhSachThongSo.Where(x => x.TenThongSo == "Dung lượng")
					.Select(x => x.MoTa).FirstOrDefault()
				})
				.Take(10)
				.ToListAsync();

			foreach (var item in model)
			{
				item.GiaHienTai = item.GiaGoc - item.GiaKhuyenMai;
			}

			return model;
		}

		public async Task<List<SanPhamReviewClientModel>> TatCaSanPham()
		{
			var model = await db.ChiTietSanPhams.AsNoTracking()
				.Where(x => x.NgayXoa == null)
				.OrderByDescending(x => x.Id)
				.Select(x => new SanPhamReviewClientModel()
				{
					Id = x.Id,
					AnhDaiDien = x.AnhDaiDien,
					TenSanPham = x.TenSanPham,
					GiaGoc = x.GiaGocSanPham ?? 0,
					GiaKhuyenMai = x.GiamGia ?? 0,
					RAM = x.DanhSachThongSo.Where(x => x.TenThongSo == "RAM")
					.Select(x => x.MoTa).FirstOrDefault(),
					DungLuong = x.DanhSachThongSo.Where(x => x.TenThongSo == "Dung lượng")
					.Select(x => x.MoTa).FirstOrDefault()
				})
				.Take(10)
				.ToListAsync();

			foreach (var item in model)
			{
				item.GiaHienTai = item.GiaGoc - item.GiaKhuyenMai;
			}

			return model;
		}

		public async Task<ChiTietSanPhamClientModel> ChiTietSanPham(int id)
		{
			var model = await db.ChiTietSanPhams
				.AsNoTracking()
				.Where(x => x.Id == id)
				.Select(x => new ChiTietSanPhamClientModel()
				{
					Id = x.Id,
					TenSanPham = x.TenSanPham,
					ThuocThuongHieu = x.HangSanXuat,
					MaSanPham = x.MaSanPham,
					GiaGoc = x.GiaGocSanPham ?? 0,
					GiaKhuyenMai = x.GiamGia ?? 0,
					QuyCachDongHop = x.QuyCachDongHop,
					ThoiHanBaoHanh = x.ThoiHanBaoHanh,
					AnhDaiDien = x.AnhDaiDien,
					DanhSachAnhChiTiet = x.DanhSachAnhChiTiet.ToList(),
					ThongTinChiTiet = x.ThongTinChiTiet,
					DanhSachThongSoKyThuat = x.DanhSachThongSo.ToList(),
					ThuocDanhMuc = x.DanhMuc
				})
				.SingleOrDefaultAsync();
			return model;
		}
	}
}