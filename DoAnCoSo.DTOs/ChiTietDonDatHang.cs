using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class ChiTietDonDatHang
	{
		public int DonDatHangId { get; set; }
		public int ChiTietSanPhamId { get; set; }
		public int SoLuong { get; set; }
		public double ThanhTien { get; set; }

		[ForeignKey("DonDatHangId")]
		public DonDatHang DonDatHang { get; set; }

		[ForeignKey("ChiTietSanPhamId")]
		public ChiTietSanPham ChiTietSanPham { get; set; }
	}
}