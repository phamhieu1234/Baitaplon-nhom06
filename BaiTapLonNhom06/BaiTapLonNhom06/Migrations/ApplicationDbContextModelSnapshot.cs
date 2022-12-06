﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BaiTapLonNhom06.Models.ChucVu", b =>
                {
                    b.Property<string>("MaChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("TEXT");

                    b.HasKey("MaChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Client", b =>
                {
                    b.Property<string>("KhachhangID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Ngayra")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Ngayvao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sophong")
                        .HasColumnType("TEXT");

                    b.Property<string>("SĐT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KhachhangID");

                    b.HasIndex("MaGioiTinh");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Employee", b =>
                {
                    b.Property<string>("MaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SĐT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaID");

                    b.HasIndex("MaChucVu");

                    b.HasIndex("MaGioiTinh");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.GioiTinh", b =>
                {
                    b.Property<string>("MaGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .HasColumnType("TEXT");

                    b.HasKey("MaGioiTinh");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Phong", b =>
                {
                    b.Property<string>("PhongID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CSVC")
                        .HasColumnType("TEXT");

                    b.Property<string>("TienPhong")
                        .HasColumnType("TEXT");

                    b.HasKey("PhongID");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Service", b =>
                {
                    b.Property<string>("ServiceID")
                        .HasColumnType("TEXT");

                    b.Property<string>("DrinkName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HaircutName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServicePrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Client", b =>
                {
                    b.HasOne("BaiTapLonNhom06.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.Employee", b =>
                {
                    b.HasOne("BaiTapLonNhom06.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("MaChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaiTapLonNhom06.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("GioiTinh");
                });
#pragma warning restore 612, 618
        }
    }
}
