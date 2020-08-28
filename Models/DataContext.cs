using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ElAhram.Models
{
    public class DataContext  : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DataContext()
        {
           // Database.SetInitializer<DataContext>(new System.Data.Entity.CreateDatabaseIfNotExists<DataContext>());
        }
        //public DataContext() : base("ConnectionStrings")
        //{
        //    Database.SetInitializer<DataContext>(new System.Data.Entity.CreateDatabaseIfNotExists<DataContext>());
        //}
        public static string ConString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string constring = config.GetConnectionString("ConnectionStrings");
            return constring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            SqlConnectionStringBuilder ConnString = new SqlConnectionStringBuilder()
            {

                DataSource = @"REDFOX\FOXEXPRESS",
                InitialCatalog = "alahram",
                IntegratedSecurity = true,

            };
            optionsBuilder.UseSqlServer(ConnString.ToString());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<المنتجات>().HasKey(c => new { c.كودالخامة });
            modelBuilder.Entity<امرتشغيل>().HasKey(c => new { c.كودالخامة, c.رقم });
            modelBuilder.Entity<بنود_الفاتورة>().HasKey(c => new { c.كودالمنتج, c.رقم });
            modelBuilder.Entity<حالات_اليوميات>().HasKey(c => new { c.كودحالة });
            modelBuilder.Entity<حسابات_موظف>().HasKey(c => new { c.تاريخ, c.كودموظف });
            modelBuilder.Entity<عميل>().HasKey(c => new { c.كودعميل });
            modelBuilder.Entity<فواتير>().HasKey(c => new { c.رقم });
            modelBuilder.Entity<موظف>().HasKey(c => new { c.كودموظف});
            modelBuilder.Entity<هالك>().HasKey(c => new { c.سنة, c.شهر });
            modelBuilder.Entity<يوميات>().HasKey(c => new { c.كود });

            modelBuilder.Entity<الخزنة>().HasNoKey();
            //modelBuilder.Entity<المنتجات>().HasNoKey();
            //modelBuilder.Entity<امرتشغيل>().HasNoKey();
            //modelBuilder.Entity<امرشراء>().HasNoKey();
            //modelBuilder.Entity<ايام>().HasNoKey();
            //modelBuilder.Entity<حسابات_موظف>().HasNoKey();
            //modelBuilder.Entity<عميل>().HasNoKey();
            //modelBuilder.Entity<فاتورةبيع>().HasNoKey();
            //modelBuilder.Entity<فواتير>().HasNoKey();
            //modelBuilder.Entity<مخزن>().HasNoKey();
            //modelBuilder.Entity<موظف>().HasNoKey();
            //modelBuilder.Entity<هالك>().HasNoKey();
            //modelBuilder.Entity<يوميات>().HasNoKey();

            //modelBuilder.Ignore<المنتجات>();
            //modelBuilder.Ignore<مخزن>();
            base.OnModelCreating(modelBuilder);


        }
       
        
        public DbSet<الخزنة> خزنة { get; set; }
        public DbSet<المنتجات> منتجات { get; set; }
        public DbSet<امرتشغيل> امرتشغيل { get; set; }
        // public DbSet<امرشراء> امرشراء { get; set; }
        //public DbSet<ايام> ايام { get; set; }
        public DbSet<بنود_الفاتورة> بنودفاتورة{ get; set; }
        public DbSet<حالات_اليوميات> حالات_يوميات{ get; set; }
        public DbSet<حسابات_موظف> حسابات_الموظف { get; set; }
        public DbSet<عميل> عملاء { get; set; }
      //  public DbSet<فاتورةبيع> فاتورةبيع { get; set; }
        public DbSet<فواتير> فواتير { get; set; }
       // public DbSet<مخزن> مخزن { get; set; }
        public DbSet<موظف> موظف{ get; set; }
        public DbSet<هالك> هالك{ get; set; }
        public DbSet<يوميات> يوميات{ get; set; }
    }

}
