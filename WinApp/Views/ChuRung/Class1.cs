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
            context.Title = "List of ChuRung";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenChuRung", Caption = "TenChuRung Header", Width = 100, },
                new TableColumn { Name = "LoaiChuSoHuu", Caption = "LoaiChuSoHuu Header", Width = 100, },
                new TableColumn { Name = "DiaChi", Caption = "DiaChi Header", Width = 100, },
                new TableColumn { Name = "SoDienThoai", Caption = "SoDienThoai Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "ChuRung Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenChuRung", Caption = " Caption of TenChuRung", Layout = 12,   },
                new EditorInfo { Name = "LoaiChuSoHuu", Caption = " Caption of LoaiChuSoHuu", Layout = 12,   },
                new EditorInfo { Name = "DiaChi", Caption = " Caption of DiaChi", Layout = 12,   },
                new EditorInfo { Name = "SoDienThoai", Caption = " Caption of SoDienThoai", Layout = 12,   },
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

