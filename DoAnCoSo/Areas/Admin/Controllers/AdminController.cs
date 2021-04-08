using DoAnCoSo.Areas.Admin.ViewModel;
using DoAnCoSo.Data.Repository;
using DoAnCoSo.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        TaiKhoanAdminRepository taiKhoanAdminRepo = new TaiKhoanAdminRepository();
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
            return View();
		}
    }
}
