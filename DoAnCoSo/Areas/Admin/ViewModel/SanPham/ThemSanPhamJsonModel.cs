using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel.SanPham
{
	public class ThemSanPhamJsonModel
	{
		[DisplayName("Tên sản phẩm")]
		public string TenSanPham { get; set; }

		[DisplayName("Chọn ảnh đại diện")]
		public string AnhDaiDien { get; set; }
		
		[DisplayName("Thông tin chi tiết sản phẩm")]
		public string ThongTinChiTiet { get; set; }

		[DisplayName("Giá gốc sản phẩm")]
		public float? GiaGocSanPham { get; set; }

		[DisplayName("Tình trạng máy")]
		public string TinhTrangMay { get; set; }

		[DisplayName("Quy cách đóng hộp sản phẩm")]
		public string QuyCachDongHop { get; set; }

		[DisplayName("Thời hạn bảo hành")]
		public string ThoiHanBaoHanh { get; set; }
	}
}
