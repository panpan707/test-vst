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
            context.Title = "Lịch Sử Tác Động";
            context.TableColumns = new object[] {
                new TableColumn { Name = "NguoiThucHien", Caption = "Người Thực Hiện", Width = 150, },
                new TableColumn { Name = "ThoiGian", Caption = "Thời Gian", Width = 150, },
                new TableColumn { Name = "BangTacDong", Caption = "Bảng Tác Động", Width = 120, },
                new TableColumn { Name = "IdBanGhi", Caption = "Id Bản Ghi", Width = 100, },
                new TableColumn { Name = "LoaiTacDong", Caption = "Loại Tác Động", Width = 100, },
                new TableColumn { Name = "NoiDungThayDoi", Caption = "Nội Dung Thay Đổi", Width = 150, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "LichSuTacDong ";
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
