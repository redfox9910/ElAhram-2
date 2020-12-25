using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "تحويلات",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    تاريخ = table.Column<DateTime>(nullable: false),
                    نوع = table.Column<string>(nullable: false),
                    قيمة = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_تحويلات", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "تحويلات");
        }
    }
}
