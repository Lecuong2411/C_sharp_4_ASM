using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lab5_6.Models
{
    public partial class NETMVCContext : DbContext
    {
        public NETMVCContext()
        {
        }

        public NETMVCContext(DbContextOptions<NETMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HocSinh> HocSinhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-98PG69Q\\SQLEXPRESS;Database=NETMVC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.Msv)
                    .HasName("PK__HocSinh__DF50EFBA317D58CB");

                entity.ToTable("HocSinh");

                entity.Property(e => e.Msv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("msv")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength(true);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ten");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
