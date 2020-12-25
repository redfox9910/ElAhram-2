using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class firth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_كود المخزن_type",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_كود المخزن_type",
                table: "بنودفاتورة");

            migrationBuilder.DropForeignKey(
                name: "FK_منتجات_مخزن_كودالمخزن",
                table: "منتجات");

            migrationBuilder.DropForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات");

            migrationBuilder.DropTable(
                name: "مخزن");

            migrationBuilder.DropPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات");

            migrationBuilder.DropIndex(
                name: "IX_منتجات_كودالمخزن",
                table: "منتجات");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالخامة_كود المخزن_type",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_كودالخامة_كود المخزن_type",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "كودالمخزن",
                table: "منتجات");

            migrationBuilder.DropColumn(
                name: "كود المخزن",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "كودالمخزن",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "كود المخزن",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "كودالمخزن",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "كودالمخزن",
                table: "اذون_صرف");

            migrationBuilder.AddColumn<string>(
                name: "حالةالعمل",
                table: "موظف",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "كودالنوع",
                table: "منتجات",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات",
                columns: new[] { "كودالخامة", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالخامة_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "type" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات",
                column: "كودالنوع",
                principalTable: "انواع_خامات",
                principalColumn: "كودالنوع",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_type",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_type",
                table: "بنودفاتورة");

            migrationBuilder.DropForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات");

            migrationBuilder.DropPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_كودالخامة_type",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_كودالخامة_type",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "حالةالعمل",
                table: "موظف");

            migrationBuilder.AlterColumn<int>(
                name: "كودالنوع",
                table: "منتجات",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "كودالمخزن",
                table: "منتجات",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "كود المخزن",
                table: "بنودفاتورة",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "كودالمخزن",
                table: "بنودفاتورة",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "كود المخزن",
                table: "امرتشغيل",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "كودالمخزن",
                table: "امرتشغيل",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "كودالمخزن",
                table: "اذون_صرف",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_منتجات",
                table: "منتجات",
                columns: new[] { "كودالخامة", "كودالمخزن", "type" });

            migrationBuilder.CreateTable(
                name: "مخزن",
                columns: table => new
                {
                    كودالمخزن = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    المخزن = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_مخزن", x => x.كودالمخزن);
                });

            migrationBuilder.CreateIndex(
                name: "IX_منتجات_كودالمخزن",
                table: "منتجات",
                column: "كودالمخزن");

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالخامة_كود المخزن_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "كود المخزن", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_كودالخامة_كود المخزن_type",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "كود المخزن", "type" });

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_منتجات_كودالخامة_كود المخزن_type",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "كود المخزن", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "كودالمخزن", "type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_منتجات_كودالخامة_كود المخزن_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "كود المخزن", "type" },
                principalTable: "منتجات",
                principalColumns: new[] { "كودالخامة", "كودالمخزن", "type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_منتجات_مخزن_كودالمخزن",
                table: "منتجات",
                column: "كودالمخزن",
                principalTable: "مخزن",
                principalColumn: "كودالمخزن",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_منتجات_انواع_خامات_كودالنوع",
                table: "منتجات",
                column: "كودالنوع",
                principalTable: "انواع_خامات",
                principalColumn: "كودالنوع",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
