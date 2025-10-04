namespace Book.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; } = string.Empty;
        public int MaLoai { get; set; }
        public int MaNSX { get; set; }
        public decimal Gia { get; set; }
        public string GhiChu { get; set; } = string.Empty;
        public string Hinh { get; set; } = string.Empty;
    }
}
