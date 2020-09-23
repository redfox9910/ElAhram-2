using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElAhram.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "كمية",
                table: "هالك");

            migrationBuilder.DropColumn(
                name: "تاريخ_استلام",
                table: "فواتير");

            migrationBuilder.AddColumn<decimal>(
                name: "سادة",
                table: "هالك",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "مطبوع",
                table: "هالك",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "وحدة",
                table: "منتجات",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "تاريخ_تشغيل",
                table: "فواتير",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "فاتورة",
                table: "فواتير",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "اوميا",
                table: "امرتشغيل",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "بيور",
                table: "امرتشغيل",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "سمك",
                table: "امرتشغيل",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "مقاس_تقطيع",
                table: "امرتشغيل",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "مقاس_طباعة",
                table: "امرتشغيل",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "سادة",
                table: "هالك");

            migrationBuilder.DropColumn(
                name: "مطبوع",
                table: "هالك");

            migrationBuilder.DropColumn(
                name: "وحدة",
                table: "منتجات");

            migrationBuilder.DropColumn(
                name: "تاريخ_تشغيل",
                table: "فواتير");

            migrationBuilder.DropColumn(
                name: "فاتورة",
                table: "فواتير");

            migrationBuilder.DropColumn(
                name: "اوميا",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "بيور",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "سمك",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "مقاس_تقطيع",
                table: "امرتشغيل");

            migrationBuilder.DropColumn(
                name: "مقاس_طباعة",
                table: "امرتشغيل");

            migrationBuilder.AddColumn<decimal>(
                name: "كمية",
                table: "هالك",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "تاريخ_استلام",
                table: "فواتير",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
