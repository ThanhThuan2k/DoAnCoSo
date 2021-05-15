using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class addtwotabledathang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonDatHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTuyChon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiDuPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTienHoaDon = table.Column<double>(type: "float", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThongTinKhachHangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonDatHang_ThongTinKhachHangs_ThongTinKhachHangId",
                        column: x => x.ThongTinKhachHangId,
                        principalTable: "ThongTinKhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonDatHang",
                columns: table => new
                {
                    IdDonDatHang = table.Column<int>(type: "int", nullable: false),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false),
                    DonDatHangId = table.Column<int>(type: "int", nullable: true),
                    ChiTietSanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonDatHang", x => new { x.IdDonDatHang, x.IdSanPham });
                    table.ForeignKey(
                        name: "FK_ChiTietDonDatHang_ChiTietSanPhams_ChiTietSanPhamId",
                        column: x => x.ChiTietSanPhamId,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietDonDatHang_DonDatHang_DonDatHangId",
                        column: x => x.DonDatHangId,
                        principalTable: "DonDatHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonDatHang_ChiTietSanPhamId",
                table: "ChiTietDonDatHang",
                column: "ChiTietSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonDatHang_DonDatHangId",
                table: "ChiTietDonDatHang",
                column: "DonDatHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHang_ThongTinKhachHangId",
                table: "DonDatHang",
                column: "ThongTinKhachHangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonDatHang");

            migrationBuilder.DropTable(
                name: "DonDatHang");
        }
    }
}
