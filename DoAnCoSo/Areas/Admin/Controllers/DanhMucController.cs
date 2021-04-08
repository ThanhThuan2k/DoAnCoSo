using DoAnCoSo.Data.JsonModel;
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
	public class DanhMucController : Controller
	{
		private readonly IWebHostEnvironment _host;
		private readonly DanhMucRepository danhMucRepo = new DanhMucRepository();
		public DanhMucController(IWebHostEnvironment host)
		{
			_host = host;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> DanhSach()
		{
			List<DanhMucJsonModel> danhSach = await danhMucRepo.DanhSach();
			return Json(danhSach);
		}

		public async Task<IActionResult> ThemMoi(string tenDanhMuc, IFormFile icon)
		{
			if (tenDanhMuc != null && icon != null)
			{
				string path = UploadImgAndReturnPath(icon, "/Images/DanhMuc/");
				string tenIcon = path.Split('/').Last();
				await danhMucRepo.ThemDanhMuc(tenDanhMuc, tenIcon);
			}
			else if (tenDanhMuc != null)
			{
				await danhMucRepo.ThemDanhMuc(tenDanhMuc);
			}
			return RedirectToAction("Index");
		}

		public async Task<JsonResult> ChiTiet(int? id)
		{
			if (id == null)
			{
				return Json(false);
			}
			else
			{
				DanhMucJsonModel danhMuc = await danhMucRepo.ChiTietDanhMuc(id ?? 0);
				if (danhMuc.Id == 0)
				{
					return Json(false);
				}
				else
				{
					return Json(danhMuc);
				}
			}
		}

		public async Task<IActionResult> ChinhSua(int? id, string tenDanhMuc, IFormFile icon)
		{
			if (id != null)
			{
				if (tenDanhMuc == null && icon == null)
				{
					return RedirectToAction("Index");
				}
				else
				{
					if (tenDanhMuc != null)
					{
						await danhMucRepo.ChinhSuaTenDanhMuc(id ?? 0, tenDanhMuc);
					}
					if (icon != null)
					{
						string path = UploadImgAndReturnPath(icon, "/Images/DanhMuc/");
						string iconName = path.Split('/').Last();
						await danhMucRepo.ChinhSuaIconDanhMuc(id ?? 0, iconName);
					}
				}
			}
			return RedirectToAction("Index");
		}

		public async Task<JsonResult> Xoa(int? id)
		{
			if (id != null)
			{
				bool isSuccess = await danhMucRepo.Xoa(id ?? 0);
				if (isSuccess)
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
