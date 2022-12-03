﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221125130555_Employee")]
    partial class Employee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("BaiTapLonNhom06.Models.Drinks", b =>
                {
                    b.Property<string>("MaDrinks")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenDrinks")
                        .HasColumnType("TEXT");

                    b.HasKey("MaDrinks");

                    b.ToTable("Drinks");
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

            modelBuilder.Entity("BaiTapLonNhom06.Models.Food", b =>
                {
                    b.Property<string>("MaFood")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenFood")
                        .HasColumnType("TEXT");

                    b.HasKey("MaFood");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("BaiTapLonNhom06.Models.GiaPhong", b =>
                {
                    b.Property<string>("MaGiaPhong")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGiaPhong")
                        .HasColumnType("TEXT");

                    b.HasKey("MaGiaPhong");

                    b.ToTable("GiaPhong");
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

            modelBuilder.Entity("BaiTapLonNhom06.Models.Haircuts", b =>
                {
                    b.Property<string>("MaHaircuts")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHaircuts")
                        .HasColumnType("TEXT");

                    b.HasKey("MaHaircuts");

                    b.ToTable("Haircuts");
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
