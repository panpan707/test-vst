using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.BaoCaoQuyHoach
{
    using Vst.Controls;
    using Models;
    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "List of BaoCaoQuyHoach";
            context.TableColumns = new object[] {
                new TableColumn { Name = "TenBaoCao", Caption = "TenBaoCao Header", Width = 100, },
                new TableColumn { Name = "SoHieuVanBan", Caption = "SoHieuVanBan Header", Width = 100, },
                new TableColumn { Name = "NgayBanHanh", Caption = "NgayBanHanh Header", Width = 100, },
                new TableColumn { Name = "CoQuanBanHanh", Caption = "CoQuanBanHanh Header", Width = 100, },
                new TableColumn { Name = "FileDinhKem", Caption = "FileDinhKem Header", Width = 100, },
                new TableColumn { Name = "MoTa", Caption = "MoTa Header", Width = 100, },
            };
        }
    }
    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "BaoCaoQuyHoach Information";
            context.Editors = new object[] {
                new EditorInfo { Name = "KyQuyHoachId", Caption = " Caption of KyQuyHoachId", Layout = 12,
    Type = "select", ValueName = "Id", DisplayName = "FieldName", Options = Provider.Select<KyQuyHoach>(), },
                new EditorInfo { Name = "TenBaoCao", Caption = " Caption of TenBaoCao", Layout = 12,   },
                new EditorInfo { Name = "SoHieuVanBan", Caption = " Caption of SoHieuVanBan", Layout = 12,   },
                new EditorInfo { Name = "NgayBanHanh", Caption = " Caption of NgayBanHanh", Layout = 12,   },
                new EditorInfo { Name = "CoQuanBanHanh", Caption = " Caption of CoQuanBanHanh", Layout = 12,   },
                new EditorInfo { Name = "FileDinhKem", Caption = " Caption of FileDinhKem", Layout = 12,   },
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
