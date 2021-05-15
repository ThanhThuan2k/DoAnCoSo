using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updatetaiKhoanKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhDaiDienKhachHang",
                table: "ThongTinKhachHangs");

            migrationBuilder.DropColumn(
                name: "DanhXung",
                table: "ThongTinKhachHangs");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "ThongTinKhachHangs");

            migrationBuilder.DropColumn(
                name: "TenDangNhap",
                table: "ThongTinKhachHangs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnhDaiDienKhachHang",
                table: "ThongTinKhachHangs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DanhXung",
                table: "ThongTinKhachHangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "ThongTinKhachHangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDangNhap",
                table: "ThongTinKhachHangs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
