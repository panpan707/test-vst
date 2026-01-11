using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace System
{
    public class User
    {
        public ActionContext TopMenu { get; set; }
        public ActionContext SideMenu { get; set; }
        public string UserName { get; set; }
        public object Profile { get; set; }
        public string Description { get; set; }
    }
}

namespace Actors
{
    public partial class Admin : User { }
    public partial class Developer : User { }
    public partial class Staff : User {
        public Staff()
        {
            // --- 1. SIDE MENU ---
            SideMenu = new ActionContext();

            var menu = new ActionContext("Quản lý CSDL tài nguyên rừng");
            var menuChucNang = new ActionContext("Chức năng Staff");
            menuChucNang.Add("Tra cứu lô rừng", "lorung/index");
            menuChucNang.Add("Chủ rừng", "map/view");
            SideMenu.Add(menuChucNang);

            // --- 2. TOP MENU ---
            TopMenu = new ActionContext();
            var menuTaiKhoan = new ActionContext("Tài khoản");
            menuTaiKhoan.Add("Đổi mật khẩu", "me/changepass");
            menuTaiKhoan.Add("Đăng xuất", "Logout");
            TopMenu.Add(menuTaiKhoan);
        }
    }
    
}
