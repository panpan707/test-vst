using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinApp.Views.BanDoQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of BanDoQuyHoach";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenBanDo", Caption = "TenBanDo Header", Width = 100, },
                new TableColumn { Name = "LoaiBanDo", Caption = "LoaiBanDo Header", Width = 100, },
                new TableColumn { Name = "TyLe", Caption = "TyLe Header", Width = 100, },
                new TableColumn { Name = "DuLieuBanDo", Caption = "DuLieuBanDo Header", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "MoTa Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "BanDoQuyHoach Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "KyQuyHoachId", Caption = " Caption of KyQuyHoachId", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
                new EditorInfo { Name = "TenBanDo", Caption = " Caption of TenBanDo", Layout = 12,   },
                new EditorInfo { Name = "LoaiBanDo", Caption = " Caption of LoaiBanDo", Layout = 12,   },
                new EditorInfo { Name = "TyLe", Caption = " Caption of TyLe", Layout = 12,   },
                new EditorInfo { Name = "DuLieuBanDo", Caption = " Caption of DuLieuBanDo", Layout = 12,   },
                new EditorInfo { Name = "MoTa", Caption = " Caption of MoTa", Layout = 12,   },
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
