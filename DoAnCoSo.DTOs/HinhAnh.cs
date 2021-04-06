using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class HinhAnh
	{
		[Key]
		public int Id { get; set; }
		public string DuongDanAnh { get; set; }
		public string NoiDungMoTaAnh { get; set; }
		public string TenThayThe { get; set; }
		public int IdSanPham { get; set; }
		public ChiTietSanPham ThuocSanPham { get; set; }
	}
}
