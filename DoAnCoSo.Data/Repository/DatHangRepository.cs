using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class DatHangRepository : RepositoryBase
	{
		public DatHangRepository() : base() { }
		public DatHangRepository(DoAnCoSoDbContext _db) : base(_db) { }

		public async Task<bool> DatHang(DonDatHang donDatHang)
		{
			try
			{
				await db.DonDatHangs.AddAsync(donDatHang);
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Logging.Logging.Write(ex.Message);
				return false;
			}
		}
	}
}
