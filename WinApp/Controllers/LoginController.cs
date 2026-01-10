using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Controllers
{
    using Models;
    
    class LoginController : DataController<TaiKhoan>
    {        
        public override object Index()
        {
            return View(new EditContext(new TaiKhoan { Ten = "", MatKhau = "" }));
        }
        protected override void UpdateCore(TaiKhoan acc)
        {
            var pass = acc.MatKhau;

            acc = DataEngine.Find<TaiKhoan>(acc.Ten);
            if (acc == null)
            {
                UpdateContext.Message = "Người dùng không tồn tại";
                return;
            }
            if (acc.MatKhau != pass)
            {
                UpdateContext.Message = "Sai mật khẩu";
                return;
            }

            // Chỗ này khả năng xuất hiện lỗi chưa định nghĩa lớp trong file Actors/User.cs
            var role = Provider.GetTable<Quyen>().GetValueById("Ext", acc.QuyenId);
            var u = (User)Activator.CreateInstance(Type.GetType($"Actors.{role}"));

            u.UserName = acc.Ten;
            if (acc.HoSoId != 0)
            {
                var p = Provider.GetTable<HoSo>().Find<HoSo>(acc.HoSoId);
                u.Description = p.Ten;
                u.Profile = p;
            }
            App.User = u;

            // ==========================================================
            // [MỚI THÊM] 4. GHI LỊCH SỬ TRUY CẬP (LOGGING)
            // ==========================================================
            try
            {
                Provider.CreateCommand(cmd => {
                    // Câu lệnh SQL khớp với bảng LichSuTruyCap trong file Tables.sql
                    cmd.CommandText = "INSERT INTO LichSuTruyCap (TaiKhoan, ThoiGian, HanhDong) VALUES (@u, GETDATE(), N'Đăng nhập hệ thống')";

                    // Truyền tham số để tránh lỗi SQL Injection
                    cmd.Parameters.AddWithValue("@u", acc.Ten);

                    cmd.ExecuteNonQuery();
                });
            }
            catch
            {
                // Có thể bỏ qua lỗi ghi log để không chặn người dùng đăng nhập
            }
            // ==========================================================
        }

        static int errorCount = 0;
        protected override object UpdateError()
        {
            const int max = 3;
            if (errorCount == max)
            {
                App.Current.Shutdown();
                return null;
            }
            UpdateContext.Message += $".\nĐược phép sai thêm {max - (++errorCount)} lần.";
            return Error(1, UpdateContext.Message);
        }
        protected override object UpdateSuccess()
        {
            errorCount = 0;
            if (App.User is Actors.Staff)
            {
                return Redirect("giongcay/index"); // <--- Đường dẫn này phải khớp với cái bạn Hard-code trong User.cs
            }
            return Redirect("home");
        }
    }
}
