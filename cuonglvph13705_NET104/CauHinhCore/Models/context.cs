using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CauHinhCore.Models;

namespace CauHinhCore.Models
{
    public class context : DbContext
    {
        public context(DbContextOptions<context>options):base (options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //cấu hình Khóa cính

            modelBuilder.Entity<Restaurant>().HasKey(p => p.restaurantcode).HasName("MaCH");
            modelBuilder.Entity<Employee>().HasKey(p => p.Employeecode).HasName("MaNV");

            //Cấu hình khóa ngoại
            modelBuilder.Entity<Employee>().HasOne<Restaurant>(p => p.Restaurant).WithMany(p => p.Employee).HasForeignKey(p => p.restaurantcode).OnDelete(DeleteBehavior.ClientCascade);
            // cấu hình thuộc tính
            modelBuilder.Entity<Employee>().Property(p => p.name).HasMaxLength(50).IsUnicode(true).HasColumnName("TenNV").HasDefaultValue("chới tiệc").IsRequired();
        }
    }
}
