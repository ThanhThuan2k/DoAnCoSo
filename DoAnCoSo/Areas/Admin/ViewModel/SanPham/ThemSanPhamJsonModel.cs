using DoAnCoSo.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.ViewModel.SanPham
{
	public class ThemSanPhamJsonModel
	{
		public string TenSanPham { get; set; }

		public string ThongTinChiTiet { get; set; }

		public double GiaGocSanPham { get; set; }
		public string TinhTrangMay { get; set; }
		public string QuyCachDongHop { get; set; }
		public string ThoiHanBaoHanh { get; set; }
		public int? IdHangSanXuat { get; set; }
		public int? IdDanhMuc { get; set; }
		public List<int> ThongSoKyThuat { get; set; }
		public IFormFile anhDaiDien { get; set; }
		public List<IFormFile> danhSachAnhChiTiet { get; set; }
		public int LoaiPhuKienId { get; set; }
	}
}