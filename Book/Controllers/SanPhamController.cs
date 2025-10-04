using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Book.Models;
using System.Data;

namespace Book.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly Database db;

        public SanPhamController(Database database)
        {
            db = database;
        }

        public IActionResult TheoLoai(int id)
        {
            string sql = $"SELECT * FROM SanPham WHERE MaLoai = {id}";
            DataTable dt = db.LayDuLieu(sql);
            return View(dt);
        }

        public IActionResult ChiTiet(int id)
        {
            string sql = $"SELECT * FROM SanPham WHERE MaSP = {id}";
            DataTable dt = db.LayDuLieu(sql);
            return View(dt);
        }
    }
}
