USE KTPM
GO

-- =============================================
-- 1. HỒ SƠ NGƯỜI DÙNG (User Profile)
-- =============================================
DELETE FROM HoSo; DBCC CHECKIDENT ('HoSo', RESEED, 0);

INSERT INTO HoSo (Ten, SDT, Email, Ext) VALUES
(N'Vũ Song Tùng', '0989154248', 'tung.vusong@hust.edu.vn', N'Giảng viên hướng dẫn/Guest'),
(N'Đào Lê Thu Thảo', '0989708960', 'thao.daolethu@hust.edu.vn', N'Giảng viên/Guest'),
(N'Nguyễn Hà Phan', '090123822', 'admin@ktpm.com', N'Dev'),
(N'Vũ Quang Huy', '0900000000', 'canbo@lamnghiep.gov.vn', N'admin'),
(N'Phan Trường Khang', '0911111111', 'mail1@gmail.com',N'Quản trị viên hệ thống'),
(N'Lê Triệu Hưng', '094444441', 'mail2@gmail.com',N'Quản trị viên hệ thống'),
(N'Đỗ Xuân Hào', '093333333', 'mail3@gmail.com',N'Quản trị viên hệ thống');
-- =============================================
-- 2. QUYỀN HẠN (Roles)
-- =============================================
DELETE FROM Quyen; DBCC CHECKIDENT ('Quyen', RESEED, 0);

INSERT INTO Quyen (Ten, Ext) VALUES
(N'Developer', 'Developer'),
(N'Admin', 'Admin'),
(N'Staff', 'Staff');


-- =============================================
-- 3. TÀI KHOẢN ĐĂNG NHẬP (Accounts)
-- =============================================
DELETE FROM TaiKhoan; 

INSERT INTO TaiKhoan (Ten, MatKhau, QuyenId, HoSoId) VALUES
-- Pass '1234' là ví dụ, thực tế nên mã hóa
('PhanNguyen', '1234', 1, 3),        -- Tài khoản Dev 
('HuyVu', '1234', 2, 4),      -- Tài khoản Admin
('KhangPT', '1234', 3, 5),      -- Tài khoản Cán bộ
('HungLe', '1234', 3, 6), 
('HaoDo', '1234', 3, 7) ,
('VST', '1234', 3, 1) , 
('DLTT', '1234',3, 2); 

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
