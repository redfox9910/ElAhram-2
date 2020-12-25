﻿// <auto-generated />
using System;
using ElAhram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElAhram.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201124200943_seventh")]
    partial class seventh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElAhram.Models.اذن_صرف", b =>
                {
                    b.Property<int>("كود")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("الكمية")
                        .HasColumnType("float");

                    b.Property<DateTime>("تاريخ")
                        .HasColumnType("datetime2");

                    b.Property<int>("كودالخامة")
                        .HasColumnType("int");

                    b.Property<string>("ملاحظات")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كود");

                    b.ToTable("اذون_صرف");
                });

            modelBuilder.Entity("ElAhram.Models.التحويلات_الداخلية", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("تاريخ")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("قيمة")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("نوع")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id");

                    b.ToTable("تحويلات");
                });

            modelBuilder.Entity("ElAhram.Models.الخزنة", b =>
                {
                    b.Property<string>("رقم")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("اجمالى")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("حساب")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("دائن")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("شيكات")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("مدين")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("نقدى")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("رقم");

                    b.ToTable("خزنة");
                });

            modelBuilder.Entity("ElAhram.Models.المنتجات", b =>
                {
                    b.Property<int>("كودالخامة")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("الخامة")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الكمية")
                        .HasColumnType("float");

                    b.Property<int?>("كودالنوع")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("وحدة")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("كودالخامة", "type");

                    b.HasIndex("كودالنوع");

                    b.ToTable("منتجات");
                });

            modelBuilder.Entity("ElAhram.Models.امرتشغيل", b =>
                {
                    b.Property<int>("كودالخامة")
                        .HasColumnType("int");

                    b.Property<int>("رقم")
                        .HasColumnType("int");

                    b.Property<string>("نوع_فاتورة")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("اوميا")
                        .HasColumnType("bit");

                    b.Property<bool>("بيور")
                        .HasColumnType("bit");

                    b.Property<string>("سمك")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("كمية")
                        .HasColumnType("float");

                    b.Property<string>("كميةخامة")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("مقاس_تقطيع")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("مقاس_طباعة")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كودالخامة", "رقم", "نوع_فاتورة");

                    b.HasIndex("رقم", "نوع_فاتورة");

                    b.HasIndex("كودالخامة", "type");

                    b.ToTable("امرتشغيل");
                });

            modelBuilder.Entity("ElAhram.Models.انواع_الخامات", b =>
                {
                    b.Property<int>("كودالنوع")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("النوع")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كودالنوع");

                    b.ToTable("انواع_خامات");
                });

            modelBuilder.Entity("ElAhram.Models.بنود_الفاتورة", b =>
                {
                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<int>("رقم")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("الاجمالى")
                        .HasColumnType("float");

                    b.Property<double>("سعر_الوحدة")
                        .HasColumnType("float");

                    b.Property<double>("كمية")
                        .HasColumnType("float");

                    b.Property<int>("كودالمنتج")
                        .HasColumnType("int");

                    b.Property<string>("نوع_فاتورة")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("number", "رقم");

                    b.HasIndex("رقم", "نوع_فاتورة");

                    b.HasIndex("كودالمنتج", "type");

                    b.ToTable("بنودفاتورة");
                });

            modelBuilder.Entity("ElAhram.Models.حالات_اليوميات", b =>
                {
                    b.Property<int>("كودحالة")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("حالة")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كودحالة");

                    b.ToTable("حالات_يوميات");
                });

            modelBuilder.Entity("ElAhram.Models.حسابات_موظف", b =>
                {
                    b.Property<DateTime>("تاريخ")
                        .HasColumnType("datetime2");

                    b.Property<int>("كودموظف")
                        .HasColumnType("int");

                    b.Property<int>("دقيقةانصراف")
                        .HasColumnType("int");

                    b.Property<int>("دقيقةحضور")
                        .HasColumnType("int");

                    b.Property<int>("ساعةانصراف")
                        .HasColumnType("int");

                    b.Property<int>("ساعةحضور")
                        .HasColumnType("int");

                    b.Property<decimal>("سلف")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("غياب")
                        .HasColumnType("bit");

                    b.Property<string>("ملاحظات")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("تاريخ", "كودموظف");

                    b.HasIndex("كودموظف");

                    b.ToTable("حسابات_الموظف");
                });

            modelBuilder.Entity("ElAhram.Models.شيكات", b =>
                {
                    b.Property<string>("رقم")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("كودعميل")
                        .HasColumnType("int");

                    b.Property<string>("بنك")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("تاريخ")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("قيمة")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ملاحظات")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم", "كودعميل");

                    b.HasIndex("كودعميل");

                    b.ToTable("شيكات");
                });

            modelBuilder.Entity("ElAhram.Models.عميل", b =>
                {
                    b.Property<int>("كودعميل")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("اسم")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("حساب")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("رقم")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("عنوان")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("نوع")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("كودعميل");

                    b.ToTable("عملاء");
                });

            modelBuilder.Entity("ElAhram.Models.فواتير", b =>
                {
                    b.Property<int>("رقم")
                        .HasColumnType("int");

                    b.Property<string>("نوع_فاتورة")
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("اجمالى_حساب")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("اجمالى_نقدى")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("اجمالى_وزن")
                        .HasColumnType("float");

                    b.Property<DateTime>("تاريخ_تسليم")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("تاريخ_تشغيل")
                        .HasColumnType("datetime2");

                    b.Property<string>("فاتورة")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("كودعميل")
                        .HasColumnType("int");

                    b.HasKey("رقم", "نوع_فاتورة");

                    b.HasIndex("كودعميل");

                    b.ToTable("فواتير");
                });

            modelBuilder.Entity("ElAhram.Models.موظف", b =>
                {
                    b.Property<int>("كودموظف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("اسم")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("بطاقة")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("حالةالعمل")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("رقم")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("رقم_قومى")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("عنوان")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كودموظف");

                    b.ToTable("موظف");
                });

            modelBuilder.Entity("ElAhram.Models.هالك", b =>
                {
                    b.Property<int>("سنة")
                        .HasColumnType("int");

                    b.Property<int>("شهر")
                        .HasColumnType("int");

                    b.Property<decimal>("اجمالى")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("سادة")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("مطبوع")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("سنة", "شهر");

                    b.ToTable("هالك");
                });

            modelBuilder.Entity("ElAhram.Models.يوميات", b =>
                {
                    b.Property<int>("كود")
                        .HasColumnType("int");

                    b.Property<DateTime>("تاريخ")
                        .HasColumnType("datetime2");

                    b.Property<string>("flag")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("كودحالة")
                        .HasColumnType("int");

                    b.Property<int>("كودصاحب")
                        .HasColumnType("int");

                    b.Property<decimal>("مبلغ")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ملاحظات")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("كود", "تاريخ");

                    b.HasIndex("كودحالة");

                    b.ToTable("يوميات");
                });

            modelBuilder.Entity("ElAhram.Models.المنتجات", b =>
                {
                    b.HasOne("ElAhram.Models.انواع_الخامات", "انواع")
                        .WithMany()
                        .HasForeignKey("كودالنوع")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.امرتشغيل", b =>
                {
                    b.HasOne("ElAhram.Models.فواتير", "فاتورة")
                        .WithMany()
                        .HasForeignKey("رقم", "نوع_فاتورة")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElAhram.Models.المنتجات", "منتج")
                        .WithMany()
                        .HasForeignKey("كودالخامة", "type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.بنود_الفاتورة", b =>
                {
                    b.HasOne("ElAhram.Models.فواتير", "فاتورة")
                        .WithMany()
                        .HasForeignKey("رقم", "نوع_فاتورة")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElAhram.Models.المنتجات", "منتج")
                        .WithMany()
                        .HasForeignKey("كودالمنتج", "type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.حسابات_موظف", b =>
                {
                    b.HasOne("ElAhram.Models.موظف", "موظف")
                        .WithMany()
                        .HasForeignKey("كودموظف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.شيكات", b =>
                {
                    b.HasOne("ElAhram.Models.عميل", "عميل")
                        .WithMany()
                        .HasForeignKey("كودعميل")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.فواتير", b =>
                {
                    b.HasOne("ElAhram.Models.عميل", "عميل")
                        .WithMany()
                        .HasForeignKey("كودعميل")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElAhram.Models.يوميات", b =>
                {
                    b.HasOne("ElAhram.Models.حالات_اليوميات", "حالة")
                        .WithMany()
                        .HasForeignKey("كودحالة")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
