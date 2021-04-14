using DoAnCoSo.Areas.Admin.ViewModel;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using DoAnCoSo.Helper;
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
	public class AdminController : Controller
	{
		TaiKhoanAdminRepository taiKhoanAdminRepo = new TaiKhoanAdminRepository();
		private readonly IWebHostEnvironment _host;
		public AdminController(IWebHostEnvironment host)
		{
			_host = host;
		}

		public IActionResult Home()
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> DanhSach()
		{
			var listTaiKhoan = await taiKhoanAdminRepo.DanhSach();
			return Json(listTaiKhoan);
		}

		public IActionResult ThemMoi()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ThemMoi(DangKiTaiKhoanAdminViewModel model)
		{
			string avatar = "";
			if (model.Avatar != null)
			{
				string Path = UploadImgAndReturnPath(model.Avatar, "/Images/Admin/");
				avatar = Path.Split('/').Last();
			}

			string pass = PasswordHelper.EncryptSHA512(model.Password, model.Username);
			TaiKhoanAdmin taiKhoanAdmin = new TaiKhoanAdmin()
			{
				Username = model.Username,
				Password = pass,
				HoTen = model.Ho + " " + model.Ten,
				AnhDaiDien = avatar,
				isSuperAdmin = false,
				BiKhoa = false,
				LanTruyCapCuoi = DateTime.Now,
				DiaChi = model.DiaChi,
				TenHienThi = model.TenHienThi,
				Email = model.Email,
				SoDienThoai = model.SoDienThoai
			};
			await taiKhoanAdminRepo.ThemTaiKhoan(taiKhoanAdmin);
			return RedirectToAction("Index");
		}

		public async Task<JsonResult> ThongTinTaiKhoan(int id)
		{
			var thongTinTaiKhoanAdmin = await taiKhoanAdminRepo.ChiTietTaiKhoan(id);
			if(thongTinTaiKhoanAdmin.Id != 0)
			{
				return Json(thongTinTaiKhoanAdmin);
			}
			return Json(false);
		}

		public async Task<JsonResult> XoaTaiKhoan(int? id)
		{
			if (id != null)
			{
				bool deleteResult = await taiKhoanAdminRepo.XoaTaiKhoan(id ?? 0);
				if (deleteResult)
				{
					return Json(true);
				}
				else
				{
					return Json(false);
				}

			}
			return Json(false);
		}

		[HttpPost]
		public async Task<JsonResult> DeleteAuthorize(string username, string password)
		{
			string encryptPass = PasswordHelper.EncryptSHA512(password, username);
			bool authorize = await taiKhoanAdminRepo.Authorize(username, encryptPass);
			if(authorize)
			{
				return Json(true);
			}
			else
			{
				return Json(false);
			}
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
