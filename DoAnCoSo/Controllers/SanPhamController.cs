using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class SanPhamController : Controller
	{
		SanPhamRepository sanPhamRepo;
		public SanPhamController()
		{
			sanPhamRepo = new SanPhamRepository();
		}
		public IActionResult DanhSach(int id = 0)
		{
			return View();
		}

		public async Task<JsonResult> TatCaSanPham()
		{
			var model = await sanPhamRepo.TatCaSanPham();
			return Json(model);
		}

		[Route("/chitietsanpham/{id?}")]
		[Route("/SanPham/ChiTietSanPham/{id?}")]
		public IActionResult ChiTietSanPham()
		{
			return View();
		}

		public async Task<JsonResult> ChiTiet(int? id)
		{
			var model = await sanPhamRepo.ChiTietSanPham(id ?? 0);
			return Json(model);
		}
	}
}