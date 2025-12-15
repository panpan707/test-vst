USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'KTPM')
BEGIN
    ALTER DATABASE KTPM SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE KTPM;
END
GO
CREATE DATABASE KTPM
GO
USE KTPM
GO

-- =============================================
-- PHẦN 1: QUẢN TRỊ HỆ THỐNG (FRAMEWORK CỦA GIÁO VIÊN)
-- Đáp ứng mục 1.1 -> 1.30
-- =============================================

CREATE TABLE HoSo (
    Id int primary key identity,
    Ten nvarchar(50),
    SDT varchar(50),
    Email varchar(50),
    Ext text
)
GO

CREATE TABLE Quyen ( -- Đáp ứng 1.8, 1.9
    Id int primary key identity,
    Ten nvarchar(50),
    Ext varchar(50)
)
GO

CREATE TABLE TaiKhoan ( -- Đáp ứng 1.5, 1.25, 1.27
    Ten varchar(50) primary key,
    MatKhau varchar(255),
    QuyenId int foreign key references Quyen(Id),
    HoSoId int foreign key references HoSo(Id)
)
GO

-- Bảng Log hệ thống (Đáp ứng 1.17 - 1.20)
CREATE TABLE LichSuTruyCap (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan VARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(Ten),
    ThoiGian DATETIME DEFAULT GETDATE(),
    HanhDong NVARCHAR(255), -- Ví dụ: Đăng nhập, Xem báo cáo
    IPAddress VARCHAR(50) NULL
)
GO

CREATE TABLE HanhChinh (
    Id int primary key identity,
    Ten nvarchar(50),
    TrucThuocId int foreign key references HanhChinh(Id)
)
GO

CREATE TABLE TenHanhChinh (
    Ten nvarchar(50)
)
GO

CREATE TABLE DonVi ( -- Đáp ứng 1.1 -> 1.4
    Id int primary key identity,
    Ten nvarchar(50),
    HanhChinhId int foreign key references HanhChinh(Id),
    TenHanhChinh nvarchar(50),
    TrucThuocId int foreign key references DonVi(Id)
)
GO

-- =============================================
-- PHẦN 2: QUẢN LÝ TÀI NGUYÊN RỪNG (MODULE NGHIỆP VỤ)
-- =============================================

-- 2.1 QUẢN LÝ QUY HOẠCH (Đáp ứng 2.1.1 - 2.1.3)
CREATE TABLE KyQuyHoach (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenKy NVARCHAR(100) NOT NULL, -- Ví dụ: Quy hoạch 2020-2025
    TuNam INT,
    DenNam INT,
    MoTa NVARCHAR(MAX),
    TrangThai BIT DEFAULT 1 -- 1: Đang hiệu lực, 0: Hết hạn
)
GO

-- 2.2 DANH MỤC LÂM NGHIỆP (Đáp ứng 2.2.x)
CREATE TABLE GiongCay ( -- Đáp ứng 2.2.17, 2.2.19
    Id int primary key identity,
    Ten nvarchar(50),
    Nguon nvarchar(255),
    DacTinh NVARCHAR(MAX) NULL,
    LoaiCay NVARCHAR(50) NULL -- Gỗ lớn, Gỗ nhỏ, Lâm sản ngoài gỗ
)
GO

CREATE TABLE LoaiRung ( -- Đáp ứng 2.2.1 - 2.2.6
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(255) NOT NULL, -- Rừng phòng hộ, Đặc dụng...
    MaLoai VARCHAR(50) NULL,
    MoTa NVARCHAR(MAX) NULL
)
GO

CREATE TABLE ChuRung ( -- Đáp ứng 2.2.10 - 2.2.12
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenChuRung NVARCHAR(255) NOT NULL,
    LoaiChuSoHuu NVARCHAR(100) NULL, -- Hộ gia đình, Doanh nghiệp...
    DiaChi NVARCHAR(MAX) NULL,
    SoDienThoai NVARCHAR(20) NULL
)
GO

-- 2.3 HIỆN TRẠNG RỪNG & THUỘC TÍNH LÔ (Đáp ứng 2.2.13 - 2.2.21)
CREATE TABLE LoRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaLo NVARCHAR(50) NOT NULL,
    
    -- Thông tin diện tích & trữ lượng (2.2.18)
    DienTich FLOAT NOT NULL, -- Đơn vị: ha
    TruLuong FLOAT NULL,     -- Đơn vị: m3
    NamTrong INT NULL,
    
    -- Các thuộc tính chi tiết (Mới thêm)
    NguonGoc NVARCHAR(50) NULL,      -- Tự nhiên / Trồng (2.2.13 - 2.2.15)
    DieuKienLapDia NVARCHAR(255) NULL, -- Đất đồi, núi đá, ngập mặn (2.2.16)
    TrangThaiSuDung NVARCHAR(100) DEFAULT N'Có rừng', -- Có rừng / Chưa có rừng (2.2.24)
    
    -- Khóa ngoại
    DonViId INT FOREIGN KEY REFERENCES DonVi(Id),
    LoaiRungId INT FOREIGN KEY REFERENCES LoaiRung(Id),
    ChuRungId INT FOREIGN KEY REFERENCES ChuRung(Id),
    GiongCayId INT FOREIGN KEY REFERENCES GiongCay(Id),
    KyQuyHoachId INT FOREIGN KEY REFERENCES KyQuyHoach(Id) -- Thuộc kỳ quy hoạch nào
)
GO

-- 2.4 BIẾN ĐỘNG RỪNG (Đáp ứng 2.2.22 - 2.2.23)
-- Theo dõi lịch sử: Cháy rừng, Khai thác, Trồng mới...
CREATE TABLE BienDongRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LoRungId INT FOREIGN KEY REFERENCES LoRung(Id),
    NgayBienDong DATETIME DEFAULT GETDATE(),
    LoaiBienDong NVARCHAR(100), -- Cháy, Chặt phá, Trồng mới
    DienTichBienDong FLOAT,
    MoTaChiTiet NVARCHAR(MAX),
    NguoiCapNhat VARCHAR(50) -- Link với TaiKhoan(Ten) nếu cần
)
GO

-- =============================================
-- PHẦN 3: QUẢN LÝ THIÊN TAI (Đáp ứng 2.3 - 2.8)
-- =============================================

CREATE TABLE DiemThienTai ( -- Đáp ứng 2.3 - 2.6
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenDiem NVARCHAR(255) NOT NULL,
    LoaiThienTai NVARCHAR(50) NOT NULL, -- 'TruotLo' hoặc 'LuQuet'
    MucDo NVARCHAR(50) NULL,
    ToaDoX FLOAT NULL, 
    ToaDoY FLOAT NULL,
    MoTa NVARCHAR(MAX) NULL,
    DonViId INT FOREIGN KEY REFERENCES DonVi(Id)
)
GO

CREATE TABLE BaoCao ( -- Đáp ứng 2.7 - 2.8
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(255) NOT NULL,
    NgayBaoCao DATETIME DEFAULT GETDATE(),
    NoiDung NVARCHAR(MAX) NULL,
    FileDinhKem NVARCHAR(MAX) NULL, -- Đường dẫn file
    NguoiBaoCao VARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(Ten)
)
GO

-- =============================================
-- PHẦN 4: VIEWS HỖ TRỢ (FRAMEWORK)
-- =============================================

EXEC('CREATE VIEW ViewHoSo AS
    SELECT HoSo.*, TaiKhoan.Ten as TenDangNhap, MatKhau, QuyenId, Quyen.Ten as Quyen 
    FROM TaiKhoan
    INNER JOIN Quyen ON QuyenId = Quyen.Id
    INNER JOIN HoSo ON HoSoId = HoSo.Id')
GO

EXEC('CREATE VIEW ViewDonVi AS
    SELECT T.*, DonVi.Ten as TrucThuoc FROM
        (SELECT DonVi.*, HanhChinh.Ten as Cap FROM DonVi 
        inner join HanhChinh ON HanhChinhId = HanhChinh.Id) as T
    left join DonVi ON T.TrucThuocId = DonVi.Id')
GO