using System;
using Models;

namespace WinApp.Views.GiongCay
{
    using Vst.Controls;

    // MÀN HÌNH DANH SÁCH
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Danh Sách Giống Cây Trồng";

            context.TableColumns = new object[] {
                // Name phải trùng với Property trong Model ở trên
                new TableColumn { Name = "Ten", Caption = "Tên Giống", Width = 200 },
                new TableColumn { Name = "LoaiCay", Caption = "Loại Cây", Width = 150 },
                new TableColumn { Name = "Nguon", Caption = "Nguồn Gốc", Width = 200 },
                new TableColumn { Name = "DacTinh", Caption = "Đặc Tính", Width = 300 },
            };
        }
    }

    // MÀN HÌNH THÊM MỚI / SỬA
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thêm Giống Cây";

            context.Editors = new object[] {
                new EditorInfo { Name = "Ten", Caption = "Tên Giống", Layout = 6 },
                new EditorInfo { Name = "LoaiCay", Caption = "Loại Cây", Layout = 6 },
                new EditorInfo { Name = "Nguon", Caption = "Nguồn Gốc", Layout = 12 },
                new EditorInfo { Name = "DacTinh", Caption = "Đặc Tính", Layout = 12 },
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
