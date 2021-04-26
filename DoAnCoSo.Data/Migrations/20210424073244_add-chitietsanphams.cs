using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class addchitietsanphams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_DanhMucs_IdDanhMuc",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_HangSanXuats_IdHangSanXuat",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnhs_ChiTietSanPham_ThuocSanPhamId",
                table: "HinhAnhs");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_ChiTietSanPham_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPham_IdSanPham",
                table: "SanPham_ThongSoKyThuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietSanPham",
                table: "ChiTietSanPham");

            migrationBuilder.RenameTable(
                name: "ChiTietSanPham",
                newName: "ChiTietSanPhams");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_IdHangSanXuat",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_IdHangSanXuat");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_IdDanhMuc",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_IdDanhMuc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietSanPhams",
                table: "ChiTietSanPhams",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnhs_ChiTietSanPhams_ThuocSanPhamId",
                table: "HinhAnhs",
                column: "ThuocSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "MauSacs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPhams_IdSanPham",
                table: "SanPham_ThongSoKyThuats",
                column: "IdSanPham",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_DanhMucs_IdDanhMuc",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_HangSanXuats_IdHangSanXuat",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnhs_ChiTietSanPhams_ThuocSanPhamId",
                table: "HinhAnhs");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPhams_IdSanPham",
                table: "SanPham_ThongSoKyThuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietSanPhams",
                table: "ChiTietSanPhams");

            migrationBuilder.RenameTable(
                name: "ChiTietSanPhams",
                newName: "ChiTietSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_IdHangSanXuat",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_IdHangSanXuat");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_IdDanhMuc",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_IdDanhMuc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietSanPham",
                table: "ChiTietSanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_DanhMucs_IdDanhMuc",
                table: "ChiTietSanPham",
                column: "IdDanhMuc",
                principalTable: "DanhMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_HangSanXuats_IdHangSanXuat",
                table: "ChiTietSanPham",
                column: "IdHangSanXuat",
                principalTable: "HangSanXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnhs_ChiTietSanPham_ThuocSanPhamId",
                table: "HinhAnhs",
                column: "ThuocSanPhamId",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_ChiTietSanPham_ChiTietSanPhamId",
                table: "MauSacs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_ThongSoKyThuats_ChiTietSanPham_IdSanPham",
                table: "SanPham_ThongSoKyThuats",
                column: "IdSanPham",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
