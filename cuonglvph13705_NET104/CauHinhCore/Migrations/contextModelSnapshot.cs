﻿// <auto-generated />
using System;
using CauHinhCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CauHinhCore.Migrations
{
    [DbContext(typeof(context))]
    partial class contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CauHinhCore.Models.Employee", b =>
                {
                    b.Property<string>("Employeecode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("chới tiệc")
                        .HasColumnName("TenNV");

                    b.Property<string>("phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("restaurantcode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("sex")
                        .HasColumnType("bit");

                    b.HasKey("Employeecode")
                        .HasName("MaNV");

                    b.HasIndex("restaurantcode");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("CauHinhCore.Models.Restaurant", b =>
                {
                    b.Property<string>("restaurantcode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sdt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("restaurantcode")
                        .HasName("MaCH");

                    b.ToTable("restaurants");
                });

            modelBuilder.Entity("CauHinhCore.Models.Employee", b =>
                {
                    b.HasOne("CauHinhCore.Models.Restaurant", "Restaurant")
                        .WithMany("Employee")
                        .HasForeignKey("restaurantcode")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CauHinhCore.Models.Restaurant", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
