using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class LienHeRepository : RepositoryBase
	{
		public LienHeRepository() : base() { }
		public LienHeRepository(DoAnCoSoDbContext _db) : base(_db) { }

		public async Task<bool> ThemLienHe(LienHe lienHe)
		{
			try
			{
				await db.LienHes.AddAsync(lienHe);
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
