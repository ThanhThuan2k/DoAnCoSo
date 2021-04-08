using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class QuanLyAnhController : Controller
	{
		public IActionResult Index(IFormFile image = null, string path = "")
		{
			return View();
		}
	}
}
