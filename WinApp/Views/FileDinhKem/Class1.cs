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
            context.Title = "List of FileDinhKem";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenFile", Caption = "TenFile Header", Width = 100, },
                new TableColumn { Name = "DuongDan", Caption = "DuongDan Header", Width = 100, },
                new TableColumn { Name = "LoaiDoiTuong", Caption = "LoaiDoiTuong Header", Width = 100, },
                new TableColumn { Name = "IdDoiTuong", Caption = "IdDoiTuong Header", Width = 100, },
                new TableColumn { Name = "NgayUpload", Caption = "NgayUpload Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "FileDinhKem Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenFile", Caption = " Caption of TenFile", Layout = 12,   },
                new EditorInfo { Name = "DuongDan", Caption = " Caption of DuongDan", Layout = 12,   },
                new EditorInfo { Name = "LoaiDoiTuong", Caption = " Caption of LoaiDoiTuong", Layout = 12,   },
                new EditorInfo { Name = "IdDoiTuong", Caption = " Caption of IdDoiTuong", Layout = 12,   },
                new EditorInfo { Name = "NgayUpload", Caption = " Caption of NgayUpload", Layout = 12,   },
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
