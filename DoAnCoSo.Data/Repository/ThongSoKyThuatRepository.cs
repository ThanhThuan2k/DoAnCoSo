using DoAnCoSo.Data.JsonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.Repository
{
	public class ThongSoKyThuatRepository : RepositoryBase
	{
		public List<ThongSoKyThuatJsonModel> GetDistinct()
		{
			List<ThongSoKyThuatJsonModel> thongSoJsonModelList = new List<ThongSoKyThuatJsonModel>();
			List<string> tenThongSoList = db.ThongSoKyThuats.Select(x => x.TenThongSo)
				.Distinct().ToList();
			foreach (string item in tenThongSoList)
			{
				List<MoTaThongSoKyThuatJsonModel> getAllThongSo = db.ThongSoKyThuats
					.Where(x => x.TenThongSo.ToLower() == item.ToLower())
					.Select(x => new MoTaThongSoKyThuatJsonModel()
					{
						Id = x.Id,
						MoTa = x.MoTa
					})
					.OrderByDescending(x => x.Id).ToList();

				ThongSoKyThuatJsonModel createNew = new ThongSoKyThuatJsonModel()
				{
					TenThongSo = item,
					ChiTietMoTa = getAllThongSo
				};
				thongSoJsonModelList.Add(createNew);
			}
			return thongSoJsonModelList;
		}

		public async Task<bool> IsExist(string tenThongSo, string moTa)
		{
			return await db.ThongSoKyThuats.AnyAsync(x => x.TenThongSo.ToLower().Trim() == tenThongSo.ToLower().Trim()
			&& x.MoTa.ToLower().Trim() == moTa.ToLower().Trim());
		}
	}
}