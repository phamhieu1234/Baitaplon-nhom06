﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapLonNhom06.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221125110524_GiaPhong")]
    partial class GiaPhong
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
#pragma warning restore 612, 618
        }
    }
}
