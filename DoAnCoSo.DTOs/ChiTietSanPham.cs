using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class ChiTietSanPham
	{
		public ChiTietSanPham()
		{
			ThuocDanhMuc = new DanhMuc();
			ThuocHangSanXuat = new HangSanXuat();
			DanhSachAnhChiTiet = new List<HinhAnh>();
			DanhSachMauSac = new List<SanPham_MauSac>();
			DanhSachThongSo = new List<SanPham_ThongSoKyThuat>();
		}

		[Key]
		public int Id { get; set; }
		public string MaSanPham { get; set; }
		public string TenSanPham { get; set; }
		public string AnhDaiDien { get; set; }
		public string ThongTinChiTiet { get; set; }
		public int? SoLuongTonKho { get; set; }
		public int? IdHangSanXuat { get; set; }
		[ForeignKey("IdHangSanXuat")]
		public HangSanXuat ThuocHangSanXuat { get; set; }
		public int? IdDanhMuc { get; set; }
		[ForeignKey("IdDanhMuc")]
		public DanhMuc ThuocDanhMuc { get; set; }
		public ICollection<HinhAnh> DanhSachAnhChiTiet { get; set; }
		public float? GiaGocSanPham { get; set; }
		public ICollection<SanPham_MauSac> DanhSachMauSac { get; set; }
		public ICollection<SanPham_ThongSoKyThuat> DanhSachThongSo { get; set; }
		public string TinhTrangMay { get; set; }
		public string QuyCachDongHop { get; set; }
		public string ThoiHanBaoHanh { get; set; }
	}
}
