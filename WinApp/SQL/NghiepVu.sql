USE KTPM
GO

-- ====================================================
-- PHẦN DỮ LIỆU NGHIỆP VỤ (BUSINESS DATA)
-- Chạy sau khi đã chạy File 1 (User) và File 2 (Danh mục)
-- ====================================================

-- 1. XÓA DỮ LIỆU CŨ (Để tránh lỗi trùng lặp hoặc khóa ngoại)
DELETE FROM BienDongRung; DBCC CHECKIDENT ('BienDongRung', RESEED, 0);
DELETE FROM LoRung;       DBCC CHECKIDENT ('LoRung', RESEED, 0);
DELETE FROM BaoCao;       DBCC CHECKIDENT ('BaoCao', RESEED, 0);
DELETE FROM DiemThienTai; DBCC CHECKIDENT ('DiemThienTai', RESEED, 0);

-- =============================================
-- 2. DỮ LIỆU LÔ RỪNG (ĐÃ SỬA: THÊM CỘT TenLo)
-- =============================================
INSERT INTO LoRung (
    MaLo, TenLo, -- <--- ĐÃ THÊM TenLo VÀO ĐÂY
    DienTich, TruLuong, NamTrong, NguonGoc, DieuKienLapDia, TrangThaiSuDung, 
    DonViId, LoaiRungId, ChuRungId, GiongCayId, KyQuyHoachId, BanDo,
    DoDocId, DoCaoId, DoDayDatId, GiaTriDoDoc, GiaTriDoCao
) VALUES
-- Lô 1-5: Rừng sản xuất
(N'LR-SX-001', N'Lô Keo lai SX-01', 5.5, 120.5, 2018, N'Rừng trồng', N'Đất đồi thấp', N'Đang khai thác', 8, 1, 1, 1, 2, N'[{"lat":22.1,"lng":105.1},{"lat":22.1,"lng":105.2}]', 1, 4, 7, 10, 200),
(N'LR-SX-002', N'Lô Bạch đàn SX-02', 3.2, 80.0, 2019, N'Rừng trồng', N'Đất cát pha', N'Có rừng', 8, 1, 2, 2, 2, NULL, 1, 4, 7, 12, 250),
(N'LR-SX-003', N'Lô Keo tai tượng SX-03', 10.0, 350.0, 2017, N'Rừng trồng', N'Đất thịt nhẹ', N'Có rừng', 8, 1, 4, 3, 2, NULL, 1, 4, 7, 8, 150),
(N'LR-SX-004', N'Lô Bạch đàn ven sông', 4.8, 95.0, 2020, N'Rừng trồng', N'Ven sông', N'Có rừng', 7, 1, 6, 4, 2, NULL, 1, 4, 7, 5, 100),
(N'LR-SX-005', N'Lô Keo lai đồi gò', 7.5, 150.0, 2018, N'Rừng trồng', N'Đất đồi gò', N'Có rừng', 7, 1, 7, 1, 2, NULL, 2, 5, 6, 20, 400),

-- Lô 6-9: Rừng phòng hộ
(N'LR-PH-006', N'Rừng PH Phi lao ven biển', 20.0, 500.0, 2010, N'Rừng trồng', N'Bãi cát ven biển', N'Có rừng', 7, 2, 5, 2, 2, N'[{"lat":22.5,"lng":105.5}]', 1, 4, 7, 2, 50),
(N'LR-PH-007', N'Rừng PH Ngập mặn', 15.0, 400.0, 2012, N'Rừng trồng', N'Đất ngập mặn', N'Có rừng', 7, 2, 5, 4, 2, NULL, 1, 4, 7, 0, 10),
(N'LR-PH-008', N'Rừng PH Núi đất', 8.0, 200.0, 2015, N'Tự nhiên', N'Núi đất', N'Có rừng', 8, 2, 8, 6, 2, NULL, 3, 5, 7, 35, 800),
(N'LR-PH-009', N'Rừng PH Đất dốc', 12.5, 310.0, 2014, N'Tự nhiên', N'Đất dốc', N'Có rừng', 8, 2, 8, 7, 2, NULL, 3, 5, 7, 28, 600),

-- Lô 10-12: Rừng đặc dụng
(N'LR-DD-010', N'Rừng nguyên sinh Khu A', 50.0, 1200.0, 1990, N'Tự nhiên', N'Rừng nguyên sinh', N'Có rừng', 6, 3, 5, 17, 2, NULL, 3, 5, 6, 40, 1200),
(N'LR-DD-011', N'Rừng núi đá vôi', 25.0, 800.0, 1995, N'Tự nhiên', N'Núi đá vôi', N'Có rừng', 6, 3, 5, 18, 2, NULL, 3, 5, 7, 45, 1500),
(N'LR-DD-012', N'Rừng vùng đệm', 30.0, 900.0, 2000, N'Tự nhiên', N'Vùng đệm', N'Có rừng', 6, 3, 5, 19, 2, NULL, 2, 5, 6, 22, 500),

-- Lô 13-14: Đất trống
(N'LR-DT-013', N'Đất trống đồi trọc', 2.0, 0, NULL, N'Đất trống', N'Đất bỏ hoang', N'Chưa có rừng', 8, 1, 1, NULL, 2, NULL, 1, 4, 7, 5, 100),
(N'LR-DT-014', N'Đất mới khai hoang', 1.5, 0, NULL, N'Đất trống', N'Đất mới khai hoang', N'Chưa có rừng', 7, 1, 3, NULL, 2, NULL, 1, 4, 7, 8, 120);


-- =============================================
-- 3. BIẾN ĐỘNG RỪNG
-- =============================================
INSERT INTO BienDongRung (LoRungId, LoaiBienDong, NgayBienDong, DienTichBienDong, MoTaChiTiet, NguoiCapNhat) VALUES
(1, N'Khai thác trắng', '2023-10-15', 2.0, N'Khai thác theo giấy phép số 123/GP-LN', 'HaoDo'),
(6, N'Sạt lở đất', '2023-09-10', 0.5, N'Sạt lở do bão số 3 gây mất rừng phòng hộ', 'KhangPT'),
(3, N'Cháy rừng', '2023-06-01', 1.2, N'Cháy thực bì do người dân đốt nương làm rẫy', 'HungLe');


-- =============================================
-- 4. ĐIỂM THIÊN TAI (Lũ quét, Sạt lở)
-- =============================================
INSERT INTO DiemThienTai (TenDiem, LoaiThienTai, MucDo, ToaDoX, ToaDoY, MoTa, DonViId) VALUES
(N'Khu vực đê biển số 5', N'Trượt lở', N'Nghiêm trọng', 106.55, 20.45, N'Sạt lở nghiêm trọng chân đê do triều cường', 7),
(N'Ngầm tràn Thụy Xuân', N'Lũ quét', N'Trung bình', 106.60, 20.50, N'Nước dâng cao khi mưa lớn, gây chia cắt', 8),
(N'Khu dân cư Xóm 9', N'Trượt lở', N'Nhẹ', 106.58, 20.48, N'Có hiện tượng nứt đất đồi sau nhà dân', 8),
(N'Cống số 6', N'Lũ Quét', N'Nghiêm trọng', 106.52, 20.42, N'Điểm ngập úng cục bộ trũng thấp', 7);


-- =============================================
-- 5. BÁO CÁO THIÊN TAI
-- =============================================
INSERT INTO BaoCao (TieuDe, NgayBaoCao, NoiDung, NguoiBaoCao, FileDinhKem) VALUES
(N'Báo cáo nhanh tình hình bão số 3', '2024-09-08', N'Bão gây mưa lớn, sạt lở 0.5ha rừng phòng hộ tại Thụy Hải.', 'HungLe', N'bao_cao_bao_so3.pdf'),
(N'Đề xuất phương án trồng rừng thay thế', '2024-10-01', N'Kế hoạch trồng lại 2ha rừng keo tại xã Thụy Xuân.', 'KhangPT', N'ke_hoach_trong_rung.docx'),
(N'Tổng hợp thiệt hại lâm nghiệp năm 2023', '2023-12-31', N'Tổng diện tích rừng bị mất: 5ha. Nguyên nhân chính: Cháy và sạt lở.', 'HuyVu', N'tong_hop_2023.xlsx');

GO