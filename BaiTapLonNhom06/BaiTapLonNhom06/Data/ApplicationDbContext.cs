using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiTapLonNhom06.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiTapLonNhom06.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BaiTapLonNhom06.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<BaiTapLonNhom06.Models.GiaPhong> GiaPhong { get; set; } = default!;


        public DbSet<BaiTapLonNhom06.Models.Client> Client { get; set; } = default!;

        public DbSet<BaiTapLonNhom06.Models.Employee> Employee { get; set; } = default!;

        public DbSet<BaiTapLonNhom06.Models.Room> Room { get; set; } = default!;

        public DbSet<BaiTapLonNhom06.Models.Service> Service { get; set; } = default!;




    
    }
