using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.BaoCao
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of BaoCao";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TieuDe", Caption = "TieuDe Header", Width = 100, },
                new TableColumn { Name = "NgayBaoCao", Caption = "NgayBaoCao Header", Width = 100, },
                new TableColumn { Name = "NoiDung", Caption = "NoiDung Header", Width = 100, },
                new TableColumn { Name = "FileDinhKem", Caption = "FileDinhKem Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "BaoCao Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "TieuDe", Caption = " Caption of TieuDe", Layout = 12,   },
                new EditorInfo { Name = "NgayBaoCao", Caption = " Caption of NgayBaoCao", Layout = 12,   },
                new EditorInfo { Name = "NoiDung", Caption = " Caption of NoiDung", Layout = 12,   },
                new EditorInfo { Name = "FileDinhKem", Caption = " Caption of FileDinhKem", Layout = 12,   },
                new EditorInfo { Name = "NguoiBaoCao", Caption = " Caption of NguoiBaoCao", Layout = 12,
    Type = "select", ValueName = "Ten", DisplayName = "FieldName", Options = Provider.Select<TaiKhoan>(), },
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
