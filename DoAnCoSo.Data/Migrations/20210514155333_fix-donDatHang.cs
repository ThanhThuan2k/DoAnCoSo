using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class fixdonDatHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHangs");

            migrationBuilder.RenameColumn(
                name: "ThongTinKhachHangId",
                table: "DonDatHangs",
                newName: "ThongTinKhachHangNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_DonDatHangs_ThongTinKhachHangId",
                table: "DonDatHangs",
                newName: "IX_DonDatHangs_ThongTinKhachHangNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                column: "ThongTinKhachHangNavigationId",
                principalTable: "ThongTinKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs");

            migrationBuilder.RenameColumn(
                name: "ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                newName: "ThongTinKhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DonDatHangs_ThongTinKhachHangNavigationId",
                table: "DonDatHangs",
                newName: "IX_DonDatHangs_ThongTinKhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHangs",
                column: "ThongTinKhachHangId",
                principalTable: "ThongTinKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
