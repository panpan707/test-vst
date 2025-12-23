using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.DiemThienTai
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of DiemThienTai";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenDiem", Caption = "TenDiem Header", Width = 100, },
                new TableColumn { Name = "LoaiThienTai", Caption = "LoaiThienTai Header", Width = 100, },
                new TableColumn { Name = "MucDo", Caption = "MucDo Header", Width = 100, },
                new TableColumn { Name = "ToaDoX", Caption = "ToaDoX Header", Width = 100, },
                new TableColumn { Name = "ToaDoY", Caption = "ToaDoY Header", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "MoTa Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "DiemThienTai Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenDiem", Caption = " Caption of TenDiem", Layout = 12,   },
                new EditorInfo { Name = "LoaiThienTai", Caption = " Caption of LoaiThienTai", Layout = 12,   },
                new EditorInfo { Name = "MucDo", Caption = " Caption of MucDo", Layout = 12,   },
                new EditorInfo { Name = "ToaDoX", Caption = " Caption of ToaDoX", Layout = 12,   },
                new EditorInfo { Name = "ToaDoY", Caption = " Caption of ToaDoY", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = " Caption of MoTa", Layout = 12,   },
                new EditorInfo { Name = "DonViId", Caption = " Caption of DonViId", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<DonVi>(), },
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
