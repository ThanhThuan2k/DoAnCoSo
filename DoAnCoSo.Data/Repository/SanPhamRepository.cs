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
			ChiTietSanPham sanPham = db.ChiTietSanPhams.Find(id);
			if(sanPham != null)
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
	}
}
