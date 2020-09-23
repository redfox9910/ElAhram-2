using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_فواتير_رقم",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_فواتير_رقم",
                table: "بنودفاتورة");

            migrationBuilder.DropPrimaryKey(
                name: "PK_فواتير",
                table: "فواتير");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_رقم",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_رقم",
                table: "امرتشغيل");

            migrationBuilder.AddColumn<string>(
                name: "نوع_فاتورة",
                table: "بنودفاتورة",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "نوع_فاتورة",
                table: "امرتشغيل",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_فواتير",
                table: "فواتير",
                columns: new[] { "رقم", "نوع_فاتورة" });

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_رقم_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "رقم", "نوع_فاتورة" });

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_رقم_نوع_فاتورة",
                table: "امرتشغيل",
                columns: new[] { "رقم", "نوع_فاتورة" });

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_فواتير_رقم_نوع_فاتورة",
                table: "امرتشغيل",
                columns: new[] { "رقم", "نوع_فاتورة" },
                principalTable: "فواتير",
                principalColumns: new[] { "رقم", "نوع_فاتورة" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_فواتير_رقم_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "رقم", "نوع_فاتورة" },
                principalTable: "فواتير",
                principalColumns: new[] { "رقم", "نوع_فاتورة" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_امرتشغيل_فواتير_رقم_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.DropForeignKey(
                name: "FK_بنودفاتورة_فواتير_رقم_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropPrimaryKey(
                name: "PK_فواتير",
                table: "فواتير");

            migrationBuilder.DropIndex(
                name: "IX_بنودفاتورة_رقم_نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropIndex(
                name: "IX_امرتشغيل_رقم_نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "نوع_فاتورة",
                table: "بنودفاتورة");

            migrationBuilder.DropColumn(
                name: "نوع_فاتورة",
                table: "امرتشغيل");

            migrationBuilder.AddPrimaryKey(
                name: "PK_فواتير",
                table: "فواتير",
                column: "رقم");

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_رقم",
                table: "بنودفاتورة",
                column: "رقم");

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_رقم",
                table: "امرتشغيل",
                column: "رقم");

            migrationBuilder.AddForeignKey(
                name: "FK_امرتشغيل_فواتير_رقم",
                table: "امرتشغيل",
                column: "رقم",
                principalTable: "فواتير",
                principalColumn: "رقم",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_بنودفاتورة_فواتير_رقم",
                table: "بنودفاتورة",
                column: "رقم",
                principalTable: "فواتير",
                principalColumn: "رقم",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
