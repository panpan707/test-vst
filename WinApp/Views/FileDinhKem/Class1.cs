using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.FileDinhKem
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách File Đính Kèm";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenFile", Caption = "Tên File", Width = 100, },
                new TableColumn { Name = "DuongDan", Caption = "Đường Dẫn", Width = 100, },
                new TableColumn { Name = "LoaiDoiTuong", Caption = "Loại Đối Tượng", Width = 100, },
                new TableColumn { Name = "IdDoiTuong", Caption = "ID Đối Tượng", Width = 100, },
                new TableColumn { Name = "NgayUpload", Caption = "Ngày Upload", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm File Đính Kèm";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenFile", Caption = "Tên File", Layout = 12,   },
                new EditorInfo { Name = "DuongDan", Caption = "Đường Dẫn", Layout = 12,   },
                new EditorInfo { Name = "LoaiDoiTuong", Caption = "Loại Đối Tượng", Layout = 12,   },
                new EditorInfo { Name = "IdDoiTuong", Caption = "Id Đối Tượng", Layout = 12,   },
                new EditorInfo { Name = "NgayUpload", Caption = "Ngày Update", Layout = 12,   },
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
