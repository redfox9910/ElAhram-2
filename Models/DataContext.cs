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

                DataSource = @"3ZMY",
                InitialCatalog = "alahram",
                IntegratedSecurity = true,

            };
            optionsBuilder.UseSqlServer(ConnString.ToString());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<المنتجات>().HasKey(c => new { c.كودالخامة ,c.كودالمخزن,c.type});
            modelBuilder.Entity<امرتشغيل>().HasKey(c => new { c.كودالخامة, c.رقم,c.نوع_فاتورة });
            modelBuilder.Entity<بنود_الفاتورة>().HasKey(c => new { c.كودالمنتج, c.رقم });
            modelBuilder.Entity<حالات_اليوميات>().HasKey(c => new { c.كودحالة });
            modelBuilder.Entity<حسابات_موظف>().HasKey(c => new { c.تاريخ, c.كودموظف });
            modelBuilder.Entity<عميل>().HasKey(c => new { c.كودعميل });
            modelBuilder.Entity<فواتير>().HasKey(c => new { c.رقم , c.نوع_فاتورة });
            modelBuilder.Entity<موظف>().HasKey(c => new { c.كودموظف});
            modelBuilder.Entity<هالك>().HasKey(c => new { c.سنة, c.شهر });
            modelBuilder.Entity<يوميات>().HasKey(c => new { c.كود });
            modelBuilder.Entity<شيكات>().HasKey(c => new { c.رقم , c.كودعميل});

            modelBuilder.Entity<الخزنة>().HasKey(c => new { c.رقم });
            modelBuilder.Entity<انواع_الخامات>().HasKey(c => new { c.كودالنوع });
            modelBuilder.Entity<مخازن>().HasKey(c => new { c.كودالمخزن });
            

          
            base.OnModelCreating(modelBuilder);


        }
       
        
        public DbSet<الخزنة> خزنة { get; set; }
        public DbSet<المنتجات> منتجات { get; set; }
        public DbSet<امرتشغيل> امرتشغيل { get; set; }
        public DbSet<انواع_الخامات> انواع_خامات { get; set; }
        // public DbSet<امرشراء> امرشراء { get; set; }
        //public DbSet<ايام> ايام { get; set; }
        public DbSet<بنود_الفاتورة> بنودفاتورة{ get; set; }
        public DbSet<حالات_اليوميات> حالات_يوميات{ get; set; }
        public DbSet<حسابات_موظف> حسابات_الموظف { get; set; }
        public DbSet<عميل> عملاء { get; set; }
      //  public DbSet<فاتورةبيع> فاتورةبيع { get; set; }
        public DbSet<فواتير> فواتير { get; set; }
        public DbSet<مخازن> مخزن { get; set; }
        public DbSet<موظف> موظف{ get; set; }
        public DbSet<هالك> هالك{ get; set; }
        public DbSet<يوميات> يوميات{ get; set; }
        public DbSet<شيكات> شيكات{ get; set; }
      
    }

}
