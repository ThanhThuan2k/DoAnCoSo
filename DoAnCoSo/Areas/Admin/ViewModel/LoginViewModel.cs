using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel
{
	public class LoginViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public bool? RememberMe { get; set; }
	}
}
