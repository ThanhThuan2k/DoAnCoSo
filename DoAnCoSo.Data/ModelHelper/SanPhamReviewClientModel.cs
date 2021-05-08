using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.ModelHelper
{
	public class SanPhamReviewClientModel
	{
		public int Id { get; set; }
		public string AnhDaiDien { get; set; }
		public string TenSanPham { get; set; }
		public double? GiaKhuyenMai { get; set; }
		public double GiaGoc { get; set; }
		public double? GiaHienTai { get; set; }
		public string RAM { get; set; }
		public string DungLuong { get; set; }
	}
}
