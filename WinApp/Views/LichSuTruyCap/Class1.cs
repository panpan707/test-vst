using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.LichSuTruyCap
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of LichSuTruyCap";
            context.TableColumns = new object[] {
                new TableColumn { Name = "ThoiGian", Caption = "ThoiGian Header", Width = 100, },
                new TableColumn { Name = "HanhDong", Caption = "HanhDong Header", Width = 100, },
                new TableColumn { Name = "IPAddress", Caption = "IPAddress Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "LichSuTruyCap Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TaiKhoan", Caption = " Caption of TaiKhoan", Layout = 12,
    Type = "select", ValueName = "Ten", DisplayName = "FieldName", Options = Provider.Select<TaiKhoan>(), },
                new EditorInfo { Name = "ThoiGian", Caption = " Caption of ThoiGian", Layout = 12,   },
                new EditorInfo { Name = "HanhDong", Caption = " Caption of HanhDong", Layout = 12,   },
                new EditorInfo { Name = "IPAddress", Caption = " Caption of IPAddress", Layout = 12,   },
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
