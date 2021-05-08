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
		public IActionResult DanhSach()
		{
			return View();
		}

		public async Task<JsonResult> TatCaSanPham()
		{
			var model = await sanPhamRepo.TatCaSanPham();
			return Json(model);
		}
	}
}