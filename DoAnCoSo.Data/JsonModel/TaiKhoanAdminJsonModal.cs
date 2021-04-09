using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data.JsonModel
{
	public class TaiKhoanAdminJsonModal
	{
		public int Id { get; set; }
		public string TenHienThi { get; set; }
		public string HoTen { get; set; }
		public DateTime? LanTruyCapCuoi { get; set; }
		public string AnhDaiDien { get; set; }
	}
}
