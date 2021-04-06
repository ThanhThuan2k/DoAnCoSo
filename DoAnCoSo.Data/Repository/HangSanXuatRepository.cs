using DoAnCoSo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class HangSanXuatRepository : RepositoryBase
	{
		public HangSanXuatRepository() : base() { }
		public List<HangSanXuat> DanhSach()
		{
			return db.HangSanXuats.OrderBy(item => item.Id).ToList();
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
