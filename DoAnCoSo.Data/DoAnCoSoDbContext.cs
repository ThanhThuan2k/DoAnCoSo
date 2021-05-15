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
		public DbSet<TaiKhoanAdmin> TaiKhoanAdmins { get; set; }
		public DbSet<ThongTinKhachHang> ThongTinKhachHangs { get; set; }
		public DbSet<DonDatHang> DonDatHangs { get; set; }
		public DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
		public DbSet<LienHe> LienHes { get; set; }
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
			modelBuilder.Entity<ChiTietSanPham>()
				.Property(x => x.LuotThich)
				.HasDefaultValue(0);
			modelBuilder.Entity<ChiTietSanPham>()
				.Property(x => x.LuotXem)
				.HasDefaultValue(0);
			modelBuilder.Entity<ChiTietDonDatHang>()
				.HasKey(x => new
				{
					x.DonDatHangId,
					x.ChiTietSanPhamId
				});
		}
	}
}
