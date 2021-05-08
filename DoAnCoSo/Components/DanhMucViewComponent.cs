using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Components
{
	public class DanhMucViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			SanPhamRepository sanPhamRepo = new SanPhamRepository();
			var model = await sanPhamRepo.GetDanhMuc();
			return View(model);
		}
	}
}
