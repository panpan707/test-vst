using Models;
using System;
using System.Mvc;
namespace WinApp.Controllers
{
    public partial class BaoCaoController : DataController<BaoCao>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class BienDongRungController : DataController<BienDongRung>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class ChuRungController : DataController<ChuRung>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class DiemThienTaiController : DataController<DiemThienTai>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class DonViController : DataController<DonVi>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class FileDinhKemController : DataController<FileDinhKem>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class GiongCayController : DataController<GiongCay>
    {
    }
}



namespace WinApp.Controllers
{
    public partial class HoSoController : DataController<HoSo>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class KyQuyHoachController : DataController<KyQuyHoach>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class LichSuTacDongController : DataController<LichSuTacDong>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class LichSuTruyCapController : DataController<LichSuTruyCap>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class LoaiRungController : DataController<LoaiRung>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class LoRungController : DataController<LoRung>
    {
        protected override string GetSearchCondition(string keyword)
        {
            return $"MaLo LIKE N'%{keyword}%' OR NguonGoc LIKE N'%{keyword}%' OR DieuKienLapDia LIKE N'%{keyword}%'";
        }
    }
}
namespace WinApp.Controllers
{
    public partial class QuyenController : DataController<Quyen>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class TenHanhChinhController : DataController<TenHanhChinh>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class ViewDonViController : DataController<ViewDonVi>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class ViewHoSoController : DataController<ViewHoSo>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class ThuocTinhLoDatController : DataController<ThuocTinhLoDat>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class BanDoQuyHoachController : DataController<BanDoQuyHoach>
    {
    }
}

namespace WinApp.Controllers
{
    public partial class BaoCaoQuyHoachController : DataController<BaoCaoQuyHoach>
    {
    }
}

