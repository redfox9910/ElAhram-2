using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "بنك",
                table: "شيكات",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة",
                column: "دائن");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_خزنة",
                table: "خزنة");

            migrationBuilder.DropColumn(
                name: "بنك",
                table: "شيكات");
        }
    }
}
