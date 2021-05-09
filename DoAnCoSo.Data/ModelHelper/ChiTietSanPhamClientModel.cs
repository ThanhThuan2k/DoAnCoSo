using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.ModelHelper
{
	public class ChiTietSanPhamClientModel
	{
		public int Id { get; set; }
		public string TenSanPham { get; set; }
		public HangSanXuat ThuocThuongHieu { get; set; }
		public string MaSanPham { get; set; }
		public double GiaGoc { get; set; }
		public double GiaKhuyenMai { get; set; }
		public double GiaHienTai { get; set; }
		public string QuyCachDongHop { get; set; }
		public string ThoiHanBaoHanh { get; set; }
		public string AnhDaiDien { get; set; }
		public List<HinhAnh> DanhSachAnhChiTiet { get; set; }
		public string ThongTinChiTiet { get; set; }
		public List<ThongSoKyThuat> DanhSachThongSoKyThuat { get; set; }
		public DanhMuc ThuocDanhMuc { get; set; }
	}
}
