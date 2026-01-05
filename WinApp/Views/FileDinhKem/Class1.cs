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
            context.Title = "Quản lý File Đính Kèm";
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
            context.Title = "Thông tin File Đính Kèm";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenFile", Caption = "Ten File", Layout = 12,   },
                new EditorInfo { Name = "DuongDan", Caption = "Duong Dan", Layout = 12,   },
                new EditorInfo { Name = "LoaiDoiTuong", Caption = "Loai Doi Tuong", Layout = 12,   },
                new EditorInfo { Name = "IdDoiTuong", Caption = "Id Doi Tuong", Layout = 12,   },
                new EditorInfo { Name = "NgayUpload", Caption = "Ngay Upload", Layout = 12,   },
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
