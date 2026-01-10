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
        public object Forgot()
        {
            return View(new EditContext(new QuenMatKhauModel())
            {
                Action = EditActions.Update
            });
        }

        // [QUAN TRỌNG] Phân luồng xử lý: Đăng nhập hay Quên MK?
        public new object Update(EditContext context)
        {
            if (context.Model is EditContext wrapped)
            {
                context.Model = wrapped.Model;
            }

            // 2. Nếu là Quên Mật Khẩu
            if (context.Model is QuenMatKhauModel)
            {
                return Recover(context);
            }

            // 3. Nếu là Đăng Nhập bình thường
            return base.Update(context);
        }

        // Xử lý Logic Quên Mật Khẩu
        public object Recover(EditContext context)
        {
            var doc = Document.FromObject(context.Model);

            // 2. [DEBUG] Kiểm tra xem hệ thống nhận được cái gì
            // Nếu doc rỗng, nghĩa là Giao diện chưa đẩy dữ liệu vào Model
            if (doc.Count == 0)
            {
                // Thử "bóc vỏ" thêm 1 lớp nữa phòng trường hợp bị gói lồng nhau
                if (context.Model is EditContext wrapped)
                {
                    doc = Document.FromObject(wrapped.Model);
                }
            }

            // 3. Lấy dữ liệu (Sử dụng cả tên viết hoa và viết thường để chắc ăn)
            // Lưu ý: Key phải khớp với Property trong QuenMatKhauModel hoặc Name trong EditorInfo
            string tenDangNhap = doc.GetString("TenDangNhap");
            string email = doc.GetString("Email");
            string sdt = doc.GetString("SoDienThoai");
            string matKhauMoi = doc.GetString("MatKhauMoi");

            // 4. Kiểm tra nhập thiếu và BÁO LỖI CHI TIẾT
            // Nếu thiếu, in ra những gì nhận được để bạn biết đường sửa
            if (string.IsNullOrEmpty(tenDangNhap) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(matKhauMoi))
            {
                // Tạo danh sách các trường đã nhận được để hiển thị lên màn hình
                string debugInfo = "";
                foreach (var key in doc.Keys)
                {
                    debugInfo += $"{key}={doc[key]}; ";
                }

                return Error(1, $"Dữ liệu chưa đến được Controller!\n" +
                                $"Hệ thống nhận được: [{debugInfo}]\n" +
                                $"Cần nhận: TenDangNhap, Email, SoDienThoai, MatKhauMoi");
            }

            // A. Tìm tài khoản
            var acc = DataEngine.Find<TaiKhoan>(tenDangNhap);
            if (acc == null) return Error(1, "Tên đăng nhập không tồn tại");

            // B. Kiểm tra Hồ sơ
            if (acc.HoSoId == 0) return Error(1, "Tài khoản chưa liên kết hồ sơ.");

            var profile = Provider.GetTable<HoSo>().Find<HoSo>(acc.HoSoId);

            // C. So khớp (Dùng Trim để xóa khoảng trắng thừa)
            bool isMatch = (profile.Email != null && profile.Email.Trim().Equals(email.Trim(), StringComparison.OrdinalIgnoreCase)) &&
                           (profile.SDT != null && profile.SDT.Trim() == sdt.Trim());

            if (!isMatch) return Error(1, "Email hoặc SĐT không khớp với hồ sơ gốc!");

            // D. Đổi mật khẩu
            try
            {
                Provider.CreateCommand(cmd => {
                    cmd.CommandText = $"UPDATE TaiKhoan SET MatKhau = @p WHERE Ten = @u";
                    cmd.Parameters.AddWithValue("@p", matKhauMoi);
                    cmd.Parameters.AddWithValue("@u", tenDangNhap);
                    cmd.ExecuteNonQuery();
                });
            }
            catch (Exception ex)
            {
                return Error(1, "Lỗi hệ thống: " + ex.Message);
            }

            return Redirect("login/index");
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
