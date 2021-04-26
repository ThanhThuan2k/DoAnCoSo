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

		public float GiaGocSanPham { get; set; }

		public string TinhTrangMay { get; set; }

		public string QuyCachDongHop { get; set; }
		public List<int> MauSac { get; set; }

		public string ThoiHanBaoHanh { get; set; }

		public int? HangSanXuat { get; set; }
		public int? DanhMuc { get; set; }
		public List<int> ThongSoKyThuat { get; set; }
		public IFormFile anhDaiDien { get; set; }
		public List<IFormFile> danhSachAnhChiTiet { get; set; }
	}
}