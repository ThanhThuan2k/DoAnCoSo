using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class ConfigRepository : RepositoryBase
	{
		public ConfigRepository() : base() { }
		
		public List<ConfigRepository> GetConfig()
		{
			return new List<ConfigRepository>();
		}

		public void AddIfNotExist(Config data)
		{
			if(db.Configs.All(x => x.Name != data.Name))
			{
				db.Configs.Add(data);
			}
			db.SaveChanges();
		}

		public Config GetConfig(string name)
		{
			return db.Configs.SingleOrDefault(d => d.Name == name);
		}

		public void Update(Config conf)
		{
			var temp = db.Configs.Where(x => x.Name == conf.Name).SingleOrDefault();
			temp.Value = conf.Value;
		}
	}
}
