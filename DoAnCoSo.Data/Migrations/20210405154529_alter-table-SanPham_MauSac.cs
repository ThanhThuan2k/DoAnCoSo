using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class altertableSanPham_MauSac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MauSac_MauSacs_IdMauSac",
                table: "SanPham_MauSac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham_MauSac",
                table: "SanPham_MauSac");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MauSac_IdMauSac",
                table: "SanPham_MauSac");

            migrationBuilder.DropColumn(
                name: "IdMauSach",
                table: "SanPham_MauSac");

            migrationBuilder.AlterColumn<int>(
                name: "IdMauSac",
                table: "SanPham_MauSac",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham_MauSac",
                table: "SanPham_MauSac",
                columns: new[] { "IdMauSac", "IdSanPham" });

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MauSac_MauSacs_IdMauSac",
                table: "SanPham_MauSac",
                column: "IdMauSac",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MauSac_MauSacs_IdMauSac",
                table: "SanPham_MauSac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham_MauSac",
                table: "SanPham_MauSac");

            migrationBuilder.AlterColumn<int>(
                name: "IdMauSac",
                table: "SanPham_MauSac",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdMauSach",
                table: "SanPham_MauSac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham_MauSac",
                table: "SanPham_MauSac",
                columns: new[] { "IdMauSach", "IdSanPham" });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MauSac_IdMauSac",
                table: "SanPham_MauSac",
                column: "IdMauSac");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MauSac_MauSacs_IdMauSac",
                table: "SanPham_MauSac",
                column: "IdMauSac",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
