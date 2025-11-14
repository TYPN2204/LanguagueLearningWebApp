-- =============================================
-- 🌟 CƠ SỞ DỮ LIỆU ỨNG DỤNG HỌC TIẾNG ANH TIỂU HỌC
-- Phiên bản: SQL Server 2020 (T-SQL)
-- Tác giả: ChatGPT
-- =============================================

CREATE DATABASE HocTiengAnh_TieuHoc;
GO
USE HocTiengAnh_TieuHoc;
GO

-- =============================================
-- 1️⃣ BẢNG TÀI KHOẢN NGƯỜI DÙNG
-- =============================================

CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) UNIQUE,
    MatKhau NVARCHAR(255),
    VaiTro NVARCHAR(20) CHECK (VaiTro IN (N'Học sinh', N'Phụ huynh', N'Giáo viên', N'Quản trị')),
    NgayTao DATETIME DEFAULT GETDATE(),
    LanDangNhapCuoi DATETIME
);
GO

-- =============================================
-- 2️⃣ BẢNG PHỤ HUYNH / HỌC SINH / GIÁO VIÊN
-- =============================================

CREATE TABLE PhuHuynh (
    MaPhuHuynh INT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT REFERENCES TaiKhoan(MaTaiKhoan),
    HoTen NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    ZaloID NVARCHAR(100),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE GiaoVien (
    MaGiaoVien INT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT REFERENCES TaiKhoan(MaTaiKhoan),
    HoTen NVARCHAR(100),
    Email NVARCHAR(255),
    Truong NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE HocSinh (
    MaHocSinh INT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT REFERENCES TaiKhoan(MaTaiKhoan),
    MaPhuHuynh INT REFERENCES PhuHuynh(MaPhuHuynh),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    Lop NVARCHAR(50),
    Truong NVARCHAR(255),
    TongDiem INT DEFAULT 0,
    AnhDaiDien NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- 3️⃣ KHÓA HỌC / BÀI HỌC / BÀI TẬP / CÂU HỎI TRẮC NGHIỆM
-- =============================================

CREATE TABLE KhoaHoc (
    MaKhoaHoc INT IDENTITY(1,1) PRIMARY KEY,
    TenKhoaHoc NVARCHAR(255),
    CapDo NVARCHAR(50),
    MoTa NVARCHAR(MAX),
    MaGiaoVien INT REFERENCES GiaoVien(MaGiaoVien),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE BaiHoc (
    MaBaiHoc INT IDENTITY(1,1) PRIMARY KEY,
    MaKhoaHoc INT REFERENCES KhoaHoc(MaKhoaHoc),
    TenBaiHoc NVARCHAR(255),
    ThuTu INT DEFAULT 0,
    MoTa NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE BaiTap (
    MaBaiTap INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiHoc INT REFERENCES BaiHoc(MaBaiHoc),
    Loai NVARCHAR(50) CHECK (Loai IN (N'Nói', N'Viết', N'Nghe', N'Ngữ pháp', N'Từ vựng', N'Đọc')),
    TieuDe NVARCHAR(255),
    CauHoi NVARCHAR(MAX),
    DapAnDung NVARCHAR(MAX),
    DiemToiDa INT DEFAULT 10,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE CauHoiTracNghiem (
    MaCauHoi INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiTap INT REFERENCES BaiTap(MaBaiTap),
    NoiDungCauHoi NVARCHAR(MAX),
    LuaChon NVARCHAR(MAX), -- Lưu các lựa chọn dưới dạng JSON hoặc phân tách
    DapAn NVARCHAR(255),
    Diem INT DEFAULT 1
);
GO

-- =============================================
-- 4️⃣ NỘP BÀI, PHÂN TÍCH AI, LỖI NGỮ PHÁP, PHẢN HỒI
-- =============================================

CREATE TABLE BaiNop (
    MaBaiNop INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    MaBaiTap INT REFERENCES BaiTap(MaBaiTap),
    BaiLam NVARCHAR(MAX),
    LinkAmThanh NVARCHAR(255),
    Diem DECIMAL(5,2),
    TrangThai NVARCHAR(20) DEFAULT N'Chờ chấm',
    NgayNop DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE PhanTichAI (
    MaPhanTich INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiNop INT UNIQUE REFERENCES BaiNop(MaBaiNop),
    DoChinhXacPhatAm DECIMAL(5,2),
    DoChinhXacNguPhap DECIMAL(5,2),
    DoLuuLoat DECIMAL(5,2),
    DoDaDangTuVung DECIMAL(5,2),
    NhanXetAI NVARCHAR(MAX),
    ChiTiet NVARCHAR(MAX), -- JSON chứa chi tiết lỗi
    NgayPhanTich DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE LoiNguPhap (
    MaLoi INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiNop INT REFERENCES BaiNop(MaBaiNop),
    DoanLoi NVARCHAR(255),
    GoiYSua NVARCHAR(255),
    LoaiLoi NVARCHAR(100),
    ViTriBatDau INT,
    ViTriKetThuc INT
);
GO

CREATE TABLE PhanHoi (
    MaPhanHoi INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiNop INT UNIQUE REFERENCES BaiNop(MaBaiNop),
    PhanHoiAI NVARCHAR(MAX),
    NhanXetGV NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- 5️⃣ NHIỆM VỤ, PHẦN THƯỞNG, TIẾN ĐỘ, BẢNG XẾP HẠNG
-- =============================================

CREATE TABLE NhiemVu (
    MaNhiemVu INT IDENTITY(1,1) PRIMARY KEY,
    TenNhiemVu NVARCHAR(255),
    MoTa NVARCHAR(MAX),
    DiemThuong INT DEFAULT 0,
    ChuKy NVARCHAR(20) CHECK (ChuKy IN (N'Hàng ngày', N'Hàng tuần', N'Hàng tháng', N'Một lần')),
    DangHoatDong BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE NhiemVuHocSinh (
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    MaNhiemVu INT REFERENCES NhiemVu(MaNhiemVu),
    TrangThai NVARCHAR(20) DEFAULT N'Đang giao',
    NgayGiao DATETIME DEFAULT GETDATE(),
    NgayHoanThanh DATETIME,
    PRIMARY KEY (MaHocSinh, MaNhiemVu)
);
GO

CREATE TABLE PhanThuong (
    MaPhanThuong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhanThuong NVARCHAR(255),
    MoTa NVARCHAR(MAX),
    DiemCan INT DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE HocSinh_PhanThuong (
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    MaPhanThuong INT REFERENCES PhanThuong(MaPhanThuong),
    NgayNhan DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaHocSinh, MaPhanThuong)
);
GO

CREATE TABLE TienDo (
    MaTienDo INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    MaBaiHoc INT REFERENCES BaiHoc(MaBaiHoc),
    TiLeHoanThanh DECIMAL(5,2) DEFAULT 0,
    LanCuoiHoatDong DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE BangXepHang (
    MaBXH INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    TongDiem INT DEFAULT 0,
    Hang INT,
    KyHan NVARCHAR(50), -- Ví dụ: 'Tuần 45 2025'
    NgayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- 6️⃣ GỬI BÁO CÁO ZALO & TIN NHẮN
-- =============================================

CREATE TABLE BaoCaoZalo (
    MaBaoCao INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    MaPhuHuynh INT REFERENCES PhuHuynh(MaPhuHuynh),
    NoiDung NVARCHAR(MAX),
    TrangThai NVARCHAR(20) DEFAULT N'Chờ gửi',
    Loi NVARCHAR(255),
    NgayGui DATETIME
);
GO

CREATE TABLE TinNhan (
    MaTinNhan INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiGui INT REFERENCES TaiKhoan(MaTaiKhoan),
    MaNguoiNhan INT REFERENCES TaiKhoan(MaTaiKhoan),
    NoiDung NVARCHAR(MAX),
    NgayGui DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- 7️⃣ CHAT BOT AI & LỊCH SỬ TRAO ĐỔI
-- =============================================

CREATE TABLE ChuDeChatBot (
    MaChuDe INT IDENTITY(1,1) PRIMARY KEY,
    TenChuDe NVARCHAR(255),
    MoTa NVARCHAR(MAX),
    KichHoat BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ChatBot_HocSinh (
    MaTinChat INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    NoiDungNguoiDung NVARCHAR(MAX),
    PhanHoiAI NVARCHAR(MAX),
    ChuDe NVARCHAR(100),
    YDinh NVARCHAR(100),
    DoChinhXac DECIMAL(5,2),
    ThoiGian DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE NhatKyAI (
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh INT REFERENCES HocSinh(MaHocSinh),
    HanhDong NVARCHAR(255),
    KetQua NVARCHAR(MAX),
    TrangThai NVARCHAR(50) DEFAULT N'Thành công',
    ThoiGian DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- ✅ TẠO CHỈ MỤC TỐI ƯU HIỆU SUẤT
-- =============================================

CREATE INDEX IX_BaiNop_HocSinh ON BaiNop(MaHocSinh);
CREATE INDEX IX_BaiNop_BaiTap ON BaiNop(MaBaiTap);
CREATE INDEX IX_TienDo_HocSinh ON TienDo(MaHocSinh);
CREATE INDEX IX_BangXepHang_HocSinh ON BangXepHang(MaHocSinh);
CREATE INDEX IX_ChatBot_HocSinh ON ChatBot_HocSinh(MaHocSinh);
GO
