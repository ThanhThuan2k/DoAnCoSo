using DoAnCoSo.Areas.Admin.ViewModel.SanPham;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using DoAnCoSo.Helper;
using DoAnCoSo.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SanPhamController : Controller
	{
		private readonly IWebHostEnvironment _host;
		private readonly ServiceBase services;
		private readonly SanPhamRepository sanPhamRepo;
		private readonly ThongSoKyThuatRepository thongSoRepo;

		public SanPhamController(IWebHostEnvironment host)
		{
			_host = host;
			services = new ServiceBase();
			sanPhamRepo = new SanPhamRepository();
			thongSoRepo = new ThongSoKyThuatRepository();
		}
		public IActionResult Index()
		{
			return View();
		}

		public JsonResult DanhSachSanPham(int? page, int? size)
		{
			var x = sanPhamRepo.getSanPham(10);
			var model = services.GetPagedList<ChiTietSanPham, DanhSachSanPhamJsonModel>(page ?? 1, size ?? 10);
			return Json(model);
		}

		public IActionResult ThemSanPham()
		{
			ViewBag.MauSac = services.GetAll<MauSac>();
			ViewBag.HangSanXuat = services.GetAll<HangSanXuat>();
			ViewBag.DanhMuc = services.GetAll<DanhMuc>();
			ViewBag.ThongSoKyThuat = thongSoRepo.GetDistinct();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ThemSanPham(ThemSanPhamJsonModel data)
		{
			ChiTietSanPham chiTietSanPham = services.CastTo<ChiTietSanPham>(data);
			chiTietSanPham.MaSanPham = PasswordHelper.CreateSalt(5, 7);
			foreach (int item in data.ThongSoKyThuat)
			{
				chiTietSanPham.DanhSachThongSo.Add(sanPhamRepo.TimThongSo(item));
			}

			chiTietSanPham.DanhMuc = sanPhamRepo.TimDanhMuc(data.IdDanhMuc ?? 0);
			chiTietSanPham.HangSanXuat = sanPhamRepo.TimHangSanXuat(data.IdHangSanXuat ?? 0);

			if (data.anhDaiDien != null)
			{
				string anhDaiDienPath = UploadImgAndReturnPath(data.anhDaiDien, "/Images/SanPham/");
				anhDaiDienPath = anhDaiDienPath.Split('/').Last();
				chiTietSanPham.AnhDaiDien = anhDaiDienPath;
			}

			if (data.danhSachAnhChiTiet.Count() > 0)
			{
				foreach (IFormFile item in data.danhSachAnhChiTiet)
				{
					string tempPath = UploadImgAndReturnPath(item, "/Images/SanPham/");
					tempPath = tempPath.Split('/').Last();
					chiTietSanPham.DanhSachAnhChiTiet.Add(new HinhAnh()
					{
						DuongDanAnh = tempPath
					});
				}
			}

			bool isSuccess = await sanPhamRepo.Add(chiTietSanPham);
			if (isSuccess)
			{
				return RedirectToAction("Index", "SanPham");
			}
			else
			{
				return RedirectToAction("ThemSanPham", "SanPham");
			}
		}

		public async Task<IActionResult> SuaSanPham(int id)
		{
			ChiTietSanPham sanPham = await sanPhamRepo.GetSanPham(id);
			if (sanPham != null)
			{
				return View(sanPham);
			}
			return View();
		}

		string UploadImgAndReturnPath(IFormFile file, string childFolder = "/Images/", bool saveInWwwRoot = true)
		{
			var y = _host.WebRootPath;
			var root = saveInWwwRoot ? _host.WebRootPath : _host.ContentRootPath;
			var filename = Path.GetFileNameWithoutExtension(file.FileName)
							+ DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff")
							+ Path.GetExtension(file.FileName);
			if (!Directory.Exists(root + childFolder))
			{
				Directory.CreateDirectory(root + childFolder);
			}
			var relativePath = childFolder + filename;
			var path = root + relativePath;
			var x = new FileStream(path, FileMode.Create);
			file.CopyTo(x);
			x.Dispose();
			GC.Collect();
			return relativePath;
		}
	}
}