using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class fiveth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "امرتشغيل",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_كودالخامة_type",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "type" });

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_type",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_type",
                table: "امرتشغيل");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_كودالخامة_type",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "type",
                table: "امرتشغيل");

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "نوع_فاتورة" });

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "نوع_فاتورة" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
