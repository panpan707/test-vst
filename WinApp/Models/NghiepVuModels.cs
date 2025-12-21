using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    
    // 2. CÁC DANH MỤC CON
    public partial class LoaiRung
    {
        public int? Id { get; set; }
        public string TenLoai { get; set; }
        public string MaLoai { get; set; }
    }

    public partial class ChuRung
    {
        public int? Id { get; set; }
        public string TenChuRung { get; set; }
        public string LoaiChuSoHuu { get; set; }
    }

    public partial class KyQuyHoach
    {
        public int? Id { get; set; }
        public string TenKy { get; set; }
        public bool? TrangThai { get; set; }
    }

    // 3. BIẾN ĐỘNG RỪNG
    public partial class BienDongRung
    {
        public int? Id { get; set; }
        public int? LoRungId { get; set; }
        public string LoaiBienDong { get; set; } // Cháy, Khai thác, Trồng mới...
        public DateTime? NgayBienDong { get; set; }
        public double? DienTichBienDong { get; set; }
        public string MoTaChiTiet { get; set; }
        public string NguoiCapNhat { get; set; }
    }

    // 4. ĐIỂM THIÊN TAI
    public partial class DiemThienTai
    {
        public int? Id { get; set; }
        public string TenDiem { get; set; }
        public string LoaiThienTai { get; set; }
        public string MucDo { get; set; }
        public double? ToaDoX { get; set; }
        public double? ToaDoY { get; set; }
        public string MoTa { get; set; }
        public int? DonViId { get; set; }
    }

    // 5. BÁO CÁO
    public partial class BaoCao
    {
        public int? Id { get; set; }
        public string TieuDe { get; set; }
        public DateTime? NgayBaoCao { get; set; }
        public string NoiDung { get; set; }
        public string NguoiBaoCao { get; set; }
        public string FileDinhKem { get; set; }
    }
}