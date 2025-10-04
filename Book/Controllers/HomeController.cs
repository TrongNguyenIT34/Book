using Book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly Database db;

        public HomeController(Database _db)   
        {
            db = _db;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            string sql = "SELECT * FROM SanPham";
            DataTable dt = db.LayDuLieu(sql);
            return View(dt);
        }

        [HttpPost]
        public IActionResult TimKiem(decimal min, decimal max)
        {
            string sql = $"SELECT * FROM SanPham WHERE Gia BETWEEN {min} AND {max}";
            DataTable dt = db.LayDuLieu(sql);
            return View("Index", dt);
        }
    }
}
