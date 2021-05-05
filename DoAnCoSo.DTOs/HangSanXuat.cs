using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class HangSanXuat
	{
		[Key]
		public int Id { get; set; }
		public string TenHang { get; set; }
		public string AnhDaiDien { get; set; }
		public ICollection<ChiTietSanPham> ChiTietSanPhamNavigation { get; set; }
	}
}