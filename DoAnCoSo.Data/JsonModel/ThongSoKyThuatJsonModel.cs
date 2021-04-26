using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.JsonModel
{
	public class ThongSoKyThuatJsonModel
	{
		public string TenThongSo { get; set; }
		public List<MoTaThongSoKyThuatJsonModel> ChiTietMoTa { get; set; }
	}
}
