using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vst.Controls;
namespace WinApp.Views.Login
{
    // Form nhập liệu
    public class Forgot : EditView
    {
        // Quan trọng: Giữ layout null giống Login để giao diện đồng bộ
        protected override object CreateLayout() => null;

        protected override void RenderCore(ViewContext context)
        {
            base.RenderCore(context); // Quan trọng để khởi tạo cơ bản
            context.Title = "Khôi phục mật khẩu";

            context.Editors = new object[] {
                // Chú ý: Name ở đây phải KHỚP 100% với tên biến trong Controller (chữ hoa thường)
                new EditorInfo { Name = "TenDangNhap", Caption = "Tên đăng nhập", Layout = 12 },
                new EditorInfo { Name = "Email", Caption = "Email đăng ký", Layout = 12 },
                new EditorInfo { Name = "SoDienThoai", Caption = "Số điện thoại", Layout = 12 },

                new EditorInfo { Name = "MatKhauMoi", Caption = "Mật khẩu mới", Layout = 12, Type = "password" }
            };
        }

        protected override void OnReady()
        {
            base.OnReady();

            // 1. Cấu hình nút GỬI (Bắt buộc dùng AcceptButton để có dữ liệu)
            MainView.AcceptButton.Text = "Xác nhận đổi mật khẩu";
            MainView.AcceptButton.IsVisible = true;

            // 2. Cấu hình nút QUAY LẠI (Dùng CancelButton)
            MainView.CancelButton.Text = "Quay lại Đăng nhập";
            MainView.CancelButton.IsVisible = true;
            // Ghi đè sự kiện nút Cancel để quay về trang Login thay vì đóng app
            MainView.CancelButton.Click += (s, e) => {
                System.Mvc.Engine.Execute("login/index");
            };

            // 3. Ẩn nút Deny (Nút này chỉ dùng làm nút 'Quên MK' ở màn hình Login, màn hình này không cần)
            MainView.DenyButton.IsVisible = false;
        }
    }
}