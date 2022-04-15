using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangChiTiet");

            migrationBuilder.AddColumn<string>(
                name: "MaGioHang",
                table: "KhachHang",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonGia",
                table: "GioHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSanPham",
                table: "GioHang",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thanhtien",
                table: "GioHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "soluong",
                table: "GioHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MaGioHang",
                table: "KhachHang",
                column: "MaGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaSanPham",
                table: "GioHang",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_SanPham_MaSanPham",
                table: "GioHang",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_GioHang_MaGioHang",
                table: "KhachHang",
                column: "MaGioHang",
                principalTable: "GioHang",
                principalColumn: "MaGioHang",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_SanPham_MaSanPham",
                table: "GioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_GioHang_MaGioHang",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_MaGioHang",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_GioHang_MaSanPham",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "MaGioHang",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "Thanhtien",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "soluong",
                table: "GioHang");

            migrationBuilder.CreateTable(
                name: "GioHangChiTiet",
                columns: table => new
                {
                    MaGioHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: true),
                    Thanhtien = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    soluong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiet", x => new { x.MaGioHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_GioHang_MaGioHang",
                        column: x => x.MaGioHang,
                        principalTable: "GioHang",
                        principalColumn: "MaGioHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_MaSanPham",
                table: "GioHangChiTiet",
                column: "MaSanPham");
        }
    }
}
