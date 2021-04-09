﻿// <auto-generated />
using System;
using DoAnCoSo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnCoSo.Data.Migrations
{
    [DbContext(typeof(DoAnCoSoDbContext))]
    [Migration("20210409112934_fix-admin-table")]
    partial class fixadmintable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("GiaGocSanPham")
                        .HasColumnType("real");

                    b.Property<int?>("IdDanhMuc")
                        .HasColumnType("int");

                    b.Property<int?>("IdHangSanXuat")
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

                    b.HasIndex("IdDanhMuc");

                    b.HasIndex("IdHangSanXuat");

                    b.ToTable("ChiTietSanPham");
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

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

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

            modelBuilder.Entity("DoAnCoSo.DTOs.SanPham_MauSac", b =>
                {
                    b.Property<int>("IdMauSac")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.HasKey("IdMauSac", "IdSanPham");

                    b.HasIndex("IdSanPham");

                    b.ToTable("SanPham_MauSac");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.SanPham_ThongSoKyThuat", b =>
                {
                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("IdThongSoKyThuat")
                        .HasColumnType("int");

                    b.HasKey("IdSanPham", "IdThongSoKyThuat");

                    b.HasIndex("IdThongSoKyThuat");

                    b.ToTable("SanPham_ThongSoKyThuats");
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

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.DanhMuc", "ThuocDanhMuc")
                        .WithMany("SanPhamNavigation")
                        .HasForeignKey("IdDanhMuc");

                    b.HasOne("DoAnCoSo.DTOs.HangSanXuat", "ThuocHangSanXuat")
                        .WithMany("SanPhamNavigation")
                        .HasForeignKey("IdHangSanXuat");

                    b.Navigation("ThuocDanhMuc");

                    b.Navigation("ThuocHangSanXuat");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HinhAnh", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", "ThuocSanPham")
                        .WithMany("DanhSachAnhChiTiet")
                        .HasForeignKey("ThuocSanPhamId");

                    b.Navigation("ThuocSanPham");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.SanPham_MauSac", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.MauSac", "MauSac")
                        .WithMany("SanPhamNavigation")
                        .HasForeignKey("IdMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", "SanPham")
                        .WithMany("DanhSachMauSac")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.SanPham_ThongSoKyThuat", b =>
                {
                    b.HasOne("DoAnCoSo.DTOs.ChiTietSanPham", "SanPham")
                        .WithMany("DanhSachThongSo")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSo.DTOs.ThongSoKyThuat", "ThongSoKyThuat")
                        .WithMany("SanPhamNavigation")
                        .HasForeignKey("IdThongSoKyThuat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("ThongSoKyThuat");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ChiTietSanPham", b =>
                {
                    b.Navigation("DanhSachAnhChiTiet");

                    b.Navigation("DanhSachMauSac");

                    b.Navigation("DanhSachThongSo");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.DanhMuc", b =>
                {
                    b.Navigation("SanPhamNavigation");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.HangSanXuat", b =>
                {
                    b.Navigation("SanPhamNavigation");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.MauSac", b =>
                {
                    b.Navigation("SanPhamNavigation");
                });

            modelBuilder.Entity("DoAnCoSo.DTOs.ThongSoKyThuat", b =>
                {
                    b.Navigation("SanPhamNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
