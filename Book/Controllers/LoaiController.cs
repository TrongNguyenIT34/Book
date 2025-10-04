using Microsoft.AspNetCore.Mvc;
using System.Data;
using Book.Models;

namespace Book.Controllers
{
    public class LoaiController : Controller
    {
        private readonly Database db;

        public LoaiController(Database database)
        {
            db = database;
        }

        public IActionResult DanhMuc()
        {
            string sql = "SELECT * FROM Loai";
            DataTable dt = db.LayDuLieu(sql);
            return PartialView("_DanhMuc", dt);
        }
    }
}
