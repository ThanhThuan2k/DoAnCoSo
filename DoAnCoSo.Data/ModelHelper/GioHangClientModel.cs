using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.ModelHelper
{
	public class GioHangClientModel
	{
		public int Id { get; set; }
		public string AnhDaiDien { get; set; }
		public string TenSanPham { get; set; }
		public int SoLuong { get; set; }
		public double? GiaGocSanPham { get; set; }
		public double? GiaHienTai { get; set; }
	}
}
