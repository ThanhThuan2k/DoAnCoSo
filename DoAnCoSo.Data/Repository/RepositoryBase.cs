using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class RepositoryBase
	{
		protected DoAnCoSoDbContext db;
		public RepositoryBase()
		{
			db = new DoAnCoSoDbContext();
		}
		public RepositoryBase(DoAnCoSoDbContext database)
		{
			db = database;
		}
		public async Task Save()
		{
			await db.SaveChangesAsync();
		}
	}
}
