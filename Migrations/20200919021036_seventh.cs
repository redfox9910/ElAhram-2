using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "دائن",
                table: "يوميات");

            migrationBuilder.DropColumn(
                name: "مدين",
                table: "يوميات");

            migrationBuilder.DropColumn(
                name: "type",
                table: "حالات_يوميات");

            migrationBuilder.AddColumn<DateTime>(
                name: "تاريخ",
                table: "يوميات",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "مبلغ",
                table: "يوميات",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "حساب",
                table: "خزنة",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "شيكات",
                table: "خزنة",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "شيكات",
                columns: table => new
                {
                    رقم = table.Column<string>(nullable: false),
                    كودعميل = table.Column<int>(nullable: false),
                    قيمة = table.Column<decimal>(nullable: false),
                    تاريخ = table.Column<DateTime>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_شيكات", x => new { x.رقم, x.كودعميل });
                    table.ForeignKey(
                        name: "FK_شيكات_عملاء_كودعميل",
                        column: x => x.كودعميل,
                        principalTable: "عملاء",
                        principalColumn: "كودعميل",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_شيكات_كودعميل",
                table: "شيكات",
                column: "كودعميل");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "شيكات");

            migrationBuilder.DropColumn(
                name: "تاريخ",
                table: "يوميات");

            migrationBuilder.DropColumn(
                name: "مبلغ",
                table: "يوميات");

            migrationBuilder.DropColumn(
                name: "حساب",
                table: "خزنة");

            migrationBuilder.DropColumn(
                name: "شيكات",
                table: "خزنة");

            migrationBuilder.AddColumn<decimal>(
                name: "دائن",
                table: "يوميات",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "مدين",
                table: "يوميات",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "حالات_يوميات",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
