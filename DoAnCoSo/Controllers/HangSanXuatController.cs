using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class HangSanXuatController : Controller
	{
		HangSanXuatRepository hangSanXuatRepo = new HangSanXuatRepository();
		public HangSanXuatController()
		{
			hangSanXuatRepo = new HangSanXuatRepository();
		}

		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult Index(int id = 0)
		{
			return View();
		}

		public async Task<JsonResult> DanhSachSanPhamThuocHang(int? id)
		{
			var model = await hangSanXuatRepo.SanPhamThuocHang(id ?? 0);
			return Json(model);
		}
	}
}
