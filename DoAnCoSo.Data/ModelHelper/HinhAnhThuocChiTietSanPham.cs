using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.ModelHelper
{
	public class HinhAnhThuocChiTietSanPham
	{
		public string Avatar { get; set; }
		public List<HinhAnh> DanhSachAnhChiTiet { get; set; }
	}
}
