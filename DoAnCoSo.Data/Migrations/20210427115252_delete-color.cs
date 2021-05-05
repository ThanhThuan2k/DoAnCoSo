using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class deletecolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropIndex(
                name: "IX_MauSacs_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropColumn(
                name: "ChiTietSanPhamId",
                table: "MauSacs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_MauSacs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "MauSacs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
