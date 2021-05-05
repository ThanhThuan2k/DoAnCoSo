using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class ThongSoKyThuat
	{
		public ThongSoKyThuat()
		{
			SanPhamNavigation = new List<ChiTietSanPham>();
		}
		[Key]
		public int Id { get; set; }
		public string TenThongSo { get; set; }
		public string MoTa { get; set;  }
		public ICollection<ChiTietSanPham> SanPhamNavigation { get; set; }
	}
}
