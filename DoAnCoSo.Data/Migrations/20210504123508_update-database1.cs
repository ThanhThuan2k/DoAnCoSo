using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updatedatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham_ThongSoKyThuats");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "HinhAnhs");

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhamThongSoKyThuat",
                columns: table => new
                {
                    DanhSachThongSoId = table.Column<int>(type: "int", nullable: false),
                    SanPhamNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhamThongSoKyThuat", x => new { x.DanhSachThongSoId, x.SanPhamNavigationId });
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamThongSoKyThuat_ChiTietSanPhams_SanPhamNavigationId",
                        column: x => x.SanPhamNavigationId,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamThongSoKyThuat_ThongSoKyThuats_DanhSachThongSoId",
                        column: x => x.DanhSachThongSoId,
                        principalTable: "ThongSoKyThuats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamThongSoKyThuat_SanPhamNavigationId",
                table: "ChiTietSanPhamThongSoKyThuat",
                column: "SanPhamNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietSanPhamThongSoKyThuat");

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "HinhAnhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                        name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "ChiTietSanPhams",
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
                name: "IX_SanPham_ThongSoKyThuats_IdThongSoKyThuat",
                table: "SanPham_ThongSoKyThuats",
                column: "IdThongSoKyThuat");
        }
    }
}
