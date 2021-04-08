using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updatedatabase84 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "TaiKhoanAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TaiKhoanAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "TaiKhoanAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenHienThi",
                table: "TaiKhoanAdmins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "TaiKhoanAdmins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TaiKhoanAdmins");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "TaiKhoanAdmins");

            migrationBuilder.DropColumn(
                name: "TenHienThi",
                table: "TaiKhoanAdmins");
        }
    }
}
