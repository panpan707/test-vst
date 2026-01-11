using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.HoSo
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách Hồ Sơ";
            context.TableColumns = new object[] {
                new TableColumn { Name = "Ten", Caption = "Tên ", Width = 150, },
                new TableColumn { Name = "SDT", Caption = "Số Điện Thoại ", Width = 100, },
                new TableColumn { Name = "Email", Caption = "Email ", Width = 200, },
                new TableColumn { Name = "Ext", Caption = "Chức Vụ", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Hồ Sơ";
            context.Editors = new object[] {
                new EditorInfo { Name = "Ten", Caption = "Tên", Layout = 12,   },
                new EditorInfo { Name = "SDT", Caption = "Số Điện Thoại", Layout = 12,   },
                new EditorInfo { Name = "Email", Caption = "Email", Layout = 12,   },
                new EditorInfo { Name = "Ext", Caption = "Chức Vụ", Layout = 12,   },
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
