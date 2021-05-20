using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class LoaiPhuKien
	{
		public int Id { get; set; }
		public string Alias { get; set; }
		public string TenLoaiPhuKien { get; set; }
		public ICollection<ChiTietSanPham> ChiTietSanPhamNavigation { get; set; }
	}
}
