using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
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
	public class HangSanXuatController : Controller
	{
		private readonly IWebHostEnvironment _host;
		private readonly HangSanXuatRepository hangSanXuatRepo = new HangSanXuatRepository();
		public HangSanXuatController(IWebHostEnvironment host)
		{
			_host = host;
		}
		public IActionResult Index()
		{
			return View();
		}

		public JsonResult DanhSachHangSanXuat()
		{
			List<HangSanXuat> danhSachHangSanXuat = hangSanXuatRepo.DanhSach();
			return Json(danhSachHangSanXuat);
		}

		[HttpPost]
		public async Task<IActionResult> ThemMoi(string tenHang, IFormFile anhDaiDien)
		{
			try
			{
				string relativePath = UploadImgAndReturnPath(anhDaiDien, "/Images/HangSanXuat/");
				string imageName = relativePath.Split('/').Last();
				await hangSanXuatRepo.Create(tenHang, imageName);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		public async Task<JsonResult> ChiTietHangSanXuat(int? id)
		{
			if(id != null)
			{
				HangSanXuat chiTiet = await hangSanXuatRepo.ThongTinHangSanXuat(id??0);
				if(chiTiet.Id != 0)
				{
					return Json(chiTiet);
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

		[HttpPost]
		public async Task<IActionResult> ChinhSua(int id, string tenHang, IFormFile anhDaiDien)
		{
			if(tenHang == null && anhDaiDien == null)
			{
				// không có sự thay đổi, ko cần update
				return RedirectToAction("Index");
			}
			else
			{
				// kiểm tra xem phần nào đã thay đổi
				if(tenHang != null)
				{
					await hangSanXuatRepo.ChinhSuaTen(id, tenHang);
				}
				if(anhDaiDien != null)
				{
					string relativePath = UploadImgAndReturnPath(anhDaiDien, "/Images/HangSanXuat/");
					string nameOfImage = relativePath.Split('/').Last();
					await hangSanXuatRepo.ChinhSuaAnhDaiDien(id, nameOfImage);
				}
			}
			return RedirectToAction("Index");
		}

		public async Task<JsonResult> Xoa(int? id)
		{
			if (id == null)
			{
				return Json(false);
			}
			else
			{
				bool deleteResult = await hangSanXuatRepo.XoaHangSanXuat(id ?? 0);
				if (deleteResult == false)
				{
					return Json(false);
				}
			}
			return Json(true);
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
