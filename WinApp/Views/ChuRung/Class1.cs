using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.ChuRung
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách Chủ Rừng";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenChuRung", Caption = "Tên Chủ Rừng", Width = 150, },
                new TableColumn { Name = "LoaiChuSoHuu", Caption = "Loại Chủ Sở Hữu", Width = 150, },
                new TableColumn { Name = "DiaChi", Caption = "Địa Chỉ", Width = 200, },
                new TableColumn { Name = "SoDienThoai", Caption = "Số Điện Thoại", Width = 150, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Chủ Rừng";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenChuRung", Caption = "Tên Chủ Rừng", Layout = 12,   },
                new EditorInfo { Name = "LoaiChuSoHuu", Caption = "Loại Chủ Sở Hữu", Layout = 12,   },
                new EditorInfo { Name = "DiaChi", Caption = "Địa Chỉ", Layout = 12,   },
                new EditorInfo { Name = "SoDienThoai", Caption = "Số Điện Thoại", Layout = 12,   },
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

