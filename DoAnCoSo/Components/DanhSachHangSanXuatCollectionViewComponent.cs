using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Components
{
	public class DanhSachHangSanXuatCollectionViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			HangSanXuatRepository hangSanXuatRepo = new HangSanXuatRepository();
			var model = await hangSanXuatRepo.GetDanhSachDanhMucCollection();
			return View(model);
		}
	}
}
