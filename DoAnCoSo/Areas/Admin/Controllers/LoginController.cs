using DoAnCoSo.Areas.Admin.ViewModel;
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
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Home", "Admin");
			}
			return View();
		}

		[HttpPost]
		public async Task<JsonResult> Index([FromBody] DangNhapViewModel model)
		{
			if (model != null)
			{
				if (model.username != null && model.password != null)
				{
					string EncryptPassword = PasswordHelper.EncryptSHA512(model.password, model.username);
					LoginJsonModel isSuccess = await loginRepository.SuccessLoginAsync(model.username, EncryptPassword, model.isSupper);
					if (isSuccess.isSuccessfully)
					{
						bool isRoot = isSuccess.isRoot ?? false;
						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, model.username),
							new Claim(ClaimTypes.Role, isRoot ? "SuperAdmin" : "Admin"),
							new Claim("Image", "~/Admin/vendors/images/photo1.jpg")
						};
						var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
							new ClaimsPrincipal(claimsIdentity),
							new AuthenticationProperties()
							{
								IsPersistent = model.RememberMe,
								ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
							});
						HttpContext.User.AddIdentity(claimsIdentity);
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
			else
			{
				return Json(false);
			}
		}
	}
}
