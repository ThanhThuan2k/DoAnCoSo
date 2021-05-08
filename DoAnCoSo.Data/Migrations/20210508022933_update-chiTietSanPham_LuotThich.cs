using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updatechiTietSanPham_LuotThich : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LuotThich",
                table: "ChiTietSanPhams",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LuotXem",
                table: "ChiTietSanPhams",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuotThich",
                table: "ChiTietSanPhams");

            migrationBuilder.DropColumn(
                name: "LuotXem",
                table: "ChiTietSanPhams");
        }
    }
}
