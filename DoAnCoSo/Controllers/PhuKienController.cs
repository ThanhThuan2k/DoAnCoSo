using DoAnCoSo.Data.ModelHelper;
using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class PhuKienController : Controller
	{
		private readonly SanPhamRepository sanPhamRepo;
		public PhuKienController()
		{
			sanPhamRepo = new SanPhamRepository();
		}

		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		[Route("/danhsachphukien")]
		public async Task<IActionResult> DanhSachPhuKien()
		{
			var model = await sanPhamRepo.GetPhuKien();
			return View(model);
		}

		public async Task<JsonResult> PhuKienTheoLoai(int id)
		{
			var model = await sanPhamRepo.PhuKienTheoLoai(id);
			return Json(model);
		}
	}
}
