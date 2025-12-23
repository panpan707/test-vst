using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.ViewHoSo
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of ViewHoSo";
            context.TableColumns = new object[] {
                new TableColumn { Name = "Id", Caption = "Id Header", Width = 100, },
                new TableColumn { Name = "Ten", Caption = "Ten Header", Width = 100, },
                new TableColumn { Name = "SDT", Caption = "SDT Header", Width = 100, },
                new TableColumn { Name = "Email", Caption = "Email Header", Width = 100, },
                new TableColumn { Name = "Ext", Caption = "Ext Header", Width = 100, },
                new TableColumn { Name = "TenDangNhap", Caption = "TenDangNhap Header", Width = 100, },
                new TableColumn { Name = "MatKhau", Caption = "MatKhau Header", Width = 100, },
                new TableColumn { Name = "QuyenId", Caption = "QuyenId Header", Width = 100, },
                new TableColumn { Name = "Quyen", Caption = "Quyen Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "ViewHoSo Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "Id", Caption = " Caption of Id", Layout = 12,   },
                new EditorInfo { Name = "Ten", Caption = " Caption of Ten", Layout = 12,   },
                new EditorInfo { Name = "SDT", Caption = " Caption of SDT", Layout = 12,   },
                new EditorInfo { Name = "Email", Caption = " Caption of Email", Layout = 12,   },
                new EditorInfo { Name = "Ext", Caption = " Caption of Ext", Layout = 12,   },
                new EditorInfo { Name = "TenDangNhap", Caption = " Caption of TenDangNhap", Layout = 12,   },
                new EditorInfo { Name = "MatKhau", Caption = " Caption of MatKhau", Layout = 12,   },
                new EditorInfo { Name = "QuyenId", Caption = " Caption of QuyenId", Layout = 12,   },
                new EditorInfo { Name = "Quyen", Caption = " Caption of Quyen", Layout = 12,   },
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
