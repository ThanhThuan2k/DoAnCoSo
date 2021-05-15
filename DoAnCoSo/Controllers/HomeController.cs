using DoAnCoSo.Data;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class HomeController : Controller
	{
		private readonly LienHeRepository lienHeRepo;
		public HomeController()
		{
			lienHeRepo = new LienHeRepository();
		}

		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult Index()
		{
			SanPhamRepository sanPham = new SanPhamRepository();
			return View();
		}

		[Route("/lienhe")]
		[AllowAnonymous]
		public IActionResult LienHe()
		{
			return View();
		}

		[Route("/lienhepost")]
		public async Task<JsonResult> LienHe(LienHe model)
		{
			bool isSuccess = await lienHeRepo.ThemLienHe(model);
			return Json(isSuccess);
		}
	}
}