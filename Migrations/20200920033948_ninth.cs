using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة");

            migrationBuilder.AddColumn<string>(
                name: "رقم",
                table: "خزنة",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة",
                column: "رقم");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة");

            migrationBuilder.DropColumn(
                name: "رقم",
                table: "خزنة");

            migrationBuilder.AddPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة",
                column: "دائن");
        }
    }
}
