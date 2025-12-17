USE KTPM
GO

DELETE FROM LichSuTacDong; -- Nếu có
DELETE FROM LichSuTruyCap;
DELETE FROM BaoCao;        -- Vì Báo cáo cũng dính đến Tài khoản
DELETE FROM TaiKhoan;

-- Sau khi xóa hết bảng con, mới được xóa bảng cha
DELETE FROM Quyen;
DELETE FROM HoSo;

DBCC CHECKIDENT ('HoSo', RESEED, 0);
DBCC CHECKIDENT ('Quyen', RESEED, 0);
DBCC CHECKIDENT ('LichSuTruyCap', RESEED, 0);
-- =============================================
-- 1. HỒ SƠ NGƯỜI DÙNG (User Profile)
-- =============================================

INSERT INTO HoSo (Ten, SDT, Email, Ext) VALUES
(N'Vũ Song Tùng', '0989154248', 'tung.vusong@hust.edu.vn', N'Giảng viên hướng dẫn/Guest'),
(N'Đào Lê Thu Thảo', '0989708960', 'thao.daolethu@hust.edu.vn', N'Giảng viên/Guest'),
(N'Nguyễn Hà Phan', '090123822', 'phan@gmail.com', N'Dev'),
(N'Vũ Quang Huy', '0900000000', 'huy@gmail.com', N'admin'),
(N'Phan Trường Khang', '0911111111', 'khang@gmail.com',N'Quản trị viên hệ thống'),
(N'Lê Triệu Hưng', '094444441', 'hung@gmail.com',N'Quản trị viên hệ thống'),
(N'Đỗ Xuân Hào', '093333333', 'hao@gmail.com',N'Quản trị viên hệ thống');
-- =============================================
-- 2. QUYỀN HẠN (Roles)
-- =============================================

INSERT INTO Quyen (Ten, Ext) VALUES
(N'Developer', 'Developer'),
(N'Admin', 'Admin'),
(N'Staff', 'Staff');


-- =============================================
-- 3. TÀI KHOẢN ĐĂNG NHẬP (Accounts)
-- =============================================

INSERT INTO TaiKhoan (Ten, MatKhau, QuyenId, HoSoId) VALUES
(
    'PhanNguyen', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Developer'), 
    (SELECT Id FROM HoSo WHERE Email = 'phan@gmail.com')
),
(
    'HuyVu', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Admin'), 
    (SELECT Id FROM HoSo WHERE Email = 'huy@gmail.com')
),
(
    'KhangPT', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Staff'), 
    (SELECT Id FROM HoSo WHERE Email = 'khang@gmail.com')
),
(
    'HungLe', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Staff'), 
    (SELECT Id FROM HoSo WHERE Email = 'hung@gmail.com')
),
(
    'HaoDo', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Staff'), 
    (SELECT Id FROM HoSo WHERE Email = 'hao@gmail.com')
),
(
    'VST', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Developer'), 
    (SELECT Id FROM HoSo WHERE Email = 'tung.vusong@hust.edu.vn')
),
(
    'DLTT', '1234', 
    (SELECT Id FROM Quyen WHERE Ten = 'Staff'), 
    (SELECT Id FROM HoSo WHERE Email = 'thao.daolethu@hust.edu.vn')
);
-- =============================================
-- 4. LỊCH SỬ TRUY CẬP (Sample Logs)
-- =============================================
-- Nếu bạn đã tạo bảng LichSuTruyCap ở bước trước
IF OBJECT_ID('dbo.LichSuTruyCap', 'U') IS NOT NULL
BEGIN
    DELETE FROM LichSuTruyCap; DBCC CHECKIDENT ('LichSuTruyCap', RESEED, 0);

    INSERT INTO LichSuTruyCap (TaiKhoan, ThoiGian, HanhDong, IPAddress) VALUES
    ('PhanNguyen', DATEADD(HOUR, -1, GETDATE()), N'Đăng nhập hệ thống', '192.168.1.10'),
    ('HuyVu', DATEADD(MINUTE, -30, GETDATE()), N'Cập nhật bảng Lô Rừng', '127.0.0.1'),
    ('HaoDo', DATEADD(MINUTE, -5, GETDATE()), N'Xem báo cáo thiên tai', '192.168.1.15');
END
