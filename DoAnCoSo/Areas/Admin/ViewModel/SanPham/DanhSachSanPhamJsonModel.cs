using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel.SanPham
{
	public class DanhSachSanPhamJsonModel
	{
		public int Id { get; set; }
		public string MaSanPham { get; set; }
		public string TenSanPham { get; set; }
		public string AnhDaiDien { get; set; }
		public int? SoLuongTonKho { get; set; }
		public float? GiaGocSanPham { get; set; }
		public string TinhTrangMay { get; set; }
	}
}
