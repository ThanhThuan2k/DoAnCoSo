using DoAnCoSo.Data.JsonModel;
using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class DanhMucRepository : RepositoryBase
	{
		public DanhMucRepository() : base() { }

		public async Task<List<DanhMucJsonModel>> DanhSach()
		{
			return await db.DanhMucs.Select(item => new DanhMucJsonModel()
			{
				TenDanhMuc = item.TenDanhMuc,
				Id = item.Id,
				Icon = item.Icon
			}).OrderByDescending(x => x.Id).ToListAsync();
		}
		
		public async Task ThemDanhMuc(string tenDanhMuc)
		{
			if (tenDanhMuc != null && tenDanhMuc != "")
			{
				DanhMuc newDanhMuc = new DanhMuc()
				{
					TenDanhMuc = tenDanhMuc
				};
				await db.DanhMucs.AddAsync(newDanhMuc);
				await Save();
			}
		}

		public async Task ThemDanhMuc(string tenDanhMuc, string duongDanAnh)
		{
			DanhMuc newDanhMuc = new DanhMuc();
			if (tenDanhMuc != null && tenDanhMuc != "")
			{
				newDanhMuc.TenDanhMuc = tenDanhMuc;
			}
			if(duongDanAnh != null && duongDanAnh != "")
			{
				newDanhMuc.Icon = duongDanAnh;
			}
			await db.DanhMucs.AddAsync(newDanhMuc);
			await Save();
		}

		public async Task<DanhMucJsonModel> ChiTietDanhMuc(int id)
		{
			return await db.DanhMucs.Select(item => new DanhMucJsonModel()
				{
					TenDanhMuc = item.TenDanhMuc,
					Icon = item.Icon,
					Id = item.Id
				}).SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task ChinhSuaTenDanhMuc(int id, string tenDanhMuc)
		{
			if(tenDanhMuc != null)
			{
				DanhMuc danhMuc = await db.DanhMucs.FindAsync(id);
				if(danhMuc != null)
				{
					danhMuc.TenDanhMuc = tenDanhMuc;
					await Save();
				}
			}
		}

		public async Task ChinhSuaIconDanhMuc(int id, string icon)
		{
			if(icon != null)
			{
				DanhMuc danhMuc = await db.DanhMucs.FindAsync(id);
				if(danhMuc != null)
				{
					danhMuc.Icon = icon;
					await Save();
				}
			}
		}

		public async Task<bool> Xoa(int? id)
		{
			if(id != null)
			{
				DanhMuc danhMuc = await db.DanhMucs.FindAsync(id);
				if(danhMuc != null)
				{
					var sanPhamList = db.ChiTietSanPhams.Where(x => x.IdDanhMuc == id)
						.ToList();
					if(sanPhamList.Count() > 0)
					{
						foreach(var item in sanPhamList)
						{
							item.IdDanhMuc = null;
						}
					}
					db.DanhMucs.Remove(danhMuc);
					await Save();
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}
}
