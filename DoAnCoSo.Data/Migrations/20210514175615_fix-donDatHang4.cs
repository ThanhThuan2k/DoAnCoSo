using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class fixdonDatHang4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_DonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropColumn(
                name: "IdDonDatHang",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "ChiTietDonDatHangs");

            migrationBuilder.AlterColumn<int>(
                name: "DonDatHangId",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChiTietSanPhamId",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs",
                columns: new[] { "DonDatHangId", "ChiTietSanPhamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHangs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonDatHangs_DonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs",
                column: "DonDatHangId",
                principalTable: "DonDatHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_ChiTietSanPhams_ChiTietSanPhamId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonDatHangs_DonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs");

            migrationBuilder.AlterColumn<int>(
                name: "ChiTietSanPhamId",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DonDatHangId",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdDonDatHang",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "ChiTietDonDatHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonDatHangs",
                table: "ChiTietDonDatHangs",
                columns: new[] { "IdDonDatHang", "IdSanPham" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonDatHangs_DonDatHangId",
                table: "ChiTietDonDatHangs",
                column: "DonDatHangId");

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
        }
    }
}
