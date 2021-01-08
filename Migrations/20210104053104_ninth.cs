using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "حساب",
                table: "يوميات",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "خزنة",
                table: "يوميات",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropColumn(
                name: "حساب",
                table: "يوميات");

            migrationBuilder.DropColumn(
                name: "خزنة",
                table: "يوميات");
        }
    }
}
