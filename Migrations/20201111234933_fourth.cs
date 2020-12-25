using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات");

            migrationBuilder.DropPrimaryKey(
                name: "PK_اذن_صرف",
                table: "اذن_صرف");

            migrationBuilder.RenameTable(
                name: "اذن_صرف",
                newName: "اذون_صرف");

            migrationBuilder.AlterColumn<int>(
                name: "كودالنوع",
                table: "منتجات",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_اذون_صرف",
                table: "اذون_صرف",
                column: "كود");

            migrationBuilder.AddForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات",
                column: "كودالنوع",
                principalTable: "انواع_خامات",
                principalColumn: "كودالنوع",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات");

            migrationBuilder.DropPrimaryKey(
                name: "PK_اذون_صرف",
                table: "اذون_صرف");

            migrationBuilder.RenameTable(
                name: "اذون_صرف",
                newName: "اذن_صرف");

            migrationBuilder.AlterColumn<int>(
                name: "كودالنوع",
                table: "منتجات",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_اذن_صرف",
                table: "اذن_صرف",
                column: "كود");

            migrationBuilder.AddForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات",
                column: "كودالنوع",
                principalTable: "انواع_خامات",
                principalColumn: "كودالنوع",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
