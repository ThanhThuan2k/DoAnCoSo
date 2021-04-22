using DoAnCoSo.Data.JsonModel;
using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class LoginRepository : RepositoryBase
	{
		public async Task<LoginJsonModel> SuccessLoginAsync(string username, string password, bool isSupper)
		{
			if(username != null && password != null)
			{
				try
				{
					TaiKhoanAdmin user = await db.TaiKhoanAdmins
						.SingleOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && 
											  x.Password == password && x.isSuperAdmin == isSupper);
					if(user != null)
					{
						return new LoginJsonModel(user.Id, user.HoTen, true, user.isSuperAdmin);
					}
					else
					{
						return new LoginJsonModel();
					}
				}
				catch
				{
					return new LoginJsonModel();
				}
			}
			return new LoginJsonModel();
		}

		public LoginJsonModel SuccessLogin(string username, string password, bool isSupper)
		{
			if (username != null && password != null)
			{
				try
				{
					TaiKhoanAdmin user = db.TaiKhoanAdmins
						.SingleOrDefault(x => x.Username.ToLower() == username.ToLower() &&
											  x.Password == password && x.isSuperAdmin == isSupper);
					if (user != null)
					{
						return new LoginJsonModel(user.Id, user.HoTen, true, user.isSuperAdmin);
					}
					else
					{
						return new LoginJsonModel();
					}
				}
				catch
				{
					return new LoginJsonModel();
				}
			}
			return new LoginJsonModel();
		}

		public async Task<string> getPathImage(string username)
		{
			if (username != null)
			{
				TaiKhoanAdmin taiKhoan = await db.TaiKhoanAdmins.Where(x => x.Username == username).FirstOrDefaultAsync();
				return taiKhoan.AnhDaiDien;
			}
			else return "~/Admin/vendors/images/photo1.jpg";
		}

		public async Task<string> getHoTen(string username)
		{
			if(username != null)
			{
				TaiKhoanAdmin taiKhoanAdmin = await db.TaiKhoanAdmins.Where(x => x.Username == username).FirstOrDefaultAsync();
				return taiKhoanAdmin.HoTen;
			}
			return "Guest";
		}
	}
}
