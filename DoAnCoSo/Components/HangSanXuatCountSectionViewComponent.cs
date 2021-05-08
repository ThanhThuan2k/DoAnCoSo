using DoAnCoSo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSo.Components
{
	public class HangSanXuatCountSectionViewComponent : ViewComponent
	{
		private readonly SanPhamRepository sanPhamRepo = new SanPhamRepository();
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await sanPhamRepo.GetHangSanXuatCount();
			return View(model);
		}
	}
}