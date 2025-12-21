using System;
using Models;

namespace WinApp.Views.LoRung
{
    using Vst.Controls;

    public class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Quản lý Lô Rừng";

            context.TableColumns = new object[] {
                // Name: Phải trùng tên biến trong Model LoRung ở trên
                new TableColumn { Name = "MaLo", Caption = "Mã Lô", Width = 100 },
                new TableColumn { Name = "DienTich", Caption = "Diện Tích (ha)", Width = 100 },
                new TableColumn { Name = "TruLuong", Caption = "Trữ Lượng (m3)", Width = 120 },
                new TableColumn { Name = "TrangThaiSuDung", Caption = "Trạng Thái", Width = 150 },
                new TableColumn { Name = "NguonGoc", Caption = "Nguồn Gốc", Width = 150 },
            };
        }
    }

    // Giữ nguyên phần Add/Edit của bạn hoặc cập nhật Name tương tự nếu cần
    public class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thông tin Lô Rừng";
            context.Editors = new object[] {
                 new EditorInfo { Name = "MaLo", Caption = "Mã Lô", Layout = 6 },
                 new EditorInfo { Name = "DienTich", Caption = "Diện Tích", Layout = 6 },
                 new EditorInfo { Name = "TruLuong", Caption = "Trữ Lượng", Layout = 6 },
                 new EditorInfo { Name = "TrangThaiSuDung", Caption = "Trạng Thái", Layout = 6 },
            };
        }
    }
    public class Edit : Add
    {
        protected override void OnReady() { ShowDeleteAction("MaLo"); }
    }
}