using DoAnCoSo.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel
{
	public class DangKiTaiKhoanAdminViewModel : TaiKhoanAdmin
	{
		public string Ho { get; set; }
		public string Ten { get; set; }
		public IFormFile Avatar { get; set; }
		public string NhapLaiMatKhau { get; set; }
	}
}
