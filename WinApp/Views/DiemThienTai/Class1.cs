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
            context.Title = "Quản lý Điểm Thiên Tai";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenDiem", Caption = "Tên Điểm", Width = 150, },
                new TableColumn { Name = "LoaiThienTai", Caption = "Loại Thiên Tai", Width = 120, },
                new TableColumn { Name = "MucDo", Caption = "Mức Độ", Width = 100, },
                new TableColumn { Name = "ToaDoX", Caption = "Toạ Độ X", Width = 100, },
                new TableColumn { Name = "ToaDoY", Caption = "Toạ Độ Y", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "Mô Tả", Width = 250, },
            };
                context.Search = (o, s) =>
            {
                var e = (Models.DiemThienTai)o; // Ép kiểu về Lô Rừng
                var k = s.ToLower(); // Chuyển từ khóa về chữ thường để so sánh

                // Kiểm tra xem từ khóa có nằm trong các trường này không
                // Lưu ý: Cần check != null để tránh lỗi crash app
                return(e.LoaiThienTai != null && e.LoaiThienTai.ToLower().Contains(k));



                
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thông tin Điểm Thiên Tai";
            context.Editors = new object[] {
                new EditorInfo { Name = "TenDiem", Caption = "Tên Điểm", Layout = 12,   },
                new EditorInfo { Name = "LoaiThienTai", Caption = "Loại Thiên Tai", Layout = 12,   },
                new EditorInfo { Name = "MucDo", Caption = "Mức Độ", Layout = 12,   },
                new EditorInfo { Name = "ToaDoX", Caption = "Toạ Độ X", Layout = 12,   },
                new EditorInfo { Name = "ToaDoY", Caption = "Toạ Độ Y", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = "Mô Tả", Layout = 12,   },
                new EditorInfo { Name = "DonViId", Caption = "Đơn Vị ID", Layout = 12,
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
