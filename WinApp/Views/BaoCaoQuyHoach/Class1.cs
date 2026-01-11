using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.BaoCaoQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Báo Cáo Quy Hoạch";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenBaoCao", Caption = "Tên Báo Cáo", Width = 200, },
                new TableColumn { Name = "SoHieuVanBan", Caption = "Số Hiệu Văn Bản", Width = 150, },
                new TableColumn { Name = "NgayBanHanh", Caption = "Ngày Ban Hành", Width = 150, },
                new TableColumn { Name = "CoQuanBanHanh", Caption = "Cơ Quan Ban Hành", Width = 200, },
                new TableColumn { Name = "FileDinhKem", Caption = "File Đính Kèm", Width = 150, },
                new TableColumn { Name = "MoTa", Caption = "Mô Tả", Width = 200, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Báo Cáo Quy Hoạch";
            context.Editors = new object[] {
                new EditorInfo { Name = "KyQuyHoachId", Caption = "ID Kỳ Quy Hoạch", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
                new EditorInfo { Name = "TenBaoCao", Caption = "Tên Báo Cáo", Layout = 12,   },
                new EditorInfo { Name = "SoHieuVanBan", Caption = "Số Hiệu Văn Bản", Layout = 12,   },
                new EditorInfo { Name = "NgayBanHanh", Caption = "Ngày Ban Hành", Layout = 12,   },
                new EditorInfo { Name = "CoQuanBanHanh", Caption = "Cơ Quan Ban Hành", Layout = 12,   },
                new EditorInfo { Name = "FileDinhKem", Caption = "File Đính Kèm", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = " Caption of MoTa", Layout = 12,   },
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
