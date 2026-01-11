using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.LoaiRung
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách Loại Rừng";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenLoai", Caption = "Tên Loại", Width = 100, },
                new TableColumn { Name = "MaLoai", Caption = "Mã Loại", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "Mô Tả", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Loại Rừng";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenLoai", Caption = "Tên Loại", Layout = 12,   },
                new EditorInfo { Name = "MaLoai", Caption = "Mã Loại", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = "Mô Tả", Layout = 12,   },
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