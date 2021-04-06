using DoAnCoSo.DTOs;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace DoAnCoSo.Data.Repository
{
	public class HangSanXuatRepository : RepositoryBase
	{
		public HangSanXuatRepository() : base() { }
		public IPagedList<HangSanXuat> DanhSachPhanTrang(int? page, int? size)
		{
			return db.HangSanXuats.ToPagedList(page ?? 1, size ?? 10);
		}

		public async Task<bool> XoaHangSanXuat(int id)
		{
			HangSanXuat hangSX = db.HangSanXuats.Find(id);
			if(hangSX != null)
			{
				db.HangSanXuats.Remove(hangSX);
				await Save();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
