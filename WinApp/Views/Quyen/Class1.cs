using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.Quyen
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of Quyen";
            context.TableColumns = new object[] {
                new TableColumn { Name = "Ten", Caption = "Ten Header", Width = 100, },
                new TableColumn { Name = "Ext", Caption = "Ext Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Quyen Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "Ten", Caption = " Caption of Ten", Layout = 12,   },
                new EditorInfo { Name = "Ext", Caption = " Caption of Ext", Layout = 12,   },
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
