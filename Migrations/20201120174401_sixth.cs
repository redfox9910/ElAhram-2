using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_type",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالخامة_type",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "كودالخامة",
                table: "بنودفاتورة");

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

            migrationBuilder.AddColumn<int>(
                name: "كودالخامة",
                table: "بنودفاتورة",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالخامة_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "type" });

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
