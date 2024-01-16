using EF_04.Entity;
using EF_04.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Services
{
    public class ChiTietPhieuThuService : IChiTietPhieuThuService
    {
        private readonly AppDbContext dbContext;
        public ChiTietPhieuThuService()
        {
            dbContext = new AppDbContext();
        }
        public void ThemChiTietPhieuThu()
        {
            Console.WriteLine("Nhập nguyên liệu ID: ");
            int nguyenLieuId = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập phiếu thu ID: ");
            int phieuThuId = int .Parse(Console.ReadLine());
            var nguyenLieu = dbContext.NguyenLieu.Find(nguyenLieuId);
            if( nguyenLieu == null )
            {
                return;
            }
            var phieuThu = dbContext.PhieuThu.Find(phieuThuId);
            if ( phieuThu == null )
            {
                return;
            }
            Console.WriteLine("Nhập số lượng bán: ");
            int soLuongBan = int.Parse(Console.ReadLine());
            var chiTietPhieuThu = new ChiTietPhieuThu
            {
                NguyenLieuId = nguyenLieuId,
                PhieuThuId = phieuThuId,
                SoLuongBan = soLuongBan,
            };
            dbContext.Add(chiTietPhieuThu);
            dbContext.SaveChanges();
            nguyenLieu.SoLuongKho -= soLuongBan;
            dbContext.SaveChanges();
            Console.WriteLine("Thêm chi tiết phiếu thu thành công");
        }
    }
}
