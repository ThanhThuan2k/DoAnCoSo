using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	public class DanhMucController : Controller
	{
		private readonly IWebHostEnvironment host;
		public DanhMucController(IWebHostEnvironment _host)
		{
			host = _host;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
