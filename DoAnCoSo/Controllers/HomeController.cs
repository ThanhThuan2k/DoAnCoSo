using DoAnCoSo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class HomeController : Controller
	{
		DoAnCoSoDbContext data;
	public	HomeController()
		{
			data = new DoAnCoSoDbContext();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
