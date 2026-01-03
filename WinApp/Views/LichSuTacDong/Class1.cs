using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.LichSuTacDong
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of LichSuTacDong";
            context.TableColumns = new object[] {
                new TableColumn { Name = "NguoiThucHien", Caption = "Nguoi Thuc Hien ", Width = 100, },
                new TableColumn { Name = "ThoiGian", Caption = "Thoi Gian ", Width = 100, },
                new TableColumn { Name = "BangTacDong", Caption = "Bang Tac Dong ", Width = 100, },
                new TableColumn { Name = "IdBanGhi", Caption = "Id Ban Ghi ", Width = 100, },
                new TableColumn { Name = "LoaiTacDong", Caption = "Loai Tac Dong ", Width = 100, },
                new TableColumn { Name = "NoiDungThayDoi", Caption = "Noi Dung Thay Doi ", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "LichSuTacDong Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "NguoiThucHien", Caption = " Caption of NguoiThucHien", Layout = 12,   },
                new EditorInfo { Name = "ThoiGian", Caption = " Caption of ThoiGian", Layout = 12,   },
                new EditorInfo { Name = "BangTacDong", Caption = " Caption of BangTacDong", Layout = 12,   },
                new EditorInfo { Name = "IdBanGhi", Caption = " Caption of IdBanGhi", Layout = 12,   },
                new EditorInfo { Name = "LoaiTacDong", Caption = " Caption of LoaiTacDong", Layout = 12,   },
                new EditorInfo { Name = "NoiDungThayDoi", Caption = " Caption of NoiDungThayDoi", Layout = 12,   },
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
