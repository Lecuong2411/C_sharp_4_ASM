using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class QLBHContext : DbContext
    {
        public QLBHContext() { }
        public QLBHContext(DbContextOptions<QLBHContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GioHang_ChiTiet>().HasKey(table => new {
                table.MaGioHang,
                table.MaSanPham
            });
        }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<DanhMuc> danhMucs { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<GioHang_ChiTiet> gioHang_ChiTiets { get; set; }

    }
}
