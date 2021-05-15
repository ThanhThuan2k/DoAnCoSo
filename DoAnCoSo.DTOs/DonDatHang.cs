using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class DonDatHang
	{
		public DonDatHang()
		{
			ChiTietDonDatHangs = new List<ChiTietDonDatHang>();
		}
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
		public string HoTen { get; set; }
		public string SoDienThoai { get; set; }
		public string DiaChiTuyChon { get; set; }
		public string DiaChiDuPhong { get; set; }
		public string GhiChu { get; set; }
		public double TongTienHoaDon { get; set; }
		public DateTime NgayDat { get; set; }
		public ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
	}
}
