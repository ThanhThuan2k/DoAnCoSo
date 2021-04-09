using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel
{
	public class ChinhSuaTaiKhoanViewModel
	{
		public string HoTen { get; set; }
		public string AnhDaiDien { get; set; }
		public string DiaChi { get; set; }
		public string TenHienThi { get; set; }
		public string Email { get; set; }
		public string SoDienThoai { get; set; }
		public IFormFile Avartar { get; set; }
	}
}
