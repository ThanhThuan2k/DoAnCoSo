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
		public ChiTietSanPham SanPham { get; set; }
		public MauSac MauSac { get; set; }
	}
}
