using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Entity
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieu { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<PhieuThu> PhieuThu { get; set; }
        public virtual DbSet<ChiTietPhieuThu> ChiTietPhieuThu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V5E7153\\SQLEXPRESS;Database=EF_04;Trusted_Connection = True;TrustServerCertificate=True");
        }
    }
}
