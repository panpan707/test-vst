using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class LoRung
    {
        public int Id { get; set; }
        public string MaLo { get; set; }
        public string BanDo { get; set; }
        public double DienTich { get; set; }  // SQL Float -> C# Double
        public double? TruLuong { get; set; } // Cho phép null (dấu ?)
        public int? NamTrong { get; set; }    // Cho phép null

        // 2. Các thuộc tính chi tiết
        public string NguonGoc { get; set; }
        public string DieuKienLapDia { get; set; }
        public string TrangThaiSuDung { get; set; }

        // 3. Các khóa ngoại (Liên kết bảng)
        public int? DonViId { get; set; }
        public int? LoaiRungId { get; set; }
        public int? ChuRungId { get; set; }
        public int? GiongCayId { get; set; }
        public int? KyQuyHoachId { get; set; }
    }
}
