using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HangSanXuatController : Controller
	{
		private readonly IWebHostEnvironment _host;
		private readonly HangSanXuatRepository hangSanXuatRepo = new HangSanXuatRepository();

		public IActionResult DanhSachHangSanXuat(int page = 1, int size = 10)
		{
			var danhSachHangSanXuat = hangSanXuatRepo.DanhSachPhanTrang(page, size);
			return View(danhSachHangSanXuat);
		}

		public IActionResult DanhSachHangSanXuat_API(int page = 1, int size = 10)
		{
			var danhSachHangSanXuat = hangSanXuatRepo.DanhSachPhanTrang(page, size);
			return Ok(danhSachHangSanXuat);
		}

		public async Task<IActionResult> Xoa(int? id)
		{
			if(id == null)
			{
				return Ok(false);
			}
			else
			{
				bool deleteResult = await hangSanXuatRepo.XoaHangSanXuat(id??0);
				if(deleteResult == false)
				{
					return Ok(false);
				}
			}
			return Ok(true);
		}
	}
}
