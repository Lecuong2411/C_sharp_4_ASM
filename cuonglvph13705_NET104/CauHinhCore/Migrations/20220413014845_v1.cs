using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CauHinhCore.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    restaurantcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaCH", x => x.restaurantcode);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Employeecode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "chới tiệc"),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<bool>(type: "bit", nullable: false),
                    restaurantcode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaNV", x => x.Employeecode);
                    table.ForeignKey(
                        name: "FK_employees_restaurants_restaurantcode",
                        column: x => x.restaurantcode,
                        principalTable: "restaurants",
                        principalColumn: "restaurantcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_restaurantcode",
                table: "employees",
                column: "restaurantcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "restaurants");
        }
    }
}
