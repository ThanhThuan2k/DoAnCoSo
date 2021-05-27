﻿// <auto-generated />
using System;
using DoAnCoSo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnCoSo.Data.Migrations
{
    [DbContext(typeof(DoAnCoSoDbContext))]
    partial class DoAnCoSoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChiTietSanPhamThongSoKyThuat", b =>
                {
                    b.Property<int>("DanhSachThongSoId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamNavigationId")
                        .HasColumnType("int");

                    b.HasKey("DanhSachThongSoId", "SanPhamNavigationId");

                    b.HasIndex("SanPhamNavigationId");

                    b.ToTable("ChiTietSanPhamThongSoKyThuat");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietDonDatHang", b =>
                {
                    b.Property<int>("DonDatHangId")
                        .HasColumnType("int");

                    b.Property<int>("ChiTietSanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("DonDatHangId", "ChiTietSanPhamId");

                    b.HasIndex("ChiTietSanPhamId");

                    b.ToTable("ChiTietDonDatHangs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DanhMucId")
                        .HasColumnType("int");

                    b.Property<double?>("GiaGocSanPham")
                        .HasColumnType("float");

                    b.Property<double?>("GiamGia")
                        .HasColumnType("float");

                    b.Property<int?>("HangSanXuatId")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiPhuKienId")
                        .HasColumnType("int");

                    b.Property<int?>("LuotThich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("LuotXem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("MaSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuyCachDongHop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuongTonKho")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiHanBaoHanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThongTinChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhTrangMay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DanhMucId");

                    b.HasIndex("HangSanXuatId");

                    b.HasIndex("LoaiPhuKienId");

                    b.ToTable("ChiTietSanPhams");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.Config", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Value")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Name")
                        .HasName("PK__Config__737584F71D05C71B");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.DanhMuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDanhMuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DanhMucs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.DonDatHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChiDuPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiTuyChon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TongTienHoaDon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DonDatHangs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HangSanXuat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HangSanXuats");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HinhAnh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DuongDanAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDungMoTaAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThayThe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThuocSanPhamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ThuocSanPhamId");

                    b.ToTable("HinhAnhs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.LienHe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LienHes");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.LoaiPhuKien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoaiPhuKien")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiPhuKiens");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.MauSac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaCSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaMau")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MauSacs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.TaiKhoanAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BiKhoa")
                        .HasColumnType("bit");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LanTruyCapCuoi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHienThi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isSuperAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoanAdmins");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ThongSoKyThuat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThongSo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThongSoKyThuats");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ThongTinKhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BiKhoa")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTaoTaiKhoan")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThongTinKhachHangs");
                });

            modelBuilder.Entity("ChiTietSanPhamThongSoKyThuat", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.ThongSoKyThuat", null)
                        .WithMany()
                        .HasForeignKey("DanhSachThongSoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", null)
                        .WithMany()
                        .HasForeignKey("SanPhamNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietDonDatHang", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", "ChiTietSanPham")
                        .WithMany()
                        .HasForeignKey("ChiTietSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSo.DTOs.DonDatHang", "DonDatHang")
                        .WithMany("ChiTietDonDatHangs")
                        .HasForeignKey("DonDatHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSanPham");

                    b.Navigation("DonDatHang");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.DanhMuc", "DanhMuc")
                        .WithMany("ChiTietSanPhamNavigation")
                        .HasForeignKey("DanhMucId");

                    b.HasOne("DoAnCoSo.DTOs.HangSanXuat", "HangSanXuat")
                        .WithMany("ChiTietSanPhamNavigation")
                        .HasForeignKey("HangSanXuatId");

                    b.HasOne("DoAnCoSo.DTOs.LoaiPhuKien", "LoaiPhuKien")
                        .WithMany("ChiTietSanPhamNavigation")
                        .HasForeignKey("LoaiPhuKienId");

                    b.Navigation("DanhMuc");

                    b.Navigation("HangSanXuat");

                    b.Navigation("LoaiPhuKien");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HinhAnh", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", "ThuocSanPham")
                        .WithMany("DanhSachAnhChiTiet")
                        .HasForeignKey("ThuocSanPhamId");

                    b.Navigation("ThuocSanPham");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.Navigation("DanhSachAnhChiTiet");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.DanhMuc", b =>
                {
                    b.Navigation("ChiTietSanPhamNavigation");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.DonDatHang", b =>
                {
                    b.Navigation("ChiTietDonDatHangs");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HangSanXuat", b =>
                {
                    b.Navigation("ChiTietSanPhamNavigation");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.LoaiPhuKien", b =>
                {
                    b.Navigation("ChiTietSanPhamNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
