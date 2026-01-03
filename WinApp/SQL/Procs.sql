USE KTPM
GO

-- =============================================
-- PHẦN 1: HỆ THỐNG (ĐÃ SỬA LẠI LOGIC ACTION)
-- Action: 1=Insert, 2=Update, 3=Delete
-- =============================================

CREATE OR ALTER PROC updateDonVi
( 
    @action int,
    @Id int output,
    @Ten nvarchar(50) = NULL,
    @HanhChinhId int = NULL,
    @TenHanhChinh nvarchar(50) = NULL,
    @TrucThuocId int = NULL
) AS
BEGIN
    -- 3: XÓA
    IF @action = 3 
    BEGIN
        DELETE FROM DonVi WHERE Id = @Id
        RETURN
    END

    -- 2: CẬP NHẬT
    IF @action = 2 
    BEGIN
        UPDATE DonVi SET
            Ten = @Ten,
            HanhChinhId = @HanhChinhId,
            TenHanhChinh = @TenHanhChinh,
            TrucThuocId = @TrucThuocId
        WHERE Id = @Id
        RETURN
    END

    -- 1: THÊM MỚI
    INSERT INTO DonVi (Ten, HanhChinhId, TenHanhChinh, TrucThuocId)
    VALUES (@Ten, @HanhChinhId, @TenHanhChinh, @TrucThuocId)
    
    SET @Id = @@IDENTITY
END
GO

CREATE OR ALTER PROC updateHoSo
( 
    @action int,
    @Id int output,
    @TenDangNhap varchar(50) = NULL,
    @Ten nvarchar(50) = NULL,
    @SDT varchar(50) = NULL,
    @Email varchar(50) = NULL,
    @Ext text = NULL,
    @MatKhau varchar(255) = NULL,
    @QuyenId int = NULL
) AS
BEGIN
    IF @action = 3
    BEGIN
        -- Xóa tài khoản trước, hồ sơ sau
        DELETE FROM TaiKhoan WHERE HoSoId = @Id
        DELETE FROM HoSo WHERE Id = @Id
        RETURN
    END

    IF @action = 2
    BEGIN
        UPDATE HoSo SET
            Ten = @Ten,
            SDT = @SDT,
            Email = @Email,
            Ext = @Ext
        WHERE Id = @Id
        
        -- Nếu có đổi quyền thì cập nhật bảng TaiKhoan
        IF @QuyenId IS NOT NULL AND @TenDangNhap IS NOT NULL
            UPDATE TaiKhoan SET QuyenId = @QuyenId WHERE Ten = @TenDangNhap

        RETURN
    END

    -- Thêm mới
    INSERT INTO HoSo (Ten, SDT, Email, Ext) VALUES (@Ten, @SDT, @Email, @Ext)
    SET @Id = @@IDENTITY
    
    INSERT INTO TaiKhoan (Ten, MatKhau, QuyenId, HoSoId) 
    VALUES (@TenDangNhap, @MatKhau, @QuyenId, @Id)
END
GO

-- =============================================
-- PHẦN 2: NGHIỆP VỤ RỪNG (BỔ SUNG MỚI)
-- =============================================

CREATE OR ALTER PROCEDURE updateLoRung
    @action INT, 
    @Id INT = NULL OUTPUT,
    @MaLo NVARCHAR(50) = NULL,
    @DienTich FLOAT = 0,
    @TruLuong FLOAT = 0,
    @NamTrong INT = NULL,
    @NguonGoc NVARCHAR(50) = NULL,
    @DieuKienLapDia NVARCHAR(255) = NULL,
    @TrangThaiSuDung NVARCHAR(100) = NULL,
    @DonViId INT = NULL,
    @LoaiRungId INT = NULL,
    @ChuRungId INT = NULL,
    @GiongCayId INT = NULL,
    @KyQuyHoachId INT = NULL,
    @BanDo NVARCHAR(MAX) = NULL 
AS
BEGIN
    IF @action = 3 
    BEGIN
        DELETE FROM LoRung WHERE Id = @Id;
        RETURN;
    END

    IF @action = 2
    BEGIN
        UPDATE LoRung SET 
            MaLo = @MaLo, DienTich = @DienTich, TruLuong = @TruLuong, 
            NamTrong = @NamTrong, NguonGoc = @NguonGoc, DieuKienLapDia = @DieuKienLapDia, 
            TrangThaiSuDung = @TrangThaiSuDung, DonViId = @DonViId, LoaiRungId = @LoaiRungId, 
            ChuRungId = @ChuRungId, GiongCayId = @GiongCayId, KyQuyHoachId = @KyQuyHoachId, BanDo = @BanDo
        WHERE Id = @Id;
        RETURN;
    END

    INSERT INTO LoRung (MaLo, DienTich, TruLuong, NamTrong, NguonGoc, DieuKienLapDia, TrangThaiSuDung, DonViId, LoaiRungId, ChuRungId, GiongCayId, KyQuyHoachId, BanDo)
    VALUES (@MaLo, @DienTich, @TruLuong, @NamTrong, @NguonGoc, @DieuKienLapDia, @TrangThaiSuDung, @DonViId, @LoaiRungId, @ChuRungId, @GiongCayId, @KyQuyHoachId, @BanDo);
    SET @Id = @@IDENTITY;
END
GO

-- Các bảng danh mục đơn giản (LoaiRung, ChuRung, GiongCay...)
-- Framework có thể tự sinh SQL nhưng tốt nhất nên viết Proc nếu giáo viên yêu cầu
CREATE OR ALTER PROC updateLoaiRung (@action int, @Id int output, @TenLoai nvarchar(255), @MaLoai varchar(50)=NULL, @MoTa nvarchar(max)=NULL) AS
BEGIN
    IF @action=3 BEGIN DELETE FROM LoaiRung WHERE Id=@Id RETURN END
    IF @action=2 BEGIN UPDATE LoaiRung SET TenLoai=@TenLoai, MaLoai=@MaLoai, MoTa=@MoTa WHERE Id=@Id RETURN END
    INSERT INTO LoaiRung (TenLoai, MaLoai, MoTa) VALUES (@TenLoai, @MaLoai, @MoTa) SET @Id=@@IDENTITY
END
GO

CREATE OR ALTER PROC updateChuRung (@action int, @Id int output, @TenChuRung nvarchar(255), @LoaiChuSoHuu nvarchar(100)=NULL, @DiaChi nvarchar(max)=NULL, @SoDienThoai nvarchar(20)=NULL) AS
BEGIN
    IF @action=3 BEGIN DELETE FROM ChuRung WHERE Id=@Id RETURN END
    IF @action=2 BEGIN UPDATE ChuRung SET TenChuRung=@TenChuRung, LoaiChuSoHuu=@LoaiChuSoHuu, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai WHERE Id=@Id RETURN END
    INSERT INTO ChuRung (TenChuRung, LoaiChuSoHuu, DiaChi, SoDienThoai) VALUES (@TenChuRung, @LoaiChuSoHuu, @DiaChi, @SoDienThoai) SET @Id=@@IDENTITY
END
GO

-- =============================================
-- PHẦN 3: NGHIỆP VỤ THIÊN TAI (BỔ SUNG MỚI)
-- =============================================

CREATE OR ALTER PROCEDURE updateDiemThienTai
    @action INT,
    @Id INT = NULL OUTPUT,
    @TenDiem NVARCHAR(255) = NULL,
    @LoaiThienTai NVARCHAR(50) = NULL,
    @MucDo NVARCHAR(50) = NULL,
    @ToaDoX FLOAT = 0,
    @ToaDoY FLOAT = 0,
    @MoTa NVARCHAR(MAX) = NULL,
    @DonViId INT = NULL
AS
BEGIN
    IF @action = 3 
    BEGIN 
        DELETE FROM DiemThienTai WHERE Id = @Id; RETURN; 
    END

    IF @action = 2
    BEGIN
        UPDATE DiemThienTai SET 
            TenDiem = @TenDiem, LoaiThienTai = @LoaiThienTai, MucDo = @MucDo, 
            ToaDoX = @ToaDoX, ToaDoY = @ToaDoY, MoTa = @MoTa, DonViId = @DonViId
        WHERE Id = @Id;
        RETURN;
    END

    INSERT INTO DiemThienTai (TenDiem, LoaiThienTai, MucDo, ToaDoX, ToaDoY, MoTa, DonViId)
    VALUES (@TenDiem, @LoaiThienTai, @MucDo, @ToaDoX, @ToaDoY, @MoTa, @DonViId);
    SET @Id = @@IDENTITY;
END
GO

CREATE OR ALTER PROCEDURE updateBaoCao
    @action INT,
    @Id INT = NULL OUTPUT,
    @TieuDe NVARCHAR(255) = NULL,
    @NgayBaoCao DATETIME = NULL,
    @NoiDung NVARCHAR(MAX) = NULL,
    @FileDinhKem NVARCHAR(MAX) = NULL,
    @NguoiBaoCao VARCHAR(50) = NULL
AS
BEGIN
    IF @action = 3 
    BEGIN 
        DELETE FROM BaoCao WHERE Id = @Id; RETURN; 
    END

    IF @action = 2
    BEGIN
        UPDATE BaoCao SET 
            TieuDe = @TieuDe, NgayBaoCao = @NgayBaoCao, 
            NoiDung = @NoiDung, FileDinhKem = @FileDinhKem, NguoiBaoCao = @NguoiBaoCao
        WHERE Id = @Id;
        RETURN;
    END

    INSERT INTO BaoCao (TieuDe, NgayBaoCao, NoiDung, FileDinhKem, NguoiBaoCao)
    VALUES (@TieuDe, @NgayBaoCao, @NoiDung, @FileDinhKem, @NguoiBaoCao);
    SET @Id = @@IDENTITY;
END
GO