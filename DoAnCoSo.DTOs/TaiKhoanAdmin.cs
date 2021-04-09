using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class TaiKhoanAdmin
	{
		[Key]
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string HoTen { get; set; }
		public DateTime? LanTruyCapCuoi { get; set; }
		public bool BiKhoa { get; set; }
		public bool isSuperAdmin { get; set; }
		public string AnhDaiDien { get; set; }
		public string DiaChi { get; set; }
		public string TenHienThi { get; set; }
		public string Email { get; set; }
		public string SoDienThoai { get; set; }
	}
}
