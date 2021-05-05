using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updateforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_IdDanhMuc",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_IdHangSanXuat",
                table: "ChiTietSanPhams");

            migrationBuilder.RenameColumn(
                name: "IdHangSanXuat",
                table: "ChiTietSanPhams",
                newName: "ThuocHangSanXuatId");

            migrationBuilder.RenameColumn(
                name: "IdDanhMuc",
                table: "ChiTietSanPhams",
                newName: "ThuocDanhMucId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_IdHangSanXuat",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_ThuocHangSanXuatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_IdDanhMuc",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_ThuocDanhMucId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_ThuocDanhMucId",
                table: "ChiTietSanPhams",
                column: "ThuocDanhMucId",
                principalTable: "DanhMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_ThuocHangSanXuatId",
                table: "ChiTietSanPhams",
                column: "ThuocHangSanXuatId",
                principalTable: "HangSanXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_ThuocDanhMucId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_ThuocHangSanXuatId",
                table: "ChiTietSanPhams");

            migrationBuilder.RenameColumn(
                name: "ThuocHangSanXuatId",
                table: "ChiTietSanPhams",
                newName: "IdHangSanXuat");

            migrationBuilder.RenameColumn(
                name: "ThuocDanhMucId",
                table: "ChiTietSanPhams",
                newName: "IdDanhMuc");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_ThuocHangSanXuatId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_IdHangSanXuat");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_ThuocDanhMucId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_IdDanhMuc");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_IdDanhMuc",
                table: "ChiTietSanPhams",
                column: "IdDanhMuc",
                principalTable: "DanhMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_IdHangSanXuat",
                table: "ChiTietSanPhams",
                column: "IdHangSanXuat",
                principalTable: "HangSanXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
