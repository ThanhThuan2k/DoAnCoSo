using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class createfirsttimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangSanXuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSanXuats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCSS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongTinChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongTonKho = table.Column<int>(type: "int", nullable: true),
                    IdHangSanXuat = table.Column<int>(type: "int", nullable: true),
                    IdDanhMuc = table.Column<int>(type: "int", nullable: true),
                    GiaGocSanPham = table.Column<float>(type: "real", nullable: true),
                    TinhTrangMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyCachDongHop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiHanBaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_DanhMucs_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_HangSanXuats_IdHangSanXuat",
                        column: x => x.IdHangSanXuat,
                        principalTable: "HangSanXuats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuongDanAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungMoTaAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenThayThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    ThuocSanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhAnhs_ChiTietSanPham_ThuocSanPhamId",
                        column: x => x.ThuocSanPhamId,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham_MauSac",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdMauSach = table.Column<int>(type: "int", nullable: false),
                    IdMauSac = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_MauSac", x => new { x.IdMauSach, x.IdSanPham });
                    table.ForeignKey(
                        name: "FK_SanPham_MauSac_ChiTietSanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPham_MauSac_MauSacs_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham_ThongSoKyThuats",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdThongSoKyThuat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_ThongSoKyThuats", x => new { x.IdSanPham, x.IdThongSoKyThuat });
                    table.ForeignKey(
                        name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPham_ThongSoKyThuats_ThongSoKyThuats_IdThongSoKyThuat",
                        column: x => x.IdThongSoKyThuat,
                        principalTable: "ThongSoKyThuats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_IdDanhMuc",
                table: "ChiTietSanPham",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_IdHangSanXuat",
                table: "ChiTietSanPham",
                column: "IdHangSanXuat");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnhs_ThuocSanPhamId",
                table: "HinhAnhs",
                column: "ThuocSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MauSac_IdMauSac",
                table: "SanPham_MauSac",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MauSac_IdSanPham",
                table: "SanPham_MauSac",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThongSoKyThuats_IdThongSoKyThuat",
                table: "SanPham_ThongSoKyThuats",
                column: "IdThongSoKyThuat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HinhAnhs");

            migrationBuilder.DropTable(
                name: "SanPham_MauSac");

            migrationBuilder.DropTable(
                name: "SanPham_ThongSoKyThuats");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "ChiTietSanPham");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuats");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "HangSanXuats");
        }
    }
}
