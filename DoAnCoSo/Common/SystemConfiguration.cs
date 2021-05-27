using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Common
{
	public class SystemConfiguration
	{
		public Config DiaChi { get; set; }
		public Config SoDienThoai { get; set; }
		public Config Email { get; set; }
		public Config Footer { get; set; }
		public SystemConfiguration()
		{
			var type = typeof(SystemConfiguration); // lấy kiểu dữ liệu của chính nó
			SystemConfiguration configs = this;

			var props = type.GetProperties();// lấy tất cả thuộc tính của class
			var repo = new ConfigRepository();
			foreach(var item in props)
			{
				var conf = new Config()
				{
					Name = item.Name,
					Value = ""
				};
				repo.AddIfNotExist(conf);
				item.SetValue(configs, repo.GetConfig(item.Name));
			}
		}
	}
}
