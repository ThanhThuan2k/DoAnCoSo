using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.ModelHelper
{
	public class ChiTietTaiKhoanKhachHangClientModel
	{
		public int Id { get; set; }
		public string HoTenKhachHang { get; set; }
		public string Email { get; set; }
		public string SoDienThoai { get; set; }
		public DateTime NgayTaoTaiKhoan { get; set; }
		public List<DonDatHang> DanhSachDonDatHang { get; set; }
	}
}
