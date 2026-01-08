USE KTPM
GO

-- =======================================================
-- NHÓM 1: HỆ THỐNG & DANH MỤC HÀNH CHÍNH
-- =======================================================

-- 1. updateHoSo
IF OBJECT_ID('updateHoSo', 'P') IS NOT NULL DROP PROC updateHoSo
GO
CREATE PROC updateHoSo
    @action int, @Id int = NULL, @Ten nvarchar(50) = NULL, @SDT varchar(50) = NULL, @Email varchar(50) = NULL, @Ext text = NULL
AS BEGIN
    IF @action = 0 DELETE FROM HoSo WHERE Id = @Id
    ELSE IF @action = 1 UPDATE HoSo SET Ten=@Ten, SDT=@SDT, Email=@Email, Ext=@Ext WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO HoSo(Ten, SDT, Email, Ext) VALUES(@Ten, @SDT, @Email, @Ext)
END
GO

-- 2. updateQuyen
IF OBJECT_ID('updateQuyen', 'P') IS NOT NULL DROP PROC updateQuyen
GO
CREATE PROC updateQuyen
    @action int, @Id int = NULL, @Ten nvarchar(50) = NULL, @Ext varchar(50) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM Quyen WHERE Id = @Id
    ELSE IF @action = 1 UPDATE Quyen SET Ten=@Ten, Ext=@Ext WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO Quyen(Ten, Ext) VALUES(@Ten, @Ext)
END
GO

-- 3. updateTaiKhoan (Lưu ý: Khóa chính là Ten)
IF OBJECT_ID('updateTaiKhoan', 'P') IS NOT NULL DROP PROC updateTaiKhoan
GO
CREATE PROC updateTaiKhoan
    @action int, @Ten varchar(50) = NULL, @MatKhau varchar(255) = NULL, @QuyenId int = NULL, @HoSoId int = NULL
AS BEGIN
    IF @action = 0 DELETE FROM TaiKhoan WHERE Ten = @Ten
    ELSE IF @action = 1 UPDATE TaiKhoan SET MatKhau=@MatKhau, QuyenId=@QuyenId, HoSoId=@HoSoId WHERE Ten = @Ten
    ELSE IF @action = 2 INSERT INTO TaiKhoan(Ten, MatKhau, QuyenId, HoSoId) VALUES(@Ten, @MatKhau, @QuyenId, @HoSoId)
END
GO

-- 4. updateHanhChinh
IF OBJECT_ID('updateHanhChinh', 'P') IS NOT NULL DROP PROC updateHanhChinh
GO
CREATE PROC updateHanhChinh
    @action int, @Id int = NULL, @Ten nvarchar(50) = NULL, @TrucThuocId int = NULL
AS BEGIN
    IF @action = 0 DELETE FROM HanhChinh WHERE Id = @Id
    ELSE IF @action = 1 UPDATE HanhChinh SET Ten=@Ten, TrucThuocId=@TrucThuocId WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO HanhChinh(Ten, TrucThuocId) VALUES(@Ten, @TrucThuocId)
END
GO

-- 5. updateDonVi
IF OBJECT_ID('updateDonVi', 'P') IS NOT NULL DROP PROC updateDonVi
GO
CREATE PROC updateDonVi
    @action int, @Id int = NULL, @Ten nvarchar(50) = NULL, @HanhChinhId int = NULL, @TenHanhChinh nvarchar(50) = NULL, @TrucThuocId int = NULL
AS BEGIN
    IF @action = 0 DELETE FROM DonVi WHERE Id = @Id
    ELSE IF @action = 1 UPDATE DonVi SET Ten=@Ten, HanhChinhId=@HanhChinhId, TenHanhChinh=@TenHanhChinh, TrucThuocId=@TrucThuocId WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO DonVi(Ten, HanhChinhId, TenHanhChinh, TrucThuocId) VALUES(@Ten, @HanhChinhId, @TenHanhChinh, @TrucThuocId)
END
GO

-- 6. updateLichSuTruyCap
IF OBJECT_ID('updateLichSuTruyCap', 'P') IS NOT NULL DROP PROC updateLichSuTruyCap
GO
CREATE PROC updateLichSuTruyCap
    @action int, @Id int = NULL, @TaiKhoan varchar(50) = NULL, @ThoiGian datetime = NULL, @HanhDong nvarchar(255) = NULL, @IPAddress varchar(50) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM LichSuTruyCap WHERE Id = @Id
    ELSE IF @action = 1 UPDATE LichSuTruyCap SET TaiKhoan=@TaiKhoan, ThoiGian=@ThoiGian, HanhDong=@HanhDong, IPAddress=@IPAddress WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO LichSuTruyCap(TaiKhoan, ThoiGian, HanhDong, IPAddress) VALUES(@TaiKhoan, @ThoiGian, @HanhDong, @IPAddress)
END
GO

-- 7. updateLichSuTacDong
IF OBJECT_ID('updateLichSuTacDong', 'P') IS NOT NULL DROP PROC updateLichSuTacDong
GO
CREATE PROC updateLichSuTacDong
    @action int, @Id int = NULL, @NguoiThucHien varchar(50) = NULL, @ThoiGian datetime = NULL, @BangTacDong nvarchar(50) = NULL, @IdBanGhi nvarchar(50) = NULL, @LoaiTacDong nvarchar(20) = NULL, @NoiDungThayDoi nvarchar(max) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM LichSuTacDong WHERE Id = @Id
    ELSE IF @action = 1 UPDATE LichSuTacDong SET NguoiThucHien=@NguoiThucHien, ThoiGian=@ThoiGian, BangTacDong=@BangTacDong, IdBanGhi=@IdBanGhi, LoaiTacDong=@LoaiTacDong, NoiDungThayDoi=@NoiDungThayDoi WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO LichSuTacDong(NguoiThucHien, ThoiGian, BangTacDong, IdBanGhi, LoaiTacDong, NoiDungThayDoi) VALUES(@NguoiThucHien, @ThoiGian, @BangTacDong, @IdBanGhi, @LoaiTacDong, @NoiDungThayDoi)
END
GO

-- =======================================================
-- NHÓM 2: DANH MỤC LÂM NGHIỆP & THUỘC TÍNH
-- =======================================================

-- 8. updateThuocTinhLoDat
IF OBJECT_ID('updateThuocTinhLoDat', 'P') IS NOT NULL DROP PROC updateThuocTinhLoDat
GO
CREATE PROC updateThuocTinhLoDat
    @action int, @Id int = NULL, @TenThuocTinh nvarchar(200) = NULL, @NhomThuocTinh nvarchar(100) = NULL, @MoTa nvarchar(max) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM ThuocTinhLoDat WHERE Id = @Id
    ELSE IF @action = 1 UPDATE ThuocTinhLoDat SET TenThuocTinh=@TenThuocTinh, NhomThuocTinh=@NhomThuocTinh, MoTa=@MoTa WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO ThuocTinhLoDat(TenThuocTinh, NhomThuocTinh, MoTa) VALUES(@TenThuocTinh, @NhomThuocTinh, @MoTa)
END
GO

-- 9. updateGiongCay
IF OBJECT_ID('updateGiongCay', 'P') IS NOT NULL DROP PROC updateGiongCay
GO
CREATE PROC updateGiongCay
    @action int, @Id int = NULL, @Ten nvarchar(200) = NULL, @Nguon nvarchar(255) = NULL, @DacTinh nvarchar(max) = NULL, @LoaiCay nvarchar(50) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM GiongCay WHERE Id = @Id
    ELSE IF @action = 1 UPDATE GiongCay SET Ten=@Ten, Nguon=@Nguon, DacTinh=@DacTinh, LoaiCay=@LoaiCay WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO GiongCay(Ten, Nguon, DacTinh, LoaiCay) VALUES(@Ten, @Nguon, @DacTinh, @LoaiCay)
END
GO

-- 10. updateLoaiRung
IF OBJECT_ID('updateLoaiRung', 'P') IS NOT NULL DROP PROC updateLoaiRung
GO
CREATE PROC updateLoaiRung
    @action int, @Id int = NULL, @TenLoai nvarchar(255) = NULL, @MaLoai varchar(50) = NULL, @MoTa nvarchar(max) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM LoaiRung WHERE Id = @Id
    ELSE IF @action = 1 UPDATE LoaiRung SET TenLoai=@TenLoai, MaLoai=@MaLoai, MoTa=@MoTa WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO LoaiRung(TenLoai, MaLoai, MoTa) VALUES(@TenLoai, @MaLoai, @MoTa)
END
GO

-- 11. updateChuRung
IF OBJECT_ID('updateChuRung', 'P') IS NOT NULL DROP PROC updateChuRung
GO
CREATE PROC updateChuRung
    @action int, @Id int = NULL, @TenChuRung nvarchar(255) = NULL, @LoaiChuSoHuu nvarchar(100) = NULL, @DiaChi nvarchar(max) = NULL, @SoDienThoai nvarchar(20) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM ChuRung WHERE Id = @Id
    ELSE IF @action = 1 UPDATE ChuRung SET TenChuRung=@TenChuRung, LoaiChuSoHuu=@LoaiChuSoHuu, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO ChuRung(TenChuRung, LoaiChuSoHuu, DiaChi, SoDienThoai) VALUES(@TenChuRung, @LoaiChuSoHuu, @DiaChi, @SoDienThoai)
END
GO

-- =======================================================
-- NHÓM 3: QUY HOẠCH & BẢN ĐỒ
-- =======================================================

-- 12. updateKyQuyHoach
IF OBJECT_ID('updateKyQuyHoach', 'P') IS NOT NULL DROP PROC updateKyQuyHoach
GO
CREATE PROC updateKyQuyHoach
    @action int, @Id int = NULL, @TenKy nvarchar(100) = NULL, @TuNam int = NULL, @DenNam int = NULL, @MoTa nvarchar(max) = NULL, @TrangThai bit = NULL
AS BEGIN
    IF @action = 0 DELETE FROM KyQuyHoach WHERE Id = @Id
    ELSE IF @action = 1 UPDATE KyQuyHoach SET TenKy=@TenKy, TuNam=@TuNam, DenNam=@DenNam, MoTa=@MoTa, TrangThai=@TrangThai WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO KyQuyHoach(TenKy, TuNam, DenNam, MoTa, TrangThai) VALUES(@TenKy, @TuNam, @DenNam, @MoTa, @TrangThai)
END
GO

-- 13. updateBanDoQuyHoach
IF OBJECT_ID('updateBanDoQuyHoach', 'P') IS NOT NULL DROP PROC updateBanDoQuyHoach
GO
CREATE PROC updateBanDoQuyHoach
    @action int, @Id int = NULL, @KyQuyHoachId int = NULL, @TenBanDo nvarchar(200) = NULL, @LoaiBanDo nvarchar(100) = NULL, @TyLe nvarchar(50) = NULL, @DuLieuBanDo nvarchar(max) = NULL, @MoTa nvarchar(max) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM BanDoQuyHoach WHERE Id = @Id
    ELSE IF @action = 1 UPDATE BanDoQuyHoach SET KyQuyHoachId=@KyQuyHoachId, TenBanDo=@TenBanDo, LoaiBanDo=@LoaiBanDo, TyLe=@TyLe, DuLieuBanDo=@DuLieuBanDo, MoTa=@MoTa WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO BanDoQuyHoach(KyQuyHoachId, TenBanDo, LoaiBanDo, TyLe, DuLieuBanDo, MoTa) VALUES(@KyQuyHoachId, @TenBanDo, @LoaiBanDo, @TyLe, @DuLieuBanDo, @MoTa)
END
GO

-- 14. updateBaoCaoQuyHoach
IF OBJECT_ID('updateBaoCaoQuyHoach', 'P') IS NOT NULL DROP PROC updateBaoCaoQuyHoach
GO
CREATE PROC updateBaoCaoQuyHoach
    @action int, @Id int = NULL, @KyQuyHoachId int = NULL, @TenBaoCao nvarchar(200) = NULL, @SoHieuVanBan nvarchar(50) = NULL, @NgayBanHanh datetime = NULL, @CoQuanBanHanh nvarchar(200) = NULL, @FileDinhKem nvarchar(max) = NULL, @MoTa nvarchar(max) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM BaoCaoQuyHoach WHERE Id = @Id
    ELSE IF @action = 1 UPDATE BaoCaoQuyHoach SET KyQuyHoachId=@KyQuyHoachId, TenBaoCao=@TenBaoCao, SoHieuVanBan=@SoHieuVanBan, NgayBanHanh=@NgayBanHanh, CoQuanBanHanh=@CoQuanBanHanh, FileDinhKem=@FileDinhKem, MoTa=@MoTa WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO BaoCaoQuyHoach(KyQuyHoachId, TenBaoCao, SoHieuVanBan, NgayBanHanh, CoQuanBanHanh, FileDinhKem, MoTa) VALUES(@KyQuyHoachId, @TenBaoCao, @SoHieuVanBan, @NgayBanHanh, @CoQuanBanHanh, @FileDinhKem, @MoTa)
END
GO

-- =======================================================
-- NHÓM 4: NGHIỆP VỤ RỪNG (CỐT LÕI)
-- =======================================================

-- 15. updateLoRung
IF OBJECT_ID('updateLoRung', 'P') IS NOT NULL DROP PROC updateLoRung
GO
CREATE PROC updateLoRung
    @action int, @Id int = NULL, @MaLo nvarchar(50) = NULL, @TenLo nvarchar(200) = NULL, @BanDo nvarchar(max) = NULL, @DienTich float = NULL, @TruLuong float = NULL, @NamTrong int = NULL, @NguonGoc nvarchar(200) = NULL, @DieuKienLapDia nvarchar(255) = NULL, @TrangThaiSuDung nvarchar(100) = NULL, @DonViId int = NULL, @LoaiRungId int = NULL, @ChuRungId int = NULL, @GiongCayId int = NULL, @KyQuyHoachId int = NULL, @DoDocId int = NULL, @DoCaoId int = NULL, @DoDayDatId int = NULL, @GiaTriDoDoc float = NULL, @GiaTriDoCao float = NULL
AS BEGIN
    IF @action = 0 DELETE FROM LoRung WHERE Id = @Id
    ELSE IF @action = 1 UPDATE LoRung SET MaLo=@MaLo, TenLo=@TenLo, BanDo=@BanDo, DienTich=@DienTich, TruLuong=@TruLuong, NamTrong=@NamTrong, NguonGoc=@NguonGoc, DieuKienLapDia=@DieuKienLapDia, TrangThaiSuDung=@TrangThaiSuDung, DonViId=@DonViId, LoaiRungId=@LoaiRungId, ChuRungId=@ChuRungId, GiongCayId=@GiongCayId, KyQuyHoachId=@KyQuyHoachId, DoDocId=@DoDocId, DoCaoId=@DoCaoId, DoDayDatId=@DoDayDatId, GiaTriDoDoc=@GiaTriDoDoc, GiaTriDoCao=@GiaTriDoCao WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO LoRung(MaLo, TenLo, BanDo, DienTich, TruLuong, NamTrong, NguonGoc, DieuKienLapDia, TrangThaiSuDung, DonViId, LoaiRungId, ChuRungId, GiongCayId, KyQuyHoachId, DoDocId, DoCaoId, DoDayDatId, GiaTriDoDoc, GiaTriDoCao) VALUES(@MaLo, @TenLo, @BanDo, @DienTich, @TruLuong, @NamTrong, @NguonGoc, @DieuKienLapDia, @TrangThaiSuDung, @DonViId, @LoaiRungId, @ChuRungId, @GiongCayId, @KyQuyHoachId, @DoDocId, @DoCaoId, @DoDayDatId, @GiaTriDoDoc, @GiaTriDoCao)
END
GO

-- 16. updateBienDongRung
IF OBJECT_ID('updateBienDongRung', 'P') IS NOT NULL DROP PROC updateBienDongRung
GO
CREATE PROC updateBienDongRung
    @action int, @Id int = NULL, @LoRungId int = NULL, @NgayBienDong datetime = NULL, @LoaiBienDong nvarchar(100) = NULL, @DienTichBienDong float = NULL, @TruLuongBienDong float = NULL, @MoTaChiTiet nvarchar(max) = NULL, @FileDinhKem nvarchar(max) = NULL, @NguoiCapNhat nvarchar(100) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM BienDongRung WHERE Id = @Id
    ELSE IF @action = 1 UPDATE BienDongRung SET LoRungId=@LoRungId, NgayBienDong=@NgayBienDong, LoaiBienDong=@LoaiBienDong, DienTichBienDong=@DienTichBienDong, TruLuongBienDong=@TruLuongBienDong, MoTaChiTiet=@MoTaChiTiet, FileDinhKem=@FileDinhKem, NguoiCapNhat=@NguoiCapNhat WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO BienDongRung(LoRungId, NgayBienDong, LoaiBienDong, DienTichBienDong, TruLuongBienDong, MoTaChiTiet, FileDinhKem, NguoiCapNhat) VALUES(@LoRungId, @NgayBienDong, @LoaiBienDong, @DienTichBienDong, @TruLuongBienDong, @MoTaChiTiet, @FileDinhKem, @NguoiCapNhat)
END
GO

-- =======================================================
-- NHÓM 5: THIÊN TAI & BÁO CÁO
-- =======================================================

-- 17. updateDiemThienTai
IF OBJECT_ID('updateDiemThienTai', 'P') IS NOT NULL DROP PROC updateDiemThienTai
GO
CREATE PROC updateDiemThienTai
    @action int, @Id int = NULL, @TenDiem nvarchar(255) = NULL, @LoaiThienTai nvarchar(100) = NULL, @MucDo nvarchar(50) = NULL, @ToaDoX float = NULL, @ToaDoY float = NULL, @MoTa nvarchar(max) = NULL, @DonViId int = NULL
AS BEGIN
    IF @action = 0 DELETE FROM DiemThienTai WHERE Id = @Id
    ELSE IF @action = 1 UPDATE DiemThienTai SET TenDiem=@TenDiem, LoaiThienTai=@LoaiThienTai, MucDo=@MucDo, ToaDoX=@ToaDoX, ToaDoY=@ToaDoY, MoTa=@MoTa, DonViId=@DonViId WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO DiemThienTai(TenDiem, LoaiThienTai, MucDo, ToaDoX, ToaDoY, MoTa, DonViId) VALUES(@TenDiem, @LoaiThienTai, @MucDo, @ToaDoX, @ToaDoY, @MoTa, @DonViId)
END
GO

-- 18. updateBaoCao
IF OBJECT_ID('updateBaoCao', 'P') IS NOT NULL DROP PROC updateBaoCao
GO
CREATE PROC updateBaoCao
    @action int, @Id int = NULL, @TieuDe nvarchar(255) = NULL, @NgayBaoCao datetime = NULL, @NoiDung nvarchar(max) = NULL, @FileDinhKem nvarchar(max) = NULL, @NguoiBaoCao varchar(50) = NULL
AS BEGIN
    IF @action = 0 DELETE FROM BaoCao WHERE Id = @Id
    ELSE IF @action = 1 UPDATE BaoCao SET TieuDe=@TieuDe, NgayBaoCao=@NgayBaoCao, NoiDung=@NoiDung, FileDinhKem=@FileDinhKem, NguoiBaoCao=@NguoiBaoCao WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO BaoCao(TieuDe, NgayBaoCao, NoiDung, FileDinhKem, NguoiBaoCao) VALUES(@TieuDe, @NgayBaoCao, @NoiDung, @FileDinhKem, @NguoiBaoCao)
END
GO

-- 19. updateFileDinhKem
IF OBJECT_ID('updateFileDinhKem', 'P') IS NOT NULL DROP PROC updateFileDinhKem
GO
CREATE PROC updateFileDinhKem
    @action int, @Id int = NULL, @TenFile nvarchar(255) = NULL, @DuongDan nvarchar(max) = NULL, @LoaiDoiTuong nvarchar(50) = NULL, @IdDoiTuong int = NULL, @NgayUpload datetime = NULL
AS BEGIN
    IF @action = 0 DELETE FROM FileDinhKem WHERE Id = @Id
    ELSE IF @action = 1 UPDATE FileDinhKem SET TenFile=@TenFile, DuongDan=@DuongDan, LoaiDoiTuong=@LoaiDoiTuong, IdDoiTuong=@IdDoiTuong, NgayUpload=@NgayUpload WHERE Id = @Id
    ELSE IF @action = 2 INSERT INTO FileDinhKem(TenFile, DuongDan, LoaiDoiTuong, IdDoiTuong, NgayUpload) VALUES(@TenFile, @DuongDan, @LoaiDoiTuong, @IdDoiTuong, @NgayUpload)
END
GO