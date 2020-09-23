using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج",
                table: "بنودفاتورة");

            migrationBuilder.DropPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات");

            migrationBuilder.DropPrimaryKey(
                name: "PK_امرتشغيل",
                table: "امرتشغيل");

            migrationBuilder.AddColumn<double>(
                name: "الاجمالى",
                table: "بنودفاتورة",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "سعر_الوحدة",
                table: "بنودفاتورة",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات",
                columns: new[] { "كودالخامة", "type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_امرتشغيل",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "رقم", "نوع_فاتورة" });

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "نوع_فاتورة" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "كودالمنتج", "نوع_فاتورة" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالمنتج_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropPrimaryKey(
                name: "PK_امرتشغيل",
                table: "امرتشغيل");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_كودالخامة_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "الاجمالى",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "سعر_الوحدة",
                table: "بنودفاتورة");

            migrationBuilder.AddPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات",
                column: "كودالخامة");

            migrationBuilder.AddPrimaryKey(
                name: "PK_امرتشغيل",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "رقم" });

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة",
                table: "امرتشغيل",
                column: "كودالخامة",
                principalTable: "منتجات",
                principalColumn: "كودالخامة",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالمنتج",
                table: "بنودفاتورة",
                column: "كودالمنتج",
                principalTable: "منتجات",
                principalColumn: "كودالخامة",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
