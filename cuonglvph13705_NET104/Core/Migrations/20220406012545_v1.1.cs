using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loves",
                columns: table => new
                {
                    MaLove = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GVCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Siso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loves", x => x.MaLove);
                });

            migrationBuilder.CreateTable(
                name: "sinhViens",
                columns: table => new
                {
                    msv = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinhViens", x => x.msv);
                });

            migrationBuilder.CreateTable(
                name: "LoveSinhVien",
                columns: table => new
                {
                    LovesMaLove = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SinhViensmsv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoveSinhVien", x => new { x.LovesMaLove, x.SinhViensmsv });
                    table.ForeignKey(
                        name: "FK_LoveSinhVien_loves_LovesMaLove",
                        column: x => x.LovesMaLove,
                        principalTable: "loves",
                        principalColumn: "MaLove",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoveSinhVien_sinhViens_SinhViensmsv",
                        column: x => x.SinhViensmsv,
                        principalTable: "sinhViens",
                        principalColumn: "msv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoveSinhVien_SinhViensmsv",
                table: "LoveSinhVien",
                column: "SinhViensmsv");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoveSinhVien");

            migrationBuilder.DropTable(
                name: "loves");

            migrationBuilder.DropTable(
                name: "sinhViens");
        }
    }
}
