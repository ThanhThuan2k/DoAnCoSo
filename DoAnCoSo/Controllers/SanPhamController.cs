using DoAnCoSo.Data.ModelHelper;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Controllers
{
	public class SanPhamController : Controller
	{
		SanPhamRepository sanPhamRepo;
		public SanPhamController()
		{
			sanPhamRepo = new SanPhamRepository();
		}
		public IActionResult DanhSach(int id = 0)
		{
			return View();
		}

		public async Task<JsonResult> TatCaSanPham()
		{
			var model = await sanPhamRepo.TatCaSanPham();
			return Json(model);
		}

		[Route("/chitietsanpham")]
		[Route("/SanPham/ChiTietSanPham")]
		public async Task<IActionResult> ChiTietSanPham(int? id)
		{
			var model = await sanPhamRepo.GetImageGallery_Product(id ?? 0);
			if (model == null)
			{
				return RedirectToAction("DanhSach");
			}
			return View(model);
		}

		public async Task<JsonResult> ChiTiet(int? id)
		{
			var model = await sanPhamRepo.ChiTietSanPham(id ?? 0);
			return Json(model);
		}

		public async Task<JsonResult> GetGioHang()
		{
			var cookieList = Request.Cookies.Where(x => x.Key.Contains("cart_"))
				.ToList();
			List<GioHangClientModel> gioHangList = new List<GioHangClientModel>();
			foreach (var item in cookieList)
			{
				try
				{
					int currentID = Convert.ToInt32(item.Key.Replace("cart_", ""));
					ChiTietSanPham thisProduct = await sanPhamRepo.GetSanPham(currentID);
					GioHangClientModel cartTemp = new GioHangClientModel()
					{
						Id = currentID,
						TenSanPham = thisProduct.TenSanPham,
						AnhDaiDien = thisProduct.AnhDaiDien,
						SoLuong = Convert.ToInt32(item.Value),
						GiaGocSanPham = thisProduct.GiaGocSanPham,
						GiaHienTai = thisProduct.GiaGocSanPham ?? 0 - thisProduct.GiamGia ?? 0
					};
					gioHangList.Add(cartTemp);
				}
				catch
				{
					continue;
				}
			}
			return Json(gioHangList);
		}
	}
}