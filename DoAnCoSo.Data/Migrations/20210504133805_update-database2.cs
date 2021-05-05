using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class updatedatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "HangSanXuatId");

            migrationBuilder.RenameColumn(
                name: "ThuocDanhMucId",
                table: "ChiTietSanPhams",
                newName: "DanhMucId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_ThuocHangSanXuatId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_HangSanXuatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_ThuocDanhMucId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_DanhMucId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_DanhMucId",
                table: "ChiTietSanPhams",
                column: "DanhMucId",
                principalTable: "DanhMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_HangSanXuatId",
                table: "ChiTietSanPhams",
                column: "HangSanXuatId",
                principalTable: "HangSanXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_DanhMucId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_HangSanXuatId",
                table: "ChiTietSanPhams");

            migrationBuilder.RenameColumn(
                name: "HangSanXuatId",
                table: "ChiTietSanPhams",
                newName: "ThuocHangSanXuatId");

            migrationBuilder.RenameColumn(
                name: "DanhMucId",
                table: "ChiTietSanPhams",
                newName: "ThuocDanhMucId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_HangSanXuatId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_ThuocHangSanXuatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_DanhMucId",
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
    }
}
