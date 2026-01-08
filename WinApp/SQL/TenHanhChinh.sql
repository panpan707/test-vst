USE KTPM
GO

-- ====================================================
-- 0. LÀM SẠCH DỮ LIỆU CŨ (THEO THỨ TỰ ĐỂ KHÔNG LỖI KHÓA NGOẠI)
-- ====================================================
DELETE FROM BienDongRung;
DELETE FROM LoRung; -- Xóa Lô rừng trước khi xóa các bảng danh mục
DELETE FROM BanDoQuyHoach;
DELETE FROM BaoCaoQuyHoach;
DELETE FROM KyQuyHoach;
DELETE FROM ThuocTinhLoDat; -- Bảng mới
DELETE FROM GiongCay;
DELETE FROM ChuRung;
DELETE FROM LoaiRung;
DELETE FROM DonVi;
DELETE FROM HanhChinh;
DELETE FROM TenHanhChinh;

-- ====================================================
-- 1. TẠO HÀNH CHÍNH & TÊN HÀNH CHÍNH
-- ====================================================
DBCC CHECKIDENT ('HanhChinh', RESEED, 0); 
INSERT INTO TenHanhChinh (Ten) VALUES (N'Tỉnh'), (N'Huyện'), (N'Xã');

INSERT INTO HanhChinh (Ten, TrucThuocId) VALUES 
(N'Tỉnh Hà Giang', NULL),   -- Id 1
(N'Huyện Vị Xuyên', 1),     -- Id 2
(N'Huyện Bắc Quang', 1),    -- Id 3
(N'Xã Phương Tiến', 2),     -- Id 4
(N'Xã Thanh Thủy', 2),      -- Id 5
(N'Xã Đồng Tâm', 3),        -- Id 6
(N'Xã Tân Quang', 3);       -- Id 7

-- ====================================================
-- 2. TẠO ĐƠN VỊ
-- ====================================================
SET IDENTITY_INSERT DonVi ON;

INSERT INTO DonVi (Id, Ten, HanhChinhId, TenHanhChinh, TrucThuocId) VALUES 
(1, N'Chi cục Kiểm lâm Tỉnh', 1, N'Tỉnh', NULL),
(2, N'Hạt KL Vị Xuyên', 2, N'Huyện', 1),
(3, N'Hạt KL Bắc Quang', 2, N'Huyện', 1),
(4, N'Trạm KL Phương Tiến', 3, N'Xã', 2),
(5, N'Trạm KL Đồng Tâm', 4, N'Xã', 3),
(6, N'Hạt KL Thái Thụy', 2, N'Huyện', 1),
(7, N'Trạm KL Thụy Hải', 3, N'Xã', 6), 
(8, N'Trạm KL Thụy Xuân', 4, N'Xã', 6);

SET IDENTITY_INSERT DonVi OFF;

-- ====================================================
-- 3. TẠO THUỘC TÍNH LÔ ĐẤT (BẮT BUỘC CHO BẢNG MỚI)
-- ====================================================
-- Cần tạo dữ liệu này trước khi tạo Lô Rừng
SET IDENTITY_INSERT ThuocTinhLoDat ON;

INSERT INTO ThuocTinhLoDat (Id, TenThuocTinh, NhomThuocTinh, MoTa) VALUES 
(1, N'Dốc nhẹ (<15 độ)', 'DoDoc', N'Thoải'),
(2, N'Dốc vừa (15-25 độ)', 'DoDoc', N'Trung bình'),
(3, N'Dốc đứng (>25 độ)', 'DoDoc', N'Hiểm trở'),
(4, N'Thấp (<500m)', 'DoCao', N'Vùng thấp'),
(5, N'Cao (>500m)', 'DoCao', N'Vùng cao'),
(6, N'Đất dày (>50cm)', 'DoDayDat', N'Tốt cho cây'),
(7, N'Đất mỏng (<50cm)', 'DoDayDat', N'Cằn cỗi');

SET IDENTITY_INSERT ThuocTinhLoDat OFF;

-- ====================================================
-- 4. TẠO KỲ QUY HOẠCH (ĐÃ CẬP NHẬT CỘT MỚI)
-- ====================================================
SET IDENTITY_INSERT KyQuyHoach ON; 

-- Thêm TuNam, DenNam, MoTa cho khớp bảng mới
INSERT INTO KyQuyHoach (Id, TenKy, TuNam, DenNam, MoTa, TrangThai) VALUES 
(1, N'Quy hoạch 2020-2025', 2020, 2025, N'Giai đoạn ổn định phát triển', 1),
(2, N'Quy hoạch 2025-2030', 2025, 2030, N'Giai đoạn mở rộng quy mô', 0);

SET IDENTITY_INSERT KyQuyHoach OFF;

-- ====================================================
-- 5. TẠO CÁC BẢNG CON CỦA QUY HOẠCH (BẢNG MỚI)
-- ====================================================
INSERT INTO BanDoQuyHoach (KyQuyHoachId, TenBanDo, LoaiBanDo, TyLe, MoTa) VALUES
(1, N'Bản đồ hiện trạng 2020', N'Hiện trạng', N'1:10000', N'Bản đồ gốc'),
(1, N'Bản đồ quy hoạch sử dụng đất', N'Quy hoạch', N'1:25000', N'Phân khu chức năng');

INSERT INTO BaoCaoQuyHoach (KyQuyHoachId, TenBaoCao, SoHieuVanBan, NgayBanHanh, CoQuanBanHanh) VALUES
(1, N'Quyết định phê duyệt QH Tỉnh', N'QD-UBND/2020', '2020-01-15', N'UBND Tỉnh Hà Giang');


-- ====================================================
-- 6. TẠO LOẠI RỪNG
-- ====================================================
SET IDENTITY_INSERT LoaiRung ON;

INSERT INTO LoaiRung (Id, TenLoai, MaLoai, MoTa) VALUES 
(1, N'Rừng sản xuất', 'RSX', N'Rừng trồng kinh tế'),
(2, N'Rừng phòng hộ', 'RPH', N'Bảo vệ đầu nguồn'),
(3, N'Rừng đặc dụng', 'RDD', N'Vườn quốc gia');

SET IDENTITY_INSERT LoaiRung OFF;

-- ====================================================
-- 7. TẠO CHỦ RỪNG
-- ====================================================
SET IDENTITY_INSERT ChuRung ON;

-- Thêm dummy data cho các cột mới (DiaChi, SDT)
INSERT INTO ChuRung (Id, TenChuRung, LoaiChuSoHuu, DiaChi, SoDienThoai) VALUES 
(1, N'Hộ gia đình ông A', N'Hộ gia đình', N'Thôn 1, Vị Xuyên', '0912345678'),
(2, N'Công ty Lâm Nghiệp B', N'Doanh nghiệp', N'TP Hà Giang', '0987654321'),
(3, N'Ban QL Rừng Vị Xuyên', N'Ban quản lý', N'Vị Xuyên', '02193888888'),
(4, N'Chủ rừng D', NULL, NULL, NULL),
(5, N'Chủ rừng E', NULL, NULL, NULL),
(6, N'Chủ rừng F', NULL, NULL, NULL),
(7, N'Chủ rừng G', NULL, NULL, NULL),
(8, N'Chủ rừng H', NULL, NULL, NULL);

SET IDENTITY_INSERT ChuRung OFF;

-- ====================================================
-- 8. TẠO GIỐNG CÂY (ĐÃ CẬP NHẬT CỘT MỚI)
-- ====================================================
SET IDENTITY_INSERT GiongCay ON;

-- Thêm Nguon, DacTinh, LoaiCay cho khớp bảng mới
INSERT INTO GiongCay (Id, Ten, Nguon, DacTinh, LoaiCay) VALUES 
(1, N'Keo tai tượng', N'Viện KH Lâm nghiệp', N'Sinh trưởng nhanh', N'Gỗ nhỏ'),
(2, N'Keo lá tràm', N'Địa phương', N'Chịu hạn tốt', N'Gỗ nhỏ'),
(3, N'Keo lai', N'Nhập khẩu', N'Chống sâu bệnh', N'Gỗ nguyên liệu'),
(4, N'Bạch đàn', N'Viện KH Lâm nghiệp', N'Thẳng, ít cành', N'Gỗ nhỏ'),
(5, N'Phi lao', N'Địa phương', N'Chắn gió cát', N'Phòng hộ'),
(6, N'Thông ba lá', N'Đà Lạt', N'Nhựa nhiều', N'Gỗ lớn'),
(7, N'Thông mã vĩ', N'Đông Bắc', N'Sinh trưởng chậm', N'Gỗ lớn'),
(8, N'Sao đen', N'Nam Bộ', N'Gỗ quý', N'Gỗ lớn'),
(9, N'Dầu rái', NULL, NULL, N'Gỗ lớn'),
(10, N'Lát hoa', NULL, NULL, N'Gỗ quý'),
(11, N'Xoan đào', NULL, NULL, N'Gỗ lớn'), 
(12, N'Mỡ', NULL, NULL, N'Gỗ nhỏ'), 
(13, N'Bồ đề', NULL, NULL, N'Gỗ nhỏ'), 
(14, N'Quế', NULL, NULL, N'Lâm sản ngoài gỗ'), 
(15, N'Hồi', NULL, NULL, N'Lâm sản ngoài gỗ'), 
(16, N'Trẩu', NULL, NULL, N'Gỗ nhỏ'), 
(17, N'Lim xanh', NULL, NULL, N'Gỗ quý'), 
(18, N'Sưa đỏ', NULL, NULL, N'Gỗ quý'), 
(19, N'Pơ mu', NULL, NULL, N'Gỗ quý');

SET IDENTITY_INSERT GiongCay OFF;

