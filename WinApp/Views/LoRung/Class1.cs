using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.LoRung
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of LoRung";
            context.TableColumns = new object[] {
                new TableColumn { Name = "MaLo", Caption = "MaLo Header", Width = 100, },
                new TableColumn { Name = "TenLo", Caption = "TenLo Header", Width = 100, },
                new TableColumn { Name = "ChuRungId", Caption = "Mã Chủ Rừng", Width = 100 },
                new TableColumn { Name = "BanDo", Caption = "BanDo Header", Width = 100, },
                new TableColumn { Name = "DienTich", Caption = "DienTich Header", Width = 100, },
                new TableColumn { Name = "TruLuong", Caption = "TruLuong Header", Width = 100, },
                new TableColumn { Name = "NamTrong", Caption = "NamTrong Header", Width = 100, },
                new TableColumn { Name = "NguonGoc", Caption = "NguonGoc Header", Width = 100, },
                new TableColumn { Name = "DieuKienLapDia", Caption = "DieuKienLapDia Header", Width = 100, },
                new TableColumn { Name = "TrangThaiSuDung", Caption = "TrangThaiSuDung Header", Width = 100, },
                new TableColumn { Name = "GiaTriDoDoc", Caption = "GiaTriDoDoc Header", Width = 100, },
                new TableColumn { Name = "GiaTriDoCao", Caption = "GiaTriDoCao Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "LoRung Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "MaLo", Caption = " Caption of MaLo", Layout = 6,   },
                new EditorInfo { Name = "TenLo", Caption = " Caption of TenLo", Layout = 6,   },
                new EditorInfo {
                    Name = "ChuRungId",
                    Caption = "Chủ sở hữu rừng",
                    Layout = 6,
                    Type = "select",
                    ValueName = "Id",
                    DisplayName = "TenChuRung",
                    Options = Provider.Select<ChuRung>()
                },
                new EditorInfo { Name = "BanDo", Caption = " Caption of BanDo", Layout = 6,   },
                new EditorInfo { Name = "DienTich", Caption = " Caption of DienTich", Layout = 6,   },
                new EditorInfo { Name = "TruLuong", Caption = " Caption of TruLuong", Layout = 6,   },
                new EditorInfo { Name = "NamTrong", Caption = " Caption of NamTrong", Layout = 6,   },
                new EditorInfo { Name = "NguonGoc", Caption = " Caption of NguonGoc", Layout = 6,   },
                new EditorInfo { Name = "DieuKienLapDia", Caption = " Caption of DieuKienLapDia", Layout = 6,   },
                new EditorInfo { Name = "TrangThaiSuDung", Caption = " Caption of TrangThaiSuDung", Layout = 6,   },
                new EditorInfo { Name = "DonViId", Caption = " Caption of DonViId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<DonVi>(), },
                new EditorInfo { Name = "LoaiRungId", Caption = " Caption of LoaiRungId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<LoaiRung>(), },
                new EditorInfo { Name = "ChuRungId", Caption = " Caption of ChuRungId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "TenChuRung", Options = Provider.Select<ChuRung>(), },
                new EditorInfo { Name = "GiongCayId", Caption = " Caption of GiongCayId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<GiongCay>(), },
                new EditorInfo { Name = "KyQuyHoachId", Caption = " Caption of KyQuyHoachId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
                new EditorInfo { Name = "DoDocId", Caption = " Caption of DoDocId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<ThuocTinhLoDat>(), },
                new EditorInfo { Name = "DoCaoId", Caption = " Caption of DoCaoId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<ThuocTinhLoDat>(), },
                new EditorInfo { Name = "DoDayDatId", Caption = " Caption of DoDayDatId", Layout = 6,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<ThuocTinhLoDat>(), },
                new EditorInfo { Name = "GiaTriDoDoc", Caption = " Caption of GiaTriDoDoc", Layout = 6,   },
                new EditorInfo { Name = "GiaTriDoCao", Caption = " Caption of GiaTriDoCao", Layout = 6,   },
            };
        }
    }
    class Edit : Add
    {
        protected override void OnReady()
        {
            // Thay FieldName bằng tên trường muốn thể hiện trên câu hỏi xóa bản ghi
            ShowDeleteAction("FieldName");
            // Thay EditorName bằng tên trường muốn cấm soạn thảo
            Find("EditorName", c => c.IsEnabled = false);
        }
    }
}
