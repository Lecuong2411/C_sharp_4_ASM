using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class QLSVContext : DbContext
    {
        public QLSVContext() { }
        public QLSVContext(DbContextOptions<QLSVContext> options) : base(options) { }
        public DbSet<SinhVien> sinhViens { get; set; }
        public DbSet<Love> loves { get; set; }
    }
}
