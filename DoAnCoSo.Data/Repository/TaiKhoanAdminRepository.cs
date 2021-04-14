using DoAnCoSo.Data.JsonModel;
using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class TaiKhoanAdminRepository : RepositoryBase
	{
		public async Task<List<TaiKhoanAdminJsonModal>> DanhSach()
		{
			return await db.TaiKhoanAdmins.Select(item => new TaiKhoanAdminJsonModal()
			{
				Id = item.Id,
				TenHienThi = item.TenHienThi,
				HoTen = item.HoTen,
				AnhDaiDien = item.AnhDaiDien,
				LanTruyCapCuoi = item.LanTruyCapCuoi
			}).OrderByDescending(x => x.Id).ToListAsync();
		}

		public async Task ThemTaiKhoan(TaiKhoanAdmin admin)
		{
			await db.TaiKhoanAdmins.AddAsync(admin);
			await Save();
		}

		public async Task<bool> Authorize(string username, string password)
		{
			TaiKhoanAdmin taiKhoan = db.TaiKhoanAdmins
				.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
			if(taiKhoan != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> XoaTaiKhoan(int id)
		{
			TaiKhoanAdmin taiKhoan = db.TaiKhoanAdmins.Find(id);
			if (taiKhoan != null)
			{
				try
				{
					db.TaiKhoanAdmins.Remove(taiKhoan);
					await Save();
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public async Task<ThongTinTaiKhoanAdminJsonModal> ChiTietTaiKhoan(int id)
		{
			ThongTinTaiKhoanAdminJsonModal chiTietTaiKhoan = await db.TaiKhoanAdmins
				.Select(item => new ThongTinTaiKhoanAdminJsonModal()
				{
					Id = item.Id,
					TenHienThi = item.TenHienThi,
					AnhDaiDien = item.AnhDaiDien
				}).SingleOrDefaultAsync(x => x.Id == id);
			if(chiTietTaiKhoan != null)
			{
				return chiTietTaiKhoan;
			}
			else
			{
				return new ThongTinTaiKhoanAdminJsonModal();
			}
		}
	}
}
