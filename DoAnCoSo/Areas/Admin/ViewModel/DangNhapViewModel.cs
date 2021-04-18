using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel
{
	public class DangNhapViewModel
	{
		public string username { get; set; }
		public string password { get; set; }
		public bool isSupper { get; set; }
		public bool RememberMe { get; set; }
	}
}
