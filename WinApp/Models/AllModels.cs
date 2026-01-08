using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class BanDoQuyHoach
    {
        public int? Id { get; set; }
        public int? KyQuyHoachId { get; set; }
        public string TenBanDo { get; set; }
        public string LoaiBanDo { get; set; }
        public string TyLe { get; set; }
        public string DuLieuBanDo { get; set; }
        public string MoTa { get; set; }
    }
}
namespace Models
{
    public partial class BaoCaoQuyHoach
    {
        public int? Id { get; set; }
        public int? KyQuyHoachId { get; set; }
        public string TenBaoCao { get; set; }
        public string SoHieuVanBan { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string CoQuanBanHanh { get; set; }
        public string FileDinhKem { get; set; }
        public string MoTa { get; set; }
    }
}

namespace Models
{
    public partial class BaoCao
    {
        public int? Id { get; set; }
        public string TieuDe { get; set; }
        public DateTime? NgayBaoCao { get; set; }
        public string NoiDung { get; set; }
        public string FileDinhKem { get; set; }
        public string NguoiBaoCao { get; set; }
    }
}
namespace Models
{
    public partial class BienDongRung
    {
        public int? Id { get; set; }
        public int? LoRungId { get; set; }
        public DateTime? NgayBienDong { get; set; }
        public string LoaiBienDong { get; set; }
        public double? DienTichBienDong { get; set; }
        public double? TruLuongBienDong { get; set; }
        public string MoTaChiTiet { get; set; }
        public string FileDinhKem { get; set; }
        public string NguoiCapNhat { get; set; }
    }
}
namespace Models
{
    public partial class ChuRung
    {
        public int? Id { get; set; }
        public string TenChuRung { get; set; }
        public string LoaiChuSoHuu { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}
namespace Models
{
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
}
namespace Models
{
    public partial class DonVi
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public int? HanhChinhId { get; set; }
        public string TenHanhChinh { get; set; }
        public int? TrucThuocId { get; set; }
    }
}
namespace Models
{
    public partial class FileDinhKem
    {
        public int? Id { get; set; }
        public string TenFile { get; set; }
        public string DuongDan { get; set; }
        public string LoaiDoiTuong { get; set; }
        public int? IdDoiTuong { get; set; }
        public DateTime? NgayUpload { get; set; }
    }
}
namespace Models
{
    public partial class GiongCay
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public string Nguon { get; set; }
        public string DacTinh { get; set; }
        public string LoaiCay { get; set; }
    }
}
namespace Models
{
    public partial class HanhChinh
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public int? TrucThuocId { get; set; }
    }
}
namespace Models
{
    public partial class HoSo
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Ext { get; set; }
    }
}
namespace Models
{
    public partial class KyQuyHoach
    {
        public int? Id { get; set; }
        public string TenKy { get; set; }
        public int? TuNam { get; set; }
        public int? DenNam { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }
}
namespace Models
{
    public partial class LichSuTacDong
    {
        public int? Id { get; set; }
        public string NguoiThucHien { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string BangTacDong { get; set; }
        public int? IdBanGhi { get; set; }
        public string LoaiTacDong { get; set; }
        public string NoiDungThayDoi { get; set; }
    }
}
namespace Models
{
    public partial class LichSuTruyCap
    {
        public int? Id { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string HanhDong { get; set; }
        public string IPAddress { get; set; }
    }
}
namespace Models
{
    public partial class LoaiRung
    {
        public int? Id { get; set; }
        public string TenLoai { get; set; }
        public string MaLoai { get; set; }
        public string MoTa { get; set; }
    }
}
namespace Models
{
    public partial class LoRung
    {
        public int? Id { get; set; }
        public string MaLo { get; set; }
        public string TenLo { get; set; }
        public string BanDo { get; set; }
        public double? DienTich { get; set; }
        public double? TruLuong { get; set; }
        public int? NamTrong { get; set; }
        public string NguonGoc { get; set; }
        public string DieuKienLapDia { get; set; }
        public string TrangThaiSuDung { get; set; }
        public int? DonViId { get; set; }
        public int? LoaiRungId { get; set; }
        public int? ChuRungId { get; set; }
        public int? GiongCayId { get; set; }
        public int? KyQuyHoachId { get; set; }
        public int? DoDocId { get; set; }
        public int? DoCaoId { get; set; }
        public int? DoDayDatId { get; set; }
        public double? GiaTriDoDoc { get; set; }
        public double? GiaTriDoCao { get; set; }
    }
}

namespace Models
{
    public partial class Quyen
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public string Ext { get; set; }
    }
}
namespace Models
{
    public partial class TaiKhoan
    {
        public string Ten { get; set; }
        public string MatKhau { get; set; }
        public int? QuyenId { get; set; }
        public int? HoSoId { get; set; }
    }
}
namespace Models
{
    public partial class TenHanhChinh
    {
        public string Ten { get; set; }
    }
}
namespace Models
{
    public partial class ViewDonVi
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public int? HanhChinhId { get; set; }
        public string TenHanhChinh { get; set; }
        public int? TrucThuocId { get; set; }
        public string Cap { get; set; }
        public string TrucThuoc { get; set; }
    }
}
namespace Models
{
    public partial class ViewHoSo
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Ext { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int? QuyenId { get; set; }
        public string Quyen { get; set; }
    }
}
namespace Models
{
    public partial class ThuocTinhLoDat
    {
        public int? Id { get; set; }
        public string TenThuocTinh { get; set; }
        public string NhomThuocTinh { get; set; }
        public string MoTa { get; set; }
    }
}

