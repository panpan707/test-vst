using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.BanDoQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Bản Đồ Quy Hoạch";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenBanDo", Caption = "Tên Bản Đồ", Width = 200, },
                new TableColumn { Name = "LoaiBanDo", Caption = "Loại Bản Đồ", Width = 100, },
                new TableColumn { Name = "TyLe", Caption = "Tỷ Lệ", Width = 100, },
                new TableColumn { Name = "DuLieuBanDo", Caption = "Dữ Liệu Bản Đồ", Width = 150, },
                new TableColumn { Name = "MoTa", Caption = "Mô Tả", Width = 200, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Bản Đồ Quy Hoạch";
            context.Editors = new object[] {
                new EditorInfo { Name = "KyQuyHoachId", Caption = "Kỳ Quy Hoạch", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
                new EditorInfo { Name = "TenBanDo", Caption = "Tên Bản Đồ", Layout = 12,   },
                new EditorInfo { Name = "LoaiBanDo", Caption = "Loại Bản Đồ", Layout = 12,   },
                new EditorInfo { Name = "TyLe", Caption = "Tỷ Lệ", Layout = 12,   },
                new EditorInfo { Name = "DuLieuBanDo", Caption = "Dữ Liệu Bản Đồ", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = "Mô Tả", Layout = 12,   },
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
