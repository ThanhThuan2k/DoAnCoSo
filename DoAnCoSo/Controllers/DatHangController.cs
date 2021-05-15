using DoAnCoSo.Data.ModelHelper;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using DoAnCoSo.Helper;
using DoAnCoSo.Services;
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
	public class DatHangController : Controller
	{
		private readonly TaiKhoanKhachHangRepository taiKhoanRepo;
		private readonly ServiceBase serviceBase;
		private readonly SanPhamRepository sanPhamRepo;
		private readonly DatHangRepository datHangRepo;
		public DatHangController()
		{
			taiKhoanRepo = new TaiKhoanKhachHangRepository();
			serviceBase = new ServiceBase();
			sanPhamRepo = new SanPhamRepository();
			datHangRepo = new DatHangRepository();
		}

		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		[Route("/dathang")]
		public async Task<IActionResult> Index()
		{
			ViewBag.IsLogin = false;
			ViewBag.Disable = "";
			ViewBag.Email = "";
			ViewBag.HoVaTen = "";
			ViewBag.SoDienThoai = "";

			ThongTinKhachHang khachHang = new ThongTinKhachHang();
			if (User.Identity.IsAuthenticated)
			{
				string email = User.Identity.Name;
				if (email != null)
				{
					khachHang = await taiKhoanRepo.GetKhachHang(email);
					ViewBag.IsLogin = true;
					ViewBag.Email = email;
					ViewBag.HoVaTen = khachHang.TenKhachHang;
					ViewBag.SoDienThoai = khachHang.SoDienThoai;
					ViewBag.Disable = "disabled";
				}
			}
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<JsonResult> ThemMoiDonDatHang([FromBody] DonDatHangClientModel model)
		{
			DonDatHang donDatHang = serviceBase.CastTo<DonDatHang>(model);
			donDatHang.DiaChiDuPhong = model.Ward + "," + model.District + "," + model.Province;
			donDatHang.NgayDat = DateTime.Now;

			//Lấy chi tiết đơn đặt hàng với Cookies giỏ hàng
			var cookieList = Request.Cookies.Where(x => x.Key.Contains("cart_"))
				.ToList();
			List<ChiTietDonDatHang> chiTietDonDatHangList = new List<ChiTietDonDatHang>();
			foreach (var item in cookieList)
			{
				try
				{
					int currentID = Convert.ToInt32(item.Key.Replace("cart_", ""));
					ChiTietSanPham thisProduct = await sanPhamRepo.GetSanPham(currentID);
					ChiTietDonDatHang chiTietDonDatHang = new ChiTietDonDatHang()
					{
						ChiTietSanPhamId = currentID,
						SoLuong = Convert.ToInt32(item.Value)
					};
					chiTietDonDatHang.ThanhTien = (thisProduct.GiaGocSanPham ?? 0 - thisProduct.GiamGia ?? 0) * chiTietDonDatHang.SoLuong;
					chiTietDonDatHangList.Add(chiTietDonDatHang);
				}
				catch
				{
					continue;
				}
			}

			donDatHang.ChiTietDonDatHangs = chiTietDonDatHangList;
			double tamTinh = 0;
			foreach(var item in donDatHang.ChiTietDonDatHangs)
			{
				tamTinh += item.ThanhTien;
			}
			donDatHang.TongTienHoaDon = tamTinh;
			bool isSuccess = await datHangRepo.DatHang(donDatHang);
			return Json(isSuccess);
		}

		[Route("/dangnhapthanhtoan")]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult DangNhap()
		{
			if (User.Identity.IsAuthenticated)
			{
				return Redirect("/dathang");
			}
			return View();
		}

		[HttpPost]
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
					return Json(true);
				}
				else
				{
					return Json(false);
				}
			}
		}

		[Route("/dangxuatthanhtoan")]
		public async Task<IActionResult> DangXuat()
		{
			await HttpContext.SignOutAsync("Customer");
			return Redirect("/dathang");
		}
	}
}