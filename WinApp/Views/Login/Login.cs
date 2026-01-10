using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.Login
{
    using Vst.Controls;

    
    class Index : EditView
    {
        protected override object CreateLayout() => null;

        protected override void RenderCore(ViewContext context)
        {
            base.RenderCore(context);
            context.Title = "Đăng nhập";

            // 1. Cấu hình ô nhập liệu (Giữ nguyên code của bạn)
            context.Editors = new object[] {
                // Dropdown chọn nhanh admin/dev
                new EditorInfo { Name = "Ten", Caption = "Tên người dùng", Type = "select", Options = "admin;dev", Placeholder = "Tên người dùng" },
                new EditorInfo { Name = "MatKhau", Type = "password", Caption = "Mật khẩu", Placeholder = "Mật khẩu" },
            };

            // 2. Thêm nút "Quên mật khẩu?" vào thanh công cụ
            context.Actions = new List<ActionInfo>
            {
                new ActionInfo {
                    Name = "Forgot",
                    Caption = "Quên mật khẩu?",
                    Icon = "Help",
                    Action = (c) => {
                        // Chuyển hướng sang trang Quên Mật Khẩu
                        System.Mvc.Engine.Execute("login/forgot");
                    }
                }
            };
        }

        // 3. Sử dụng OnReady để thao tác với nút bấm (An toàn hơn để trong RenderCore)
        protected override void OnReady()
        {
            base.OnReady();

            // 1. Nút Đăng Nhập (Màu xanh)
            MainView.AcceptButton.Text = "Đăng nhập";

            // 2. Ẩn nút Hủy
            MainView.CancelButton.IsVisible = false;

            // 3. [MỚI] TÁI CHẾ NÚT "TỪ CHỐI" ĐỂ LÀM NÚT "QUÊN MẬT KHẨU"
            // Nút này có sẵn trong Framework, chắc chắn sẽ hiện
            MainView.DenyButton.IsVisible = true;
            MainView.DenyButton.Text = "Quên mật khẩu?";

            // Gán sự kiện bấm nút
            MainView.DenyButton.Click += (s, e) => {
                // Chuyển hướng sang trang Quên Mật Khẩu
                System.Mvc.Engine.Execute("login/forgot");
            };
        }
    }
}