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
				Username = item.Username,
				HoTen = item.HoTen,
				AnhDaiDien = item.AnhDaiDien,
				LanTruyCapCuoi = item.LanTruyCapCuoi
			}).OrderByDescending(x => x.Id).ToListAsync();
		}
	}
}
