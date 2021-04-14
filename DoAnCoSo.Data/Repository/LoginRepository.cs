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
		public async Task<LoginJsonModel> SuccessLogin(string username, string password, bool isSupper)
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
						return new LoginJsonModel(true, user.isSuperAdmin);
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
	}
}
