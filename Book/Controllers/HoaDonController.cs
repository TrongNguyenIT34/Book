using Book.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Book.Models;
using System.Data;

namespace Book.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly Database db;

        public HoaDonController(Database database)
        {
            db = database;
        }

        public IActionResult LichSu()
        {
            var maKH = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(maKH))
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            string sql = $@"
                SELECT hd.MaHoaDon, hd.NgayTao, sp.TenSP, sp.Gia, ct.SoLuong
                FROM HoaDon hd
                JOIN ChiTiet ct ON hd.MaHoaDon = ct.MaHD
                JOIN SanPham sp ON sp.MaSP = ct.MaSP
                WHERE hd.MaKH = {maKH}
                ORDER BY hd.MaHoaDon DESC";


            DataTable dt = db.LayDuLieu(sql);
            return View(dt);
        }
    }
}
