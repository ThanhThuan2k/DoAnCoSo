using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class SanPham_ThongSoKyThuat
	{
		public int SanPhamId { get; set; }
		public ChiTietSanPham SanPham { get; set; }

		public int ThongSoKyThuatId { get; set; }
		public ThongSoKyThuat ThongSoKyThuat { get; set; }
	}
}
