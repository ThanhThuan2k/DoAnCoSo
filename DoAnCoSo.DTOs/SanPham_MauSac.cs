using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.DTOs
{
	public class SanPham_MauSac
	{
		public int IdSanPham { get; set; }
		[ForeignKey("IdSanPham")]
		public ChiTietSanPham SanPham { get; set; }

		public int IdMauSac { get; set; }
		[ForeignKey("IdMauSac")]
		public MauSac MauSac { get; set; }
	}
}
