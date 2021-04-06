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
		public int IdSanPham { get; set; }
		[ForeignKey("IdSanPham")]
		public ChiTietSanPham SanPham { get; set; }
		public int IdThongSoKyThuat { get; set; }
		[ForeignKey("IdThongSoKyThuat")]
		public ThongSoKyThuat ThongSoKyThuat { get; set; }
	}
}
