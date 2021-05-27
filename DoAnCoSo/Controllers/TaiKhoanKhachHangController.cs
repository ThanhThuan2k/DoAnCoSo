using DoAnCoSo.Data.ModelHelper;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class TaiKhoanKhachHangController : Controller
	{
		private readonly TaiKhoanKhachHangRepository taiKhoanRepo;

		public TaiKhoanKhachHangController()
		{
			taiKhoanRepo = new TaiKhoanKhachHangRepository();
		}

		[Route("/dangkitaikhoan")]
		[Route("/dangkytaikhoan")]
		[AllowAnonymous]
		public IActionResult DangKy()
		{
			return View();
		}

		[HttpPost]
		[Route("/dangkitaikhoanpost")]
		[AllowAnonymous]
		public async Task<IActionResult> DangKy([FromBody] DangKiClientModel model)
		{
			// check email is exist ?
			List<string> danhSachEmailKhachHang = await taiKhoanRepo.GetAllEmail();
			bool exist = false;
			foreach (string item in danhSachEmailKhachHang)
			{
				if (item == model.Email)
					exist = true;
			}

			if (!exist)
			{
				model.TenKhachHang = model.Ho + " " + model.Ten;
				model.MatKhau = PasswordHelper.EncryptSHA512(model.MatKhau, model.Email);
				bool isSuccess = await taiKhoanRepo.TaoMoiTaiKhoan(model);
				if (!isSuccess)
				{
					return Ok("Thất bại, vui lòng thử lại sau ít phút");
				}
				else
				{
					var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, model.Email),
							new Claim(ClaimTypes.Role, "Customer")
						};
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync("Customer",
					   new ClaimsPrincipal(claimsIdentity),
					   new AuthenticationProperties()
					   {
						   IsPersistent = true,
						   ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
					   });
					return Ok("Thành công");
				}
			}
			else
			{
				return Ok("Email đã tồn tại, vui lòng chọn email khác");
			}

		}

		[Route("/dangnhaptaikhoan")]
		[Route("/dangnhap")]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult DangNhap()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpPost]
		[Route("/dangnhappost")]
		public async Task<JsonResult> DangNhap([FromBody] DangNhapClientModel dangNhap)
		{
			if (dangNhap.Email == null || dangNhap.Password == null)
			{
				return Json(false);
			}
			else
			{
				string EncryptPassword = PasswordHelper.EncryptSHA512(dangNhap.Password, dangNhap.Email);
				bool isExist = await taiKhoanRepo.DangNhap(dangNhap.Email, EncryptPassword);
				if (isExist)
				{
					var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, dangNhap.Email),
							new Claim(ClaimTypes.Role, "Customer")
						};
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync("Customer",
					   new ClaimsPrincipal(claimsIdentity),
					   new AuthenticationProperties()
					   {
						   IsPersistent = true,
						   ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
					   });
					var user = User.Identity.Name;
					return Json(true);
				}
				else
				{
					return Json(false);
				}
			}
		}

		[Route("/dangxuat")]
		public async Task<IActionResult> DangXuat()
		{
			await HttpContext.SignOutAsync("Customer");
			return RedirectToAction("Index", "Home");
		}

		[Route("/chi-tiet-tai-khoan")]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> ChiTietTaiKhoanKhachHang()
		{
			if (User.Identity.IsAuthenticated)
			{
				var model = await taiKhoanRepo.ChiTietTaiKhoanKhachHang(User.Identity.Name);
				if (model != null)
				{
					return View(model);
				}
				else
				{
					return Redirect("/dangxuat");
				}
			}
			else
			{
				return Redirect("/dangnhap");
			}
		}
	}
}
