using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DonDatHangController : Controller
	{
		DatHangRepository datHangRepo = new DatHangRepository();
		public async Task<IActionResult> Index()
		{
			var model = await datHangRepo.GetAllDonDatHang();
			return View(model);
		}
	}
}
