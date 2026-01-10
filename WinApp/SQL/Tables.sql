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

-- =======================================================
-- PHẦN 1: QUẢN TRỊ HỆ THỐNG (GIỮ NGUYÊN GỐC CỦA BẠN)
-- =======================================================

CREATE TABLE HoSo (
    Id int primary key identity,
    Ten nvarchar(50),
    SDT varchar(50),
    Email varchar(50),
    Ext text
)
GO

CREATE TABLE Quyen (
    Id int primary key identity,
    Ten nvarchar(50),
    Ext varchar(50)
)
GO

-- Lưu ý: BaseController thường cần cột "Id". 
-- Bảng này dùng "Ten" làm PK, cần chú ý khi code Controller.
CREATE TABLE TaiKhoan (
    Ten varchar(50) primary key, 
    MatKhau varchar(255),
    QuyenId int foreign key references Quyen(Id),
    HoSoId int foreign key references HoSo(Id)
)
GO

CREATE TABLE LichSuTruyCap (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan VARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(Ten),
    ThoiGian DATETIME DEFAULT GETDATE(),
    HanhDong NVARCHAR(255),
    IPAddress VARCHAR(50) NULL
)
GO

-- Bảng này cần khớp với BaseController đoạn Ghi Log
CREATE TABLE LichSuTacDong (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NguoiThucHien VARCHAR(50), 
    ThoiGian DATETIME DEFAULT GETDATE(),
    BangTacDong NVARCHAR(50),  
    IdBanGhi INT,
    LoaiTacDong NVARCHAR(20),  
    NoiDungThayDoi NVARCHAR(MAX) 
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

CREATE TABLE DonVi (
    Id int primary key identity,
    Ten nvarchar(50),
    HanhChinhId int foreign key references HanhChinh(Id),
    TenHanhChinh nvarchar(50),
    TrucThuocId int foreign key references DonVi(Id)
)
GO

-- =======================================================
-- PHẦN 2: CÁC BẢNG MỚI & CẬP NHẬT (KHỚP MODEL C#)
-- =======================================================

-- 2.1. Bảng Thuộc Tính Lô Đất (MỚI)
-- Dùng để lưu danh mục: Độ dốc, Độ cao, Độ dày tầng đất
CREATE TABLE ThuocTinhLoDat (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenThuocTinh NVARCHAR(200),
    NhomThuocTinh NVARCHAR(100), -- VD: 'DoDoc', 'DoCao', 'DoDay'
    MoTa NVARCHAR(MAX)
)
GO

-- 2.2. KyQuyHoach (CẬP NHẬT)
CREATE TABLE KyQuyHoach (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenKy NVARCHAR(100),
    TuNam INT,
    DenNam INT,
    MoTa NVARCHAR(MAX),
    TrangThai BIT DEFAULT 1
)
GO

-- 2.3. BanDoQuyHoach (MỚI - Khớp Model)
CREATE TABLE BanDoQuyHoach (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    KyQuyHoachId INT FOREIGN KEY REFERENCES KyQuyHoach(Id),
    TenBanDo NVARCHAR(200),
    LoaiBanDo NVARCHAR(100),
    TyLe NVARCHAR(50),
    DuLieuBanDo NVARCHAR(MAX), -- Lưu đường dẫn file hoặc Base64
    MoTa NVARCHAR(MAX)
)
GO

-- 2.4. BaoCaoQuyHoach (MỚI - Khớp Model)
CREATE TABLE BaoCaoQuyHoach (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    KyQuyHoachId INT FOREIGN KEY REFERENCES KyQuyHoach(Id),
    TenBaoCao NVARCHAR(200),
    SoHieuVanBan NVARCHAR(50),
    NgayBanHanh DATETIME,
    CoQuanBanHanh NVARCHAR(200),
    FileDinhKem NVARCHAR(MAX),
    MoTa NVARCHAR(MAX)
)
GO

-- 2.5. Các danh mục con
CREATE TABLE GiongCay (
    Id int primary key identity,
    Ten nvarchar(200), -- Tăng độ rộng
    Nguon nvarchar(255),
    DacTinh NVARCHAR(MAX),
    LoaiCay NVARCHAR(50)
)
GO

CREATE TABLE LoaiRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(255),
    MaLoai VARCHAR(50),
    MoTa NVARCHAR(MAX)
)
GO

CREATE TABLE ChuRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenChuRung NVARCHAR(255),
    LoaiChuSoHuu NVARCHAR(100),
    DiaChi NVARCHAR(MAX),
    SoDienThoai NVARCHAR(20)
)
GO

-- 2.6. LoRung (CẬP NHẬT NHIỀU CỘT MỚI)
CREATE TABLE LoRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaLo NVARCHAR(50) NOT NULL,
    TenLo NVARCHAR(200),
    BanDo NVARCHAR(MAX),
    DienTich FLOAT,
    TruLuong FLOAT,
    NamTrong INT,
    NguonGoc NVARCHAR(200),
    DieuKienLapDia NVARCHAR(255),
    TrangThaiSuDung NVARCHAR(100) DEFAULT N'Có rừng',
    
    -- Khóa ngoại cơ bản
    DonViId INT FOREIGN KEY REFERENCES DonVi(Id),
    LoaiRungId INT FOREIGN KEY REFERENCES LoaiRung(Id),
    ChuRungId INT FOREIGN KEY REFERENCES ChuRung(Id),
    GiongCayId INT FOREIGN KEY REFERENCES GiongCay(Id),
    KyQuyHoachId INT FOREIGN KEY REFERENCES KyQuyHoach(Id),
    
    -- CÁC CỘT MỚI THÊM (Theo Model C#)
    DoDocId INT FOREIGN KEY REFERENCES ThuocTinhLoDat(Id),
    DoCaoId INT FOREIGN KEY REFERENCES ThuocTinhLoDat(Id),
    DoDayDatId INT FOREIGN KEY REFERENCES ThuocTinhLoDat(Id),
    GiaTriDoDoc FLOAT,
    GiaTriDoCao FLOAT
	
)
GO

-- 2.7. BienDongRung (CẬP NHẬT)
CREATE TABLE BienDongRung (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LoRungId INT FOREIGN KEY REFERENCES LoRung(Id),
    NgayBienDong DATETIME DEFAULT GETDATE(),
    LoaiBienDong NVARCHAR(100),
    DienTichBienDong FLOAT,
    TruLuongBienDong FLOAT, -- Mới thêm
    MoTaChiTiet NVARCHAR(MAX),
    FileDinhKem NVARCHAR(MAX), -- Mới thêm
    NguoiCapNhat NVARCHAR(100)
)
GO

-- =======================================================
-- PHẦN 3: QUẢN LÝ THIÊN TAI (GIỮ NGUYÊN & KHỚP TYPE)
-- =======================================================

CREATE TABLE DiemThienTai (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenDiem NVARCHAR(255),
    LoaiThienTai NVARCHAR(100), -- Tăng độ rộng
    MucDo NVARCHAR(50),
    ToaDoX FLOAT, 
    ToaDoY FLOAT,
    MoTa NVARCHAR(MAX),
    DonViId INT FOREIGN KEY REFERENCES DonVi(Id)
)
GO

CREATE TABLE BaoCao (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(255),
    NgayBaoCao DATETIME DEFAULT GETDATE(),
    NoiDung NVARCHAR(MAX),
    FileDinhKem NVARCHAR(MAX),
    NguoiBaoCao VARCHAR(50) FOREIGN KEY REFERENCES TaiKhoan(Ten)
)
GO

CREATE TABLE FileDinhKem (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenFile NVARCHAR(255),
    DuongDan NVARCHAR(MAX),
    LoaiDoiTuong NVARCHAR(50), 
    IdDoiTuong INT,           
    NgayUpload DATETIME DEFAULT GETDATE()
)
GO

-- =======================================================
-- PHẦN 4: VIEWS (GIỮ NGUYÊN FRAMEWORK)
-- =======================================================

EXEC('CREATE VIEW ViewHoSo AS
    SELECT HoSo.Id, HoSo.Ten, HoSo.SDT, HoSo.Email, HoSo.Ext, 
           TaiKhoan.Ten as TenDangNhap, MatKhau, QuyenId, Quyen.Ten as Quyen 
    FROM TaiKhoan
    INNER JOIN Quyen ON QuyenId = Quyen.Id
    INNER JOIN HoSo ON HoSoId = HoSo.Id')
GO

EXEC('CREATE VIEW ViewDonVi AS
    SELECT T.Id, T.Ten, T.HanhChinhId, T.TenHanhChinh, T.TrucThuocId, T.Cap, DonVi.Ten as TrucThuoc FROM
        (SELECT DonVi.Id, DonVi.Ten, DonVi.HanhChinhId, DonVi.TenHanhChinh, DonVi.TrucThuocId, HanhChinh.Ten as Cap FROM DonVi 
        inner join HanhChinh ON HanhChinhId = HanhChinh.Id) as T
    left join DonVi ON T.TrucThuocId = DonVi.Id')
GO

