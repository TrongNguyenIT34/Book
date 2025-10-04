using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Book.Models;
using System.Data;

namespace Book.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly Database db;

        public TaiKhoanController(Database database)
        {
            db = database;
        }

        public IActionResult DangNhap() => View();

        [HttpPost]
        public IActionResult DangNhap(string sdt, string mk)
        {
            string sql = $"SELECT * FROM KhachHang WHERE SoDienThoai='{sdt}' AND MatKhau='{mk}'";
            DataTable dt = db.LayDuLieu(sql);

            if (dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("MaKH", dt.Rows[0]["MaKH"].ToString());
                HttpContext.Session.SetString("TenKH", dt.Rows[0]["TenKhachHang"].ToString());
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ThongBao = "Sai thông tin đăng nhập!";
            return View();
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
