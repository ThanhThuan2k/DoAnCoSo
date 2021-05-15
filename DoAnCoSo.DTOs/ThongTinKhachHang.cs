using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class ThongTinKhachHang
	{
		[Key]
		public int Id { get; set; }
		public string TenKhachHang { get; set; }
		public string SoDienThoai { get; set; }
		public string Email { get; set; }
		public string MatKhau { get; set; }
		public DateTime NgayTaoTaiKhoan { get; set; }
		public bool BiKhoa { get; set; }
	}
}
