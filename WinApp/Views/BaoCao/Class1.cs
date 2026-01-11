using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.BaoCao
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách Báo Cáo Thiên Tai";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TieuDe", Caption = "Tiêu Đề", Width = 350, },
                new TableColumn { Name = "NgayBaoCao", Caption = "Ngày Báo Cáo", Width = 125, },
                new TableColumn { Name = "NoiDung", Caption = "Nội Dung", Width = 500, },
                new TableColumn { Name = "FileDinhKem", Caption = "File Đính Kèm", Width = 175, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Báo Cáo";
            context.Editors = new object[] {
                new EditorInfo { Name = "TieuDe", Caption = "Tiêu Đề", Layout = 12,   },
                new EditorInfo { Name = "NgayBaoCao", Caption = "Ngày Báo Cáo", Layout = 12,   },
                new EditorInfo { Name = "NoiDung", Caption = "Nội Dung", Layout = 12,   },
                new EditorInfo { Name = "FileDinhKem", Caption = "File Đính Kèm", Layout = 12,   },
                new EditorInfo { Name = "NguoiBaoCao", Caption = "Người Báo Cáo", Layout = 12,
    Type = "select", ValueName = "Ten", DisplayName = "FieldName", Options = Provider.Select<TaiKhoan>(), },
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
