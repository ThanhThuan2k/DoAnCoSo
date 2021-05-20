using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCoSo.Data.Migrations
{
    public partial class addtableloaiphukien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiPhuKienId",
                table: "ChiTietSanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiPhuKiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhuKiens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_LoaiPhuKienId",
                table: "ChiTietSanPhams",
                column: "LoaiPhuKienId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_LoaiPhuKiens_LoaiPhuKienId",
                table: "ChiTietSanPhams",
                column: "LoaiPhuKienId",
                principalTable: "LoaiPhuKiens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_LoaiPhuKiens_LoaiPhuKienId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropTable(
                name: "LoaiPhuKiens");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSanPhams_LoaiPhuKienId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropColumn(
                name: "LoaiPhuKienId",
                table: "ChiTietSanPhams");
        }
    }
}
