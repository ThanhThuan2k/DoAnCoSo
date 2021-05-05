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

                    b.Property<int?>("HangSanXuatId")
                        .HasColumnType("int");

                    b.Property<string>("MaSanPham")
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

                    b.ToTable("ChiTietSanPhams");
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

                    b.Property<bool>("AnhDaiDienKhachHang")
                        .HasColumnType("bit");

                    b.Property<bool>("BiKhoa")
                        .HasColumnType("bit");

                    b.Property<string>("DanhXung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTaoTaiKhoan")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
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

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.DanhMuc", "DanhMuc")
                        .WithMany("ChiTietSanPhamNavigation")
                        .HasForeignKey("DanhMucId");

                    b.HasOne("DoAnCoSo.DTOs.HangSanXuat", "HangSanXuat")
                        .WithMany("ChiTietSanPhamNavigation")
                        .HasForeignKey("HangSanXuatId");

                    b.Navigation("DanhMuc");

                    b.Navigation("HangSanXuat");
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

            modelBuilder.Entity("DoAnCoSo.DTOs.HangSanXuat", b =>
                {
                    b.Navigation("ChiTietSanPhamNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
