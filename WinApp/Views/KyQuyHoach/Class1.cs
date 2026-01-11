using System;
namespace WinApp.Views.KyQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Kỳ Quy Hoạch";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenKy", Caption = "Tên Kỳ", Width = 175, },
                new TableColumn { Name = "TuNam", Caption = "Từ Năm", Width = 100, },
                new TableColumn { Name = "DenNam", Caption = "Đến Năm", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "Mô Tả", Width = 200, },
                new TableColumn { Name = "TrangThai", Caption = "Trạng Thái", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Kỳ Thu Hoạch";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenKy", Caption = "Tên Kỳ", Layout = 12,   },
                new EditorInfo { Name = "TuNam", Caption = "Từ Năm", Layout = 12,   },
                new EditorInfo { Name = "DenNam", Caption = "Đến Năm", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = "Mô Tả", Layout = 12,   },
                new EditorInfo { Name = "TrangThai", Caption = "Trạng Thái", Layout = 12,   },
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
