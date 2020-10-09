using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "اذن_صرف",
                columns: table => new
                {
                    كود = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    كودالخامة = table.Column<int>(nullable: false),
                    كودالمخزن = table.Column<int>(nullable: false),
                    الكمية = table.Column<double>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true),
                    تاريخ = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_اذن_صرف", x => x.كود);
                });

            migrationBuilder.CreateTable(
                name: "انواع_خامات",
                columns: table => new
                {
                    كودالنوع = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    النوع = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_انواع_خامات", x => x.كودالنوع);
                });

            migrationBuilder.CreateTable(
                name: "حالات_يوميات",
                columns: table => new
                {
                    كودحالة = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    حالة = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_حالات_يوميات", x => x.كودحالة);
                });

            migrationBuilder.CreateTable(
                name: "خزنة",
                columns: table => new
                {
                    رقم = table.Column<string>(nullable: false),
                    دائن = table.Column<decimal>(nullable: false),
                    مدين = table.Column<decimal>(nullable: false),
                    اجمالى = table.Column<decimal>(nullable: false),
                    نقدى = table.Column<decimal>(nullable: false),
                    شيكات = table.Column<decimal>(nullable: false),
                    حساب = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_خزنة", x => x.رقم);
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
                name: "مخزن",
                columns: table => new
                {
                    كودالمخزن = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    المخزن = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_مخزن", x => x.كودالمخزن);
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
                    اجمالى = table.Column<decimal>(nullable: false),
                    مطبوع = table.Column<decimal>(nullable: false),
                    سادة = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_هالك", x => new { x.سنة, x.شهر });
                });

            migrationBuilder.CreateTable(
                name: "يوميات",
                columns: table => new
                {
                    كود = table.Column<int>(nullable: false),
                    تاريخ = table.Column<DateTime>(nullable: false),
                    مبلغ = table.Column<decimal>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true),
                    كودصاحب = table.Column<int>(nullable: false),
                    كودحالة = table.Column<int>(nullable: false),
                    flag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_يوميات", x => new { x.كود, x.تاريخ });
                    table.ForeignKey(
                        name: "FK_يوميات_حالات_يوميات_كودحالة",
                        column: x => x.كودحالة,
                        principalTable: "حالات_يوميات",
                        principalColumn: "كودحالة",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "شيكات",
                columns: table => new
                {
                    رقم = table.Column<string>(nullable: false),
                    كودعميل = table.Column<int>(nullable: false),
                    قيمة = table.Column<decimal>(nullable: false),
                    تاريخ = table.Column<DateTime>(nullable: false),
                    ملاحظات = table.Column<string>(nullable: true),
                    بنك = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "فواتير",
                columns: table => new
                {
                    رقم = table.Column<int>(nullable: false),
                    نوع_فاتورة = table.Column<string>(nullable: false),
                    كودعميل = table.Column<int>(nullable: false),
                    تاريخ_تسليم = table.Column<DateTime>(nullable: false),
                    تاريخ_تشغيل = table.Column<DateTime>(nullable: false),
                    اجمالى_نقدى = table.Column<decimal>(nullable: false),
                    اجمالى_وزن = table.Column<double>(nullable: false),
                    اجمالى_حساب = table.Column<decimal>(nullable: false),
                    فاتورة = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_فواتير", x => new { x.رقم, x.نوع_فاتورة });
                    table.ForeignKey(
                        name: "FK_فواتير_عملاء_كودعميل",
                        column: x => x.كودعميل,
                        principalTable: "عملاء",
                        principalColumn: "كودعميل",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "منتجات",
                columns: table => new
                {
                    كودالخامة = table.Column<int>(nullable: false),
                    كودالمخزن = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(nullable: false),
                    كودالنوع = table.Column<int>(nullable: false),
                    الخامة = table.Column<string>(nullable: true),
                    الكمية = table.Column<double>(nullable: false),
                    وحدة = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_منتجات", x => new { x.كودالخامة, x.كودالمخزن, x.type });
                    table.ForeignKey(
                        name: "FK_منتجات_مخزن_كودالمخزن",
                        column: x => x.كودالمخزن,
                        principalTable: "مخزن",
                        principalColumn: "كودالمخزن",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_منتجات_انواع_خامات_كودالنوع",
                        column: x => x.كودالنوع,
                        principalTable: "انواع_خامات",
                        principalColumn: "كودالنوع",
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
                    ملاحظات = table.Column<string>(nullable: true),
                    غياب = table.Column<bool>(nullable: false)
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
                    نوع_فاتورة = table.Column<string>(nullable: false),
                    كودالمخزن = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(nullable: false),
                    كمية = table.Column<double>(nullable: false),
                    سمك = table.Column<string>(nullable: true),
                    مقاس_طباعة = table.Column<string>(nullable: true),
                    مقاس_تقطيع = table.Column<string>(nullable: true),
                    كميةخامة = table.Column<string>(nullable: true),
                    بيور = table.Column<bool>(nullable: false),
                    اوميا = table.Column<bool>(nullable: false),
                    كودالمخزن0 = table.Column<int>(name: "كود المخزن", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_امرتشغيل", x => new { x.كودالخامة, x.رقم, x.نوع_فاتورة });
                    table.ForeignKey(
                        name: "FK_امرتشغيل_فواتير_رقم_نوع_فاتورة",
                        columns: x => new { x.رقم, x.نوع_فاتورة },
                        principalTable: "فواتير",
                        principalColumns: new[] { "رقم", "نوع_فاتورة" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_امرتشغيل_منتجات_كودالخامة_كود المخزن_type",
                        columns: x => new { x.كودالخامة, x.كودالمخزن0, x.type },
                        principalTable: "منتجات",
                        principalColumns: new[] { "كودالخامة", "كودالمخزن", "type" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "بنودفاتورة",
                columns: table => new
                {
                    number = table.Column<int>(nullable: false),
                    رقم = table.Column<int>(nullable: false),
                    كودالمنتج = table.Column<int>(nullable: false),
                    نوع_فاتورة = table.Column<string>(nullable: false),
                    كمية = table.Column<double>(nullable: false),
                    كودالمخزن = table.Column<int>(type: "int", nullable: false),
                    سعر_الوحدة = table.Column<double>(nullable: false),
                    الاجمالى = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    كودالخامة = table.Column<int>(nullable: true),
                    كودالمخزن0 = table.Column<int>(name: "كود المخزن", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_بنودفاتورة", x => new { x.number, x.رقم });
                    table.ForeignKey(
                        name: "FK_بنودفاتورة_فواتير_رقم_نوع_فاتورة",
                        columns: x => new { x.رقم, x.نوع_فاتورة },
                        principalTable: "فواتير",
                        principalColumns: new[] { "رقم", "نوع_فاتورة" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_بنودفاتورة_منتجات_كودالخامة_كود المخزن_type",
                        columns: x => new { x.كودالخامة, x.كودالمخزن0, x.type },
                        principalTable: "منتجات",
                        principalColumns: new[] { "كودالخامة", "كودالمخزن", "type" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_رقم_نوع_فاتورة",
                table: "امرتشغيل",
                columns: new[] { "رقم", "نوع_فاتورة" });

            migrationBuilder.CreateIndex(
                name: "IX_امرتشغيل_كودالخامة_كود المخزن_type",
                table: "امرتشغيل",
                columns: new[] { "كودالخامة", "كود المخزن", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_رقم_نوع_فاتورة",
                table: "بنودفاتورة",
                columns: new[] { "رقم", "نوع_فاتورة" });

            migrationBuilder.CreateIndex(
                name: "IX_بنودفاتورة_كودالخامة_كود المخزن_type",
                table: "بنودفاتورة",
                columns: new[] { "كودالخامة", "كود المخزن", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_حسابات_الموظف_كودموظف",
                table: "حسابات_الموظف",
                column: "كودموظف");

            migrationBuilder.CreateIndex(
                name: "IX_شيكات_كودعميل",
                table: "شيكات",
                column: "كودعميل");

            migrationBuilder.CreateIndex(
                name: "IX_فواتير_كودعميل",
                table: "فواتير",
                column: "كودعميل");

            migrationBuilder.CreateIndex(
                name: "IX_منتجات_كودالمخزن",
                table: "منتجات",
                column: "كودالمخزن");

            migrationBuilder.CreateIndex(
                name: "IX_منتجات_كودالنوع",
                table: "منتجات",
                column: "كودالنوع");

            migrationBuilder.CreateIndex(
                name: "IX_يوميات_كودحالة",
                table: "يوميات",
                column: "كودحالة");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "اذن_صرف");

            migrationBuilder.DropTable(
                name: "امرتشغيل");

            migrationBuilder.DropTable(
                name: "بنودفاتورة");

            migrationBuilder.DropTable(
                name: "حسابات_الموظف");

            migrationBuilder.DropTable(
                name: "خزنة");

            migrationBuilder.DropTable(
                name: "شيكات");

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

            migrationBuilder.DropTable(
                name: "مخزن");

            migrationBuilder.DropTable(
                name: "انواع_خامات");
        }
    }
}
