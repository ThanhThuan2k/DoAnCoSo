using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class DanhMuc
	{
		public DanhMuc()
		{
			ChiTietSanPhamNavigation = new HashSet<ChiTietSanPham>();
		}
		[Key]
		public int Id { get; set; }
		public string TenDanhMuc { get; set; }
		public int? ThuTu { get; set; }
		public string Icon { get; set; }
		public ICollection<ChiTietSanPham> ChiTietSanPhamNavigation { get; set; }
	}
}