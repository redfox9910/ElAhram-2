using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "flag",
                table: "شيكات",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "الحالة",
                table: "شيكات",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flag",
                table: "شيكات");

            migrationBuilder.DropColumn(
                name: "الحالة",
                table: "شيكات");
        }
    }
}
