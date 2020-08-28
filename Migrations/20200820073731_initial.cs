using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "حالات_يوميات",
                columns: table => new
                {
                    كودحالة = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    حالة = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_حالات_يوميات", x => x.كودحالة);
                });

            migrationBuilder.CreateTable(
                name: "خزنة",
                columns: table => new
                {
                    دائن = table.Column<decimal>(nullable: false),
                    مدين = table.Column<decimal>(nullable: false),
                    اجمالى = table.Column<decimal>(nullable: false),
                    نقدى = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "عملاء",
                columns: table => new
                {
                    كودعميل = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم = table.Column<string>(nullable: true),
                    رقم = table.Column<string>(nullable: true),
                    عنوان = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    حساب = table.Column<decimal>(nullable: false),
                    نوع = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_عملاء", x => x.كودعميل);
                });

            migrationBuilder.CreateTable(
                name: "منتجات",
                columns: table => new
                {
                    كودالخامة = table.Column<int>(nullable: false),
                    الخامة = table.Column<string>(nullable: true),
                    الكمية = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_منتجات", x => x.كودالخامة);
                });

            migrationBuilder.CreateTable(
                name: "موظف",
                columns: table => new
                {
                    كودموظف = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    اسم = table.Column<string>(nullable: true),
                    رقم = table.Column<string>(nullable: true),
                    بطاقة = table.Column<string>(nullable: true),
                    عنوان = table.Column<string>(nullable: true),
                    رقم_قومى = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_موظف", x => x.كودموظف);
                });

            migrationBuilder.CreateTable(
                name: "هالك",
                columns: table => new
                {
                    شهر = table.Column<int>(nullable: false),
                    سنة = table.Column<int>(nullable: false),
                    كمية = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_هالك", x => new { x.سنة, x.شهر });
                });

            migrationBuilder.CreateTable(
                name: "يوميات",
                columns: table => new
                {
                    كود = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    مدين = table.Column<decimal>(nullable: false),
                    دائن = table.Column<decimal>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true),
                    كودصاحب = table.Column<int>(nullable: false),
                    كودحالة = table.Column<int>(nullable: false),
                    flag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_يوميات", x => x.كود);
                    table.ForeignKey(
                        name: "FK_يوميات_حالات_يوميات_كودحالة",
                        column: x => x.كودحالة,
                        principalTable: "حالات_يوميات",
                        principalColumn: "كودحالة",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "فواتير",
                columns: table => new
                {
                    رقم = table.Column<int>(nullable: false),
                    كودعميل = table.Column<int>(nullable: false),
                    تاريخ_تسليم = table.Column<DateTime>(nullable: false),
                    تاريخ_استلام = table.Column<DateTime>(nullable: false),
                    نوع_فاتورة = table.Column<string>(nullable: false),
                    اجمالى_نقدى = table.Column<decimal>(nullable: false),
                    اجمالى_وزن = table.Column<double>(nullable: false),
                    اجمالى_حساب = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_فواتير", x => x.رقم);
                    table.ForeignKey(
                        name: "FK_فواتير_عملاء_كودعميل",
                        column: x => x.كودعميل,
                        principalTable: "عملاء",
                        principalColumn: "كودعميل",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "حسابات_الموظف",
                columns: table => new
                {
                    تاريخ = table.Column<DateTime>(nullable: false),
                    كودموظف = table.Column<int>(nullable: false),
                    ساعةحضور = table.Column<int>(nullable: false),
                    دقيقةحضور = table.Column<int>(nullable: false),
                    ساعةانصراف = table.Column<int>(nullable: false),
                    دقيقةانصراف = table.Column<int>(nullable: false),
                    سلف = table.Column<decimal>(nullable: false),
                    غياب = table.Column<bool>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_حسابات_الموظف", x => new { x.تاريخ, x.كودموظف });
                    table.ForeignKey(
                        name: "FK_حسابات_الموظف_موظف_كودموظف",
                        column: x => x.كودموظف,
                        principalTable: "موظف",
                        principalColumn: "كودموظف",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "امرتشغيل",
                columns: table => new
                {
                    كودالخامة = table.Column<int>(nullable: false),
                    رقم = table.Column<int>(nullable: false),
                    كمية = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_امرتشغيل", x => new { x.كودالخامة, x.رقم });
                    table.ForeignKey(
                        name: "FK_امرتشغيل_فواتير_رقم",
                        column: x => x.رقم,
                        principalTable: "فواتير",
                        principalColumn: "رقم",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_امرتشغيل_منتجات_كودالخامة",
                        column: x => x.كودالخامة,
                        principalTable: "منتجات",
                        principalColumn: "كودالخامة",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "بنودفاتورة",
                columns: table => new
                {
                    كودالمنتج = table.Column<int>(nullable: false),
                    رقم = table.Column<int>(nullable: false),
                    كمية = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_بنودفاتورة", x => new { x.كودالمنتج, x.رقم });
                    table.ForeignKey(
                        name: "FK_بنودفاتورة_فواتير_رقم",
                        column: x => x.رقم,
                        principalTable: "فواتير",
                        principalColumn: "رقم",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_بنودفاتورة_منتجات_كودالمنتج",
                        column: x => x.كودالمنتج,
                        principalTable: "منتجات",
                        principalColumn: "كودالخامة",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_رقم",
                table: "امرتشغيل",
                column: "رقم");

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_رقم",
                table: "بنودفاتورة",
                column: "رقم");

            migrationBuilder.CreateIndex(
                name: "IX_حسابات_الموظف_كودموظف",
                table: "حسابات_الموظف",
                column: "كودموظف");

            migrationBuilder.CreateIndex(
                name: "IX_فواتير_كودعميل",
                table: "فواتير",
                column: "كودعميل");

            migrationBuilder.CreateIndex(
                name: "IX_يوميات_كودحالة",
                table: "يوميات",
                column: "كودحالة");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "امرتشغيل");

            migrationBuilder.DropTable(
                name: "بنودفاتورة");

            migrationBuilder.DropTable(
                name: "حسابات_الموظف");

            migrationBuilder.DropTable(
                name: "خزنة");

            migrationBuilder.DropTable(
                name: "هالك");

            migrationBuilder.DropTable(
                name: "يوميات");

            migrationBuilder.DropTable(
                name: "فواتير");

            migrationBuilder.DropTable(
                name: "منتجات");

            migrationBuilder.DropTable(
                name: "موظف");

            migrationBuilder.DropTable(
                name: "حالات_يوميات");

            migrationBuilder.DropTable(
                name: "عملاء");
        }
    }
}
