using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.ThuocTinhLoDat
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of ThuocTinhLoDat";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenThuocTinh", Caption = "TenThuocTinh Header", Width = 100, },
                new TableColumn { Name = "NhomThuocTinh", Caption = "NhomThuocTinh Header", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "MoTa Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "ThuocTinhLoDat Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenThuocTinh", Caption = " Caption of TenThuocTinh", Layout = 12,   },
                new EditorInfo { Name = "NhomThuocTinh", Caption = " Caption of NhomThuocTinh", Layout = 12,   },
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
