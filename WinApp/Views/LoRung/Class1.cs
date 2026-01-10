using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Views.LoRung
{
    using Vst.Controls;
    using Models;

    class Index : BaseView<DataListViewLayout>
    {
        protected override void RenderCore(ViewContext context)
        {
            base.RenderCore(context); // Nên gọi base để khởi tạo các thông số mặc định
            context.Title = "Danh sách Lô Rừng";
            var listThuocTinh = Provider.Select<ThuocTinhLoDat>();
            var dictLoaiRung = Provider.Select<LoaiRung>()
                                       .ToDictionary(x => x.Id, x => x.TenLoai.ToLower());
            // Cấu hình cột hiển thị
            context.TableColumns = new object[] {
                new TableColumn { Name = "MaLo", Caption = "Mã Lô", Width = 100, },
                new TableColumn { Name = "TenLo", Caption = "Tên Lô", Width = 150, },
                new TableColumn { Name = "ChuRungId", Caption = "Mã Chủ Rừng", Width = 100 },
                new TableColumn { Name = "DienTich", Caption = "Diện Tích", Width = 100, },
                new TableColumn { Name = "TruLuong", Caption = "Trữ Lượng", Width = 100, },
                new TableColumn { Name = "NamTrong", Caption = "Năm Trồng", Width = 100, },
                new TableColumn { Name = "NguonGoc", Caption = "Nguồn Gốc", Width = 150, },
                new TableColumn { Name = "DieuKienLapDia", Caption = "Điều Kiện Lập Địa", Width = 150, },
                new TableColumn { Name = "TrangThaiSuDung", Caption = "Trạng Thái", Width = 120, },
                new TableColumn { Name = "GiaTriDoDoc", Caption = "Độ Dốc", Width = 100, },
                new TableColumn { Name = "GiaTriDoCao", Caption = "Độ Cao", Width = 100, },
            };

         
            context.Search = (o, s) =>
            {
                var e = (Models.LoRung)o; 
                var k = s.ToLower(); // Chuyển từ khóa về chữ thường để so sánh

                // check xem từ khóa có nằm trong không
             
                bool matchBasic = (e.MaLo != null && e.MaLo.ToLower().Contains(k))
                    || (e.TenLo != null && e.TenLo.ToLower().Contains(k))
                    || (e.NguonGoc != null && e.NguonGoc.ToLower().Contains(k))
                    || (e.DieuKienLapDia != null && e.DieuKienLapDia.ToLower().Contains(k));

                if (matchBasic) return true;

                // Tìm theo loại rừng
                if (e.LoaiRungId != null && dictLoaiRung.ContainsKey((int)e.LoaiRungId))
                {
                    // Lấy tên loại rừng từ từ điển ra để so sánh
                    string tenLoai = dictLoaiRung[(int)e.LoaiRungId];
                    if (tenLoai.Contains(k)) return true;
                }

                return false;
                /* var matchingIds = listThuocTinh
                     .Where(t => (t.TenThuocTinh != null && t.TenThuocTinh.ToLower().Contains(k)) 
                              || (t.MoTa != null && t.MoTa.ToLower().Contains(k)))
                     .Select(t => t.Id)
                     .ToList();

                 // Kiểm tra xem các chỉ số của Lô rừng có nằm trong danh sách ID tìm được không
                 if (matchingIds.Count > 0)
                 {
                     if (e.DoDocId != null && matchingIds.Contains((int)e.DoDocId)) return true;
                     if (e.DoCaoId != null && matchingIds.Contains((int)e.DoCaoId)) return true;
                     if (e.DoDayDatId != null && matchingIds.Contains((int)e.DoDayDatId)) return true;
                 }

                 return false;
               // có thể sử dụng nhưng rất lag
               */
            };
        }
    }

    class Add : EditView
    {
        protected override void RenderCore(ViewContext context)
        {
            context.Title = "Thông tin Lô Rừng";
            context.Editors = new object[] {
                new EditorInfo { Name = "MaLo", Caption = "Mã Lô", Layout = 6,   },
                new EditorInfo { Name = "TenLo", Caption = "Tên Lô", Layout = 6,   },
                new EditorInfo {
                    Name = "ChuRungId",
                    Caption = "Chủ sở hữu rừng",
                    Layout = 6,
                    Type = "select",
                    ValueName = "Id",
                    DisplayName = "TenChuRung", 
                    Options = Provider.Select<ChuRung>()
                },

                new EditorInfo { Name = "BanDo", Caption = "Bản Đồ", Layout = 6,   },
                new EditorInfo { Name = "DienTich", Caption = "Diện Tích", Layout = 6,   },
                new EditorInfo { Name = "TruLuong", Caption = "Trữ Lượng", Layout = 6,   },
                new EditorInfo { Name = "NamTrong", Caption = "Năm Trồng", Layout = 6,   },
                new EditorInfo { Name = "NguonGoc", Caption = "Nguồn Gốc", Layout = 6,   },
                new EditorInfo { Name = "DieuKienLapDia", Caption = "Điều Kiện Lập Địa", Layout = 6,   },
                new EditorInfo { Name = "TrangThaiSuDung", Caption = "Trạng Thái Sử Dụng", Layout = 6,   },

                // Các dropdown select box
                new EditorInfo { Name = "DonViId", Caption = "Đơn Vị", Layout = 6,
                    Type = "select", ValueName = "Id", DisplayName = "Ten", Options = Provider.Select<DonVi>(), },

                new EditorInfo { Name = "LoaiRungId", Caption = "Loại Rừng", Layout = 6,
                    Type = "select", ValueName = "Id", DisplayName = "TenLoai", Options = Provider.Select<LoaiRung>(), },

                new EditorInfo { Name = "GiongCayId", Caption = "Giống Cây", Layout = 6,
                    Type = "select", ValueName = "Id", DisplayName = "Ten", Options = Provider.Select<GiongCay>(), },

                new EditorInfo { Name = "KyQuyHoachId", Caption = "Kỳ Quy Hoạch", Layout = 6,
                    Type = "select", ValueName = "Id", DisplayName = "TenKy", Options = Provider.Select<KyQuyHoach>(), },
                
                // Thuộc tính lô đất

                new EditorInfo { Name = "GiaTriDoDoc", Caption = "Giá Trị Độ Dốc", Layout = 6,   },
                new EditorInfo { Name = "GiaTriDoCao", Caption = "Giá Trị Độ Cao", Layout = 6,   },
            };
        }
    }

    class Edit : Add
    {
        protected override void OnReady()
        {
            // Hiển thị tên lô khi hỏi xóa
            ShowDeleteAction("TenLo");

            // Cấm sửa Mã Lô khi đang ở chế độ Edit (tùy logic của bạn)
            Find("MaLo", c => c.IsEnabled = false);
        }
    }
}