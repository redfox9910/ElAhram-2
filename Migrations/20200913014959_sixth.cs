using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "بنودفاتورة",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالمنتج_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "type" });

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_type",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالمنتج_type",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "type",
                table: "بنودفاتورة");

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "نوع_فاتورة" });

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "نوع_فاتورة" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
