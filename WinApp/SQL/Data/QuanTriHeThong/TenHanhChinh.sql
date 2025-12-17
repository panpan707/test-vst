USE KTPM
GO

-- ====================================================
-- 1. TẠO HÀNH CHÍNH & TÊN HÀNH CHÍNH (Làm sạch trước)
-- ====================================================
DELETE FROM DonVi; -- Xóa bảng con trước
DELETE FROM HanhChinh;
DELETE FROM TenHanhChinh;

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
-- 2. TẠO ĐƠN VỊ (QUAN TRỌNG: CÓ ID 7, 8)
-- ====================================================
SET IDENTITY_INSERT DonVi ON;

INSERT INTO DonVi (Id, Ten, HanhChinhId, TenHanhChinh, TrucThuocId) VALUES 
(1, N'Chi cục Kiểm lâm Tỉnh', 1, N'Tỉnh', NULL),
(2, N'Hạt KL Vị Xuyên', 2, N'Huyện', 1),
(3, N'Hạt KL Bắc Quang', 2, N'Huyện', 1),
(4, N'Trạm KL Phương Tiến', 3, N'Xã', 2),
(5, N'Trạm KL Đồng Tâm', 4, N'Xã', 3),
(6, N'Hạt KL Thái Thụy', 2, N'Huyện', 1),
(7, N'Trạm KL Thụy Hải', 3, N'Xã', 6), -- ID 7 Chuẩn
(8, N'Trạm KL Thụy Xuân', 4, N'Xã', 6); -- ID 8 Chuẩn

SET IDENTITY_INSERT DonVi OFF;

-- ====================================================
-- 3. TẠO KỲ QUY HOẠCH (SỬA LỖI CỦA BẠN TẠI ĐÂY)
-- ====================================================
DELETE FROM KyQuyHoach;
-- Ép ID phải là 1 và 2 để khớp với file Nghiệp vụ
SET IDENTITY_INSERT KyQuyHoach ON; 

INSERT INTO KyQuyHoach (Id, TenKy, TrangThai) VALUES 
(1, N'Quy hoạch 2020-2025', 1),
(2, N'Quy hoạch 2025-2030', 0); -- Bắt buộc có số 2

SET IDENTITY_INSERT KyQuyHoach OFF;

-- ====================================================
-- 4. TẠO LOẠI RỪNG
-- ====================================================
DELETE FROM LoaiRung;
SET IDENTITY_INSERT LoaiRung ON;

INSERT INTO LoaiRung (Id, TenLoai, MaLoai) VALUES 
(1, N'Rừng sản xuất', 'RSX'),
(2, N'Rừng phòng hộ', 'RPH'),
(3, N'Rừng đặc dụng', 'RDD');

SET IDENTITY_INSERT LoaiRung OFF;

-- ====================================================
-- 5. TẠO CHỦ RỪNG
-- ====================================================
DELETE FROM ChuRung;
SET IDENTITY_INSERT ChuRung ON;

INSERT INTO ChuRung (Id, TenChuRung, LoaiChuSoHuu) VALUES 
(1, N'Hộ gia đình ông A', N'Hộ gia đình'),
(2, N'Công ty Lâm Nghiệp B', N'Doanh nghiệp'),
(3, N'Ban QL Rừng Vị Xuyên', N'Ban quản lý'),
(4, N'Chủ rừng D', NULL),
(5, N'Chủ rừng E', NULL),
(6, N'Chủ rừng F', NULL),
(7, N'Chủ rừng G', NULL),
(8, N'Chủ rừng H', NULL);

SET IDENTITY_INSERT ChuRung OFF;

-- ====================================================
-- 6. TẠO GIỐNG CÂY
-- ====================================================
DELETE FROM GiongCay;
SET IDENTITY_INSERT GiongCay ON;

INSERT INTO GiongCay (Id, Ten) VALUES 
(1, N'Keo tai tượng'), (2, N'Keo lá tràm'), (3, N'Keo lai'), (4, N'Bạch đàn'), (5, N'Phi lao'),
(6, N'Thông ba lá'), (7, N'Thông mã vĩ'), (8, N'Sao đen'), (9, N'Dầu rái'), (10, N'Lát hoa'),
(11, N'Xoan đào'), (12, N'Mỡ'), (13, N'Bồ đề'), (14, N'Quế'), (15, N'Hồi'), (16, N'Trẩu'), 
(17, N'Lim xanh'), (18, N'Sưa đỏ'), (19, N'Pơ mu');

SET IDENTITY_INSERT GiongCay OFF;
GO