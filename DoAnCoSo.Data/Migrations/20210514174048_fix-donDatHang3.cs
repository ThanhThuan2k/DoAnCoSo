using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class fixdonDatHang3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs");

            migrationBuilder.DropIndex(
                name: "IX_DonDatHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs");

            migrationBuilder.DropColumn(
                name: "ThongTinKhachHangNavigationId",
                table: "DonDatHangs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                column: "ThongTinKhachHangNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                column: "ThongTinKhachHangNavigationId",
                principalTable: "ThongTinKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
