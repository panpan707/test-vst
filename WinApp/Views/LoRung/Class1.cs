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
                new TableColumn { Name = "BanDo", Caption = "BanDo Header", Width = 100, },
                new TableColumn { Name = "DienTich", Caption = "DienTich Header", Width = 100, },
                new TableColumn { Name = "TruLuong", Caption = "TruLuong Header", Width = 100, },
                new TableColumn { Name = "NamTrong", Caption = "NamTrong Header", Width = 100, },
                new TableColumn { Name = "NguonGoc", Caption = "NguonGoc Header", Width = 100, },
                new TableColumn { Name = "DieuKienLapDia", Caption = "DieuKienLapDia Header", Width = 100, },
                new TableColumn { Name = "TrangThaiSuDung", Caption = "TrangThaiSuDung Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "LoRung Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "MaLo", Caption = " Ma Lo", Layout = 12,   },
                new EditorInfo { Name = "BanDo", Caption = " Ban Do", Layout = 12,   },
                new EditorInfo { Name = "DienTich", Caption = " Dien Tich", Layout = 12,   },
                new EditorInfo { Name = "TruLuong", Caption = " Tru Luong", Layout = 12,   },
                new EditorInfo { Name = "NamTrong", Caption = " Nam Trong", Layout = 12,   },
                new EditorInfo { Name = "NguonGoc", Caption = " `Nguon Goc", Layout = 12,   },
                new EditorInfo { Name = "DieuKienLapDia", Caption = " Dieu Kien Lap Dia", Layout = 12,   },
                new EditorInfo { Name = "TrangThaiSuDung", Caption = " Trang Thai Su Dung", Layout = 12,   },
                new EditorInfo { Name = "DonViId", Caption = "Don Vi Id", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<DonVi>(), },
                new EditorInfo { Name = "LoaiRungId", Caption = "Loai Rung Id", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<LoaiRung>(), },
                new EditorInfo { Name = "ChuRungId", Caption = " Chu Rung Id", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<ChuRung>(), },
                new EditorInfo { Name = "GiongCayId", Caption = " Giong Cay Id", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<GiongCay>(), },
                new EditorInfo { Name = "KyQuyHoachId", Caption = " Ky Quy Hoach Id", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
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
