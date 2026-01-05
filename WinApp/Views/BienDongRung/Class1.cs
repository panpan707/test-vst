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
            context.Title = "Quản lý Biến Động Rừng";
            context.TableColumns = new object[] {
                new TableColumn { Name = "NgayBienDong", Caption = "Ngày Biến Động", Width = 150, },
                new TableColumn { Name = "LoaiBienDong", Caption = "Loại Biến Động", Width = 150, },
                new TableColumn { Name = "DienTichBienDong", Caption = "Diện Tích Biến Động", Width = 150, },
                new TableColumn { Name = "MoTaChiTiet", Caption = "Mô Tả Chi Tiết", Width = 300, },
                new TableColumn { Name = "NguoiCapNhat", Caption = "Người Cập Nhật", Width = 150, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thông tin Biến Động Rừng";
            context.Editors = new object[] {
                new EditorInfo { Name = "LoRungId", Caption = "Lô Rừng ID", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<LoRung>(), },
                new EditorInfo { Name = "NgayBienDong", Caption = "Ngày Biến Động", Layout = 12,   },
                new EditorInfo { Name = "LoaiBienDong", Caption = "Loại Biến Động", Layout = 12,   },
                new EditorInfo { Name = "DienTichBienDong", Caption = "Diện Tích Biến Động", Layout = 12,   },
                new EditorInfo { Name = "MoTaChiTiet", Caption = "Mô Tả Chi Tiết", Layout = 12,   },
                new EditorInfo { Name = "NguoiCapNhat", Caption = "Người Cập Nhật", Layout = 12,   },
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
