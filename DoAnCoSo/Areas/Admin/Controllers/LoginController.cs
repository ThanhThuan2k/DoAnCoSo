using DoAnCoSo.Data.JsonModel;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		private readonly LoginRepository loginRepository;
		public LoginController()
		{
			loginRepository = new LoginRepository();
		}

		public IActionResult Index()
		{
			if(User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Home", "Admin");
			}
			return View();
		}

		[HttpPost]
		public async Task<JsonResult> Index(string username, string password, bool isSuper, bool RememberMe)
		{
			if(username != null && password != null)
			{
				string EncryptPassword = PasswordHelper.EncryptSHA512(password, username);
				LoginJsonModel isSuccess = await loginRepository.SuccessLogin(username, EncryptPassword, isSuper);
				if(isSuccess.isSuccessfully)
				{
					bool isRoot = isSuccess.isRoot ?? false;
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, username),
						new Claim(ClaimTypes.Role, isRoot ? "SuperAdmin" : "Admin")
					};
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(claimsIdentity),
						new AuthenticationProperties()
						{
							IsPersistent = RememberMe,
							ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
						});
					return Json(true);
				}
				else
				{
					return Json(false);
				}
			}
			else
			{
				return Json(false);
			}
		}
	}
}
