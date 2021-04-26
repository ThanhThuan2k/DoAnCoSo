using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class them_danhsachMauSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChiTietSanPhamId",
                table: "MauSacs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MauSacs_ChiTietSanPhamId",
                table: "MauSacs",
                column: "ChiTietSanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_ChiTietSanPham_ChiTietSanPhamId",
                table: "MauSacs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_ChiTietSanPham_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropIndex(
                name: "IX_MauSacs_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropColumn(
                name: "ChiTietSanPhamId",
                table: "MauSacs");
        }
    }
}
