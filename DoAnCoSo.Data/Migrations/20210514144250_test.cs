using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHang_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHang_DonDatHang_DonDatHangId",
                table: "ChiTietDonDatHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHang_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonDatHang",
                table: "DonDatHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonDatHang",
                table: "ChiTietDonDatHang");

            migrationBuilder.RenameTable(
                name: "DonDatHang",
                newName: "DonDatHangs");

            migrationBuilder.RenameTable(
                name: "ChiTietDonDatHang",
                newName: "ChiTietDonDatHangs");

            migrationBuilder.RenameIndex(
                name: "IX_DonDatHang_ThongTinKhachHangId",
                table: "DonDatHangs",
                newName: "IX_DonDatHangs_ThongTinKhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonDatHang_DonDatHangId",
                table: "ChiTietDonDatHangs",
                newName: "IX_ChiTietDonDatHangs_DonDatHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonDatHang_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs",
                newName: "IX_ChiTietDonDatHangs_ChiTietSanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonDatHangs",
                table: "DonDatHangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs",
                columns: new[] { "IdDonDatHang", "IdSanPham" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHangs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHangs_DonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs",
                column: "DonDatHangId",
                principalTable: "DonDatHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHangs",
                column: "ThongTinKhachHangId",
                principalTable: "ThongTinKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_DonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DonDatHangs_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonDatHangs",
                table: "DonDatHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs");

            migrationBuilder.RenameTable(
                name: "DonDatHangs",
                newName: "DonDatHang");

            migrationBuilder.RenameTable(
                name: "ChiTietDonDatHangs",
                newName: "ChiTietDonDatHang");

            migrationBuilder.RenameIndex(
                name: "IX_DonDatHangs_ThongTinKhachHangId",
                table: "DonDatHang",
                newName: "IX_DonDatHang_ThongTinKhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHang",
                newName: "IX_ChiTietDonDatHang_DonDatHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonDatHangs_ChiTietSanPhamId",
                table: "ChiTietDonDatHang",
                newName: "IX_ChiTietDonDatHang_ChiTietSanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonDatHang",
                table: "DonDatHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonDatHang",
                table: "ChiTietDonDatHang",
                columns: new[] { "IdDonDatHang", "IdSanPham" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHang_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHang",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHang_DonDatHang_DonDatHangId",
                table: "ChiTietDonDatHang",
                column: "DonDatHangId",
                principalTable: "DonDatHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonDatHang_ThongTinKhachHangs_ThongTinKhachHangId",
                table: "DonDatHang",
                column: "ThongTinKhachHangId",
                principalTable: "ThongTinKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
