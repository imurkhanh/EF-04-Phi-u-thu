using EF_04.Entity;
using EF_04.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Services
{
    public class PhieuThuService : IPhieuThuService
    {
        private readonly AppDbContext dbContext;
        public PhieuThuService()
        {
            dbContext = new AppDbContext();
        }
        public void HienThiPhieuThuTheoThoiGian()
        {
            var phieuThuList = dbContext.PhieuThu.OrderByDescending(x=>x.NgayLap).ToList();
            foreach(var temp in phieuThuList)
            {
                Console.WriteLine(temp);
            }
            var phieuThuSanPham = dbContext.PhieuThu
                                   .Join(dbContext.ChiTietPhieuThu, pt => pt.PhieuThuId, ctpt => ctpt.PhieuThuId, (pt, ctpt) => new { PhieuThu = pt, ChiTietPhieuThu = ctpt })
                                   .Join(dbContext.NguyenLieu, ctpt => ctpt.ChiTietPhieuThu.NguyenLieuId, nl => nl.NguyenLieuId, (ctpt, nl) => new { ChiTietPhieuThu = ctpt, NguyenLieu = nl })
                                   .Select(x =>new { x.NguyenLieu.TenNguyenLieu, x.ChiTietPhieuThu.ChiTietPhieuThu.SoLuongBan });
            foreach(var temp in phieuThuSanPham)
            {
                Console.WriteLine(temp);
            }    
                                   
        }
        public void ThemPhieuThu()
        {
            Console.WriteLine("Ngày lập: ");
            DateTime ngayLap = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhân viên lập: ");
            string nhanVienLap = Console.ReadLine();
            Console.WriteLine("Ghi chú: ");
            string ghiChu = Console.ReadLine();
            Console.WriteLine("Thành tiền: ");
            int thanhTien = int.Parse(Console.ReadLine());
            var phieuThu = new PhieuThu
            {
                NgayLap = ngayLap,
                NhanVienLap = nhanVienLap,
                GhiChu = ghiChu,
                ThanhTien = thanhTien,
            };
            dbContext.Add(phieuThu);
            dbContext.SaveChanges();
            Console.WriteLine("Thêm phiếu thu thành công");
        }

        public void XoaPhieuThu()
        {
            Console.WriteLine("Nhập phiếu thu ID: ");
            int phieuThuId = int.Parse(Console.ReadLine());
            var phieuThuDelete = dbContext.PhieuThu.Find(phieuThuId);
            if(phieuThuDelete != null)
            {
                dbContext.Remove(phieuThuDelete);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Không có phiếu thu cần xóa");
            }
        }
    }
}
