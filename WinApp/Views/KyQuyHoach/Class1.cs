using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.KyQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of KyQuyHoach";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenKy", Caption = "TenKy Header", Width = 100, },
                new TableColumn { Name = "TuNam", Caption = "TuNam Header", Width = 100, },
                new TableColumn { Name = "DenNam", Caption = "DenNam Header", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "MoTa Header", Width = 100, },
                new TableColumn { Name = "TrangThai", Caption = "TrangThai Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "KyQuyHoach Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenKy", Caption = " Caption of TenKy", Layout = 12,   },
                new EditorInfo { Name = "TuNam", Caption = " Caption of TuNam", Layout = 12,   },
                new EditorInfo { Name = "DenNam", Caption = " Caption of DenNam", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = " Caption of MoTa", Layout = 12,   },
                new EditorInfo { Name = "TrangThai", Caption = " Caption of TrangThai", Layout = 12,   },
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
