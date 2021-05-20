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
			DanhMuc = new DanhMuc();
			HangSanXuat = new HangSanXuat();
			DanhSachAnhChiTiet = new List<HinhAnh>();
			DanhSachThongSo = new List<ThongSoKyThuat>();
		}

		[Key]
		public int Id { get; set; }
		public string MaSanPham { get; set; }
		public string TenSanPham { get; set; }
		public string AnhDaiDien { get; set; }
		public string ThongTinChiTiet { get; set; }
		public int? SoLuongTonKho { get; set; }
		public HangSanXuat HangSanXuat { get; set; }
		public DanhMuc DanhMuc { get; set; }
		public ICollection<HinhAnh> DanhSachAnhChiTiet { get; set; }
		public double? GiaGocSanPham { get; set; }
		public ICollection<ThongSoKyThuat> DanhSachThongSo { get; set; }
		public string TinhTrangMay { get; set; }
		public string QuyCachDongHop { get; set; }
		public string ThoiHanBaoHanh { get; set; }
		public int? LuotXem { get; set; }
		public int? LuotThich { get; set; }
		public DateTime? NgayXoa { get; set; }
		public string NguoiXoa { get; set; }
		public double? GiamGia { get; set; }
		public LoaiPhuKien LoaiPhuKien { get; set; }
	}
}
