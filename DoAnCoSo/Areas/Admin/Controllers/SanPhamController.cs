using DoAnCoSo.Areas.Admin.ViewModel.SanPham;
using DoAnCoSo.DTOs;
using DoAnCoSo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SanPhamController : Controller
	{
		private readonly ServiceBase services;
		public SanPhamController()
		{
			services = new ServiceBase();
		}
		public IActionResult Index()
		{
			return View();
		}

		public JsonResult DanhSachSanPham(int? page, int? size)
		{
			var model = services.GetPagedList<ChiTietSanPham, DanhSachSanPhamJsonModel>(page??1, size??10);
			return Json(model);
		}

		public IActionResult ThemSanPham()
		{
			return View();
		}
	}
}