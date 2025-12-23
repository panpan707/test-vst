using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.BienDongRung
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of BienDongRung";
            context.TableColumns = new object[] {
                new TableColumn { Name = "NgayBienDong", Caption = "NgayBienDong Header", Width = 100, },
                new TableColumn { Name = "LoaiBienDong", Caption = "LoaiBienDong Header", Width = 100, },
                new TableColumn { Name = "DienTichBienDong", Caption = "DienTichBienDong Header", Width = 100, },
                new TableColumn { Name = "MoTaChiTiet", Caption = "MoTaChiTiet Header", Width = 100, },
                new TableColumn { Name = "NguoiCapNhat", Caption = "NguoiCapNhat Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "BienDongRung Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "LoRungId", Caption = " Caption of LoRungId", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<LoRung>(), },
                new EditorInfo { Name = "NgayBienDong", Caption = " Caption of NgayBienDong", Layout = 12,   },
                new EditorInfo { Name = "LoaiBienDong", Caption = " Caption of LoaiBienDong", Layout = 12,   },
                new EditorInfo { Name = "DienTichBienDong", Caption = " Caption of DienTichBienDong", Layout = 12,   },
                new EditorInfo { Name = "MoTaChiTiet", Caption = " Caption of MoTaChiTiet", Layout = 12,   },
                new EditorInfo { Name = "NguoiCapNhat", Caption = " Caption of NguoiCapNhat", Layout = 12,   },
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
