using DoAnCoSo.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCoSo.Data
{
	public class DoAnCoSoDbContext : DbContext
	{
		public DbSet<DanhMuc> DanhMucs { get; set; }
		public DbSet<HangSanXuat> HangSanXuats { get; set; }
		public DbSet<HinhAnh> HinhAnhs { get; set; }
		public DbSet<MauSac> MauSacs { get; set; }
		public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
		public DbSet<ThongSoKyThuat> ThongSoKyThuats { get; set; }
		public DbSet<SanPham_ThongSoKyThuat> SanPham_ThongSoKyThuats { get; set; }
		public DbSet<TaiKhoanAdmin> TaiKhoanAdmins { get; set; }
		public DbSet<ThongTinKhachHang> ThongTinKhachHangs { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=45.119.83.27;Initial Catalog=DoAnCoSo;Persist Security Info=True;User ID=sa;Password=mssql@12345",
				sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(
						maxRetryCount: 10,
						maxRetryDelay: TimeSpan.FromSeconds(15),
						errorNumbersToAdd: null);
				});
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SanPham_ThongSoKyThuat>().HasKey(table => new
			{
				table.IdSanPham,
				table.IdThongSoKyThuat
			});
		}
	}
}
