using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_DoanhMuc_MaDanhMuc",
                table: "GioHang");

            migrationBuilder.RenameColumn(
                name: "MaDanhMuc",
                table: "GioHang",
                newName: "MaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_GioHang_MaDanhMuc",
                table: "GioHang",
                newName: "IX_GioHang_MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_KhachHang_MaKhachHang",
                table: "GioHang",
                column: "MaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_KhachHang_MaKhachHang",
                table: "GioHang");

            migrationBuilder.RenameColumn(
                name: "MaKhachHang",
                table: "GioHang",
                newName: "MaDanhMuc");

            migrationBuilder.RenameIndex(
                name: "IX_GioHang_MaKhachHang",
                table: "GioHang",
                newName: "IX_GioHang_MaDanhMuc");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_DoanhMuc_MaDanhMuc",
                table: "GioHang",
                column: "MaDanhMuc",
                principalTable: "DoanhMuc",
                principalColumn: "MaDoanhMuc",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
