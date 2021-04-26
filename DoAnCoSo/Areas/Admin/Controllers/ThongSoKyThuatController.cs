using DoAnCoSo.Areas.Admin.ViewModel.ThongSoKyThuat;
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
	public class ThongSoKyThuatController : Controller
	{
		private readonly ServiceBase services;
		public ThongSoKyThuatController()
		{
			services = new ServiceBase();
		}

		public IActionResult Index()
		{
			return View();
		}

		public JsonResult DanhSach()
		{
			return Json(services.GetAll<ThongSoKyThuat>());
		}

		[HttpPost]
		public async Task<JsonResult> ThemMoi([FromBody]ThongSoKyThuatJsonModel model)
		{
			bool isSucess = await services.AddAsync<ThongSoKyThuat, ThongSoKyThuatJsonModel>(model);
			if(isSucess)
			{
				return Json(true);
			}
			return Json(false);
		}
	}
}
