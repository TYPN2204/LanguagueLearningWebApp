using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguagueLearningApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuDeChatBots",
                columns: table => new
                {
                    MaChuDe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichHoat = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDeChatBots", x => x.MaChuDe);
                });

            migrationBuilder.CreateTable(
                name: "NhiemVus",
                columns: table => new
                {
                    MaNhiemVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhiemVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemThuong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ChuKy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DangHoatDong = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVus", x => x.MaNhiemVu);
                });

            migrationBuilder.CreateTable(
                name: "PhanThuongs",
                columns: table => new
                {
                    MaPhanThuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhanThuong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemCan = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanThuongs", x => x.MaPhanThuong);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VaiTro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LanDangNhapCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    MaGiaoVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Truong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.MaGiaoVien);
                    table.ForeignKey(
                        name: "FK_GiaoViens_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "PhuHuynhs",
                columns: table => new
                {
                    MaPhuHuynh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ZaloID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuHuynhs", x => x.MaPhuHuynh);
                    table.ForeignKey(
                        name: "FK_PhuHuynhs_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "TinNhans",
                columns: table => new
                {
                    MaTinNhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiGui = table.Column<int>(type: "int", nullable: true),
                    MaNguoiNhan = table.Column<int>(type: "int", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinNhans", x => x.MaTinNhan);
                    table.ForeignKey(
                        name: "FK_TinNhans_TaiKhoans_MaNguoiGui",
                        column: x => x.MaNguoiGui,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TinNhans_TaiKhoans_MaNguoiNhan",
                        column: x => x.MaNguoiNhan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CapDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaGiaoVien = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.MaKhoaHoc);
                    table.ForeignKey(
                        name: "FK_KhoaHocs_GiaoViens_MaGiaoVien",
                        column: x => x.MaGiaoVien,
                        principalTable: "GiaoViens",
                        principalColumn: "MaGiaoVien");
                });

            migrationBuilder.CreateTable(
                name: "HocSinhs",
                columns: table => new
                {
                    MaHocSinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: true),
                    MaPhuHuynh = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Truong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TongDiem = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinhs", x => x.MaHocSinh);
                    table.ForeignKey(
                        name: "FK_HocSinhs_PhuHuynhs_MaPhuHuynh",
                        column: x => x.MaPhuHuynh,
                        principalTable: "PhuHuynhs",
                        principalColumn: "MaPhuHuynh");
                    table.ForeignKey(
                        name: "FK_HocSinhs_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "BaiHocs",
                columns: table => new
                {
                    MaBaiHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: true),
                    TenBaiHoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiHocs", x => x.MaBaiHoc);
                    table.ForeignKey(
                        name: "FK_BaiHocs_KhoaHocs_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "MaKhoaHoc");
                });

            migrationBuilder.CreateTable(
                name: "BangXepHangs",
                columns: table => new
                {
                    MaBXH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    TongDiem = table.Column<int>(type: "int", nullable: true),
                    Hang = table.Column<int>(type: "int", nullable: true),
                    KyHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangXepHangs", x => x.MaBXH);
                    table.ForeignKey(
                        name: "FK_BangXepHangs_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoZalos",
                columns: table => new
                {
                    MaBaoCao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    MaPhuHuynh = table.Column<int>(type: "int", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Chờ gửi"),
                    Loi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoZalos", x => x.MaBaoCao);
                    table.ForeignKey(
                        name: "FK_BaoCaoZalos_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                    table.ForeignKey(
                        name: "FK_BaoCaoZalos_PhuHuynhs_MaPhuHuynh",
                        column: x => x.MaPhuHuynh,
                        principalTable: "PhuHuynhs",
                        principalColumn: "MaPhuHuynh");
                });

            migrationBuilder.CreateTable(
                name: "ChatBot_HocSinhs",
                columns: table => new
                {
                    MaTinChat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    NoiDungNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanHoiAI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YDinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DoChinhXac = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBot_HocSinhs", x => x.MaTinChat);
                    table.ForeignKey(
                        name: "FK_ChatBot_HocSinhs_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                });

            migrationBuilder.CreateTable(
                name: "HocSinh_PhanThuongs",
                columns: table => new
                {
                    MaHocSinh = table.Column<int>(type: "int", nullable: false),
                    MaPhanThuong = table.Column<int>(type: "int", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinh_PhanThuongs", x => new { x.MaHocSinh, x.MaPhanThuong });
                    table.ForeignKey(
                        name: "FK_HocSinh_PhanThuongs_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocSinh_PhanThuongs_PhanThuongs_MaPhanThuong",
                        column: x => x.MaPhanThuong,
                        principalTable: "PhanThuongs",
                        principalColumn: "MaPhanThuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyAIs",
                columns: table => new
                {
                    MaNhatKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    HanhDong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Thành công"),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyAIs", x => x.MaNhatKy);
                    table.ForeignKey(
                        name: "FK_NhatKyAIs_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                });

            migrationBuilder.CreateTable(
                name: "NhiemVuHocSinhs",
                columns: table => new
                {
                    MaHocSinh = table.Column<int>(type: "int", nullable: false),
                    MaNhiemVu = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Đang giao"),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVuHocSinhs", x => new { x.MaHocSinh, x.MaNhiemVu });
                    table.ForeignKey(
                        name: "FK_NhiemVuHocSinhs_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhiemVuHocSinhs_NhiemVus_MaNhiemVu",
                        column: x => x.MaNhiemVu,
                        principalTable: "NhiemVus",
                        principalColumn: "MaNhiemVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiTaps",
                columns: table => new
                {
                    MaBaiTap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBaiHoc = table.Column<int>(type: "int", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CauHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAnDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemToiDa = table.Column<int>(type: "int", nullable: true, defaultValue: 10),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiTaps", x => x.MaBaiTap);
                    table.ForeignKey(
                        name: "FK_BaiTaps_BaiHocs_MaBaiHoc",
                        column: x => x.MaBaiHoc,
                        principalTable: "BaiHocs",
                        principalColumn: "MaBaiHoc");
                });

            migrationBuilder.CreateTable(
                name: "TienDos",
                columns: table => new
                {
                    MaTienDo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    MaBaiHoc = table.Column<int>(type: "int", nullable: true),
                    TiLeHoanThanh = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LanCuoiHoatDong = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienDos", x => x.MaTienDo);
                    table.ForeignKey(
                        name: "FK_TienDos_BaiHocs_MaBaiHoc",
                        column: x => x.MaBaiHoc,
                        principalTable: "BaiHocs",
                        principalColumn: "MaBaiHoc");
                    table.ForeignKey(
                        name: "FK_TienDos_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                });

            migrationBuilder.CreateTable(
                name: "BaiNops",
                columns: table => new
                {
                    MaBaiNop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocSinh = table.Column<int>(type: "int", nullable: true),
                    MaBaiTap = table.Column<int>(type: "int", nullable: true),
                    BaiLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAmThanh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diem = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Chờ chấm"),
                    NgayNop = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiNops", x => x.MaBaiNop);
                    table.ForeignKey(
                        name: "FK_BaiNops_BaiTaps_MaBaiTap",
                        column: x => x.MaBaiTap,
                        principalTable: "BaiTaps",
                        principalColumn: "MaBaiTap");
                    table.ForeignKey(
                        name: "FK_BaiNops_HocSinhs_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinhs",
                        principalColumn: "MaHocSinh");
                });

            migrationBuilder.CreateTable(
                name: "CauHoiTracNghiems",
                columns: table => new
                {
                    MaCauHoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBaiTap = table.Column<int>(type: "int", nullable: true),
                    NoiDungCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuaChon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoiTracNghiems", x => x.MaCauHoi);
                    table.ForeignKey(
                        name: "FK_CauHoiTracNghiems_BaiTaps_MaBaiTap",
                        column: x => x.MaBaiTap,
                        principalTable: "BaiTaps",
                        principalColumn: "MaBaiTap");
                });

            migrationBuilder.CreateTable(
                name: "LoiNguPhaps",
                columns: table => new
                {
                    MaLoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBaiNop = table.Column<int>(type: "int", nullable: true),
                    DoanLoi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GoiYSua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LoaiLoi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTriBatDau = table.Column<int>(type: "int", nullable: true),
                    ViTriKetThuc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoiNguPhaps", x => x.MaLoi);
                    table.ForeignKey(
                        name: "FK_LoiNguPhaps_BaiNops_MaBaiNop",
                        column: x => x.MaBaiNop,
                        principalTable: "BaiNops",
                        principalColumn: "MaBaiNop");
                });

            migrationBuilder.CreateTable(
                name: "PhanHois",
                columns: table => new
                {
                    MaPhanHoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBaiNop = table.Column<int>(type: "int", nullable: true),
                    PhanHoiAI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanXetGV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHois", x => x.MaPhanHoi);
                    table.ForeignKey(
                        name: "FK_PhanHois_BaiNops_MaBaiNop",
                        column: x => x.MaBaiNop,
                        principalTable: "BaiNops",
                        principalColumn: "MaBaiNop");
                });

            migrationBuilder.CreateTable(
                name: "PhanTichAIs",
                columns: table => new
                {
                    MaPhanTich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBaiNop = table.Column<int>(type: "int", nullable: true),
                    DoChinhXacPhatAm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DoChinhXacNguPhap = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DoLuuLoat = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DoDaDangTuVung = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NhanXetAI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayPhanTich = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanTichAIs", x => x.MaPhanTich);
                    table.ForeignKey(
                        name: "FK_PhanTichAIs_BaiNops_MaBaiNop",
                        column: x => x.MaBaiNop,
                        principalTable: "BaiNops",
                        principalColumn: "MaBaiNop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiHocs_MaKhoaHoc",
                table: "BaiHocs",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_BaiNops_MaBaiTap",
                table: "BaiNops",
                column: "MaBaiTap");

            migrationBuilder.CreateIndex(
                name: "IX_BaiNops_MaHocSinh",
                table: "BaiNops",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_BaiTaps_MaBaiHoc",
                table: "BaiTaps",
                column: "MaBaiHoc");

            migrationBuilder.CreateIndex(
                name: "IX_BangXepHangs_MaHocSinh",
                table: "BangXepHangs",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoZalos_MaHocSinh",
                table: "BaoCaoZalos",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoZalos_MaPhuHuynh",
                table: "BaoCaoZalos",
                column: "MaPhuHuynh");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoiTracNghiems_MaBaiTap",
                table: "CauHoiTracNghiems",
                column: "MaBaiTap");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBot_HocSinhs_MaHocSinh",
                table: "ChatBot_HocSinhs",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_MaTaiKhoan",
                table: "GiaoViens",
                column: "MaTaiKhoan",
                unique: true,
                filter: "[MaTaiKhoan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_PhanThuongs_MaPhanThuong",
                table: "HocSinh_PhanThuongs",
                column: "MaPhanThuong");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinhs_MaPhuHuynh",
                table: "HocSinhs",
                column: "MaPhuHuynh");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinhs_MaTaiKhoan",
                table: "HocSinhs",
                column: "MaTaiKhoan",
                unique: true,
                filter: "[MaTaiKhoan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocs_MaGiaoVien",
                table: "KhoaHocs",
                column: "MaGiaoVien");

            migrationBuilder.CreateIndex(
                name: "IX_LoiNguPhaps_MaBaiNop",
                table: "LoiNguPhaps",
                column: "MaBaiNop");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyAIs_MaHocSinh",
                table: "NhatKyAIs",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVuHocSinhs_MaNhiemVu",
                table: "NhiemVuHocSinhs",
                column: "MaNhiemVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_MaBaiNop",
                table: "PhanHois",
                column: "MaBaiNop",
                unique: true,
                filter: "[MaBaiNop] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhanTichAIs_MaBaiNop",
                table: "PhanTichAIs",
                column: "MaBaiNop",
                unique: true,
                filter: "[MaBaiNop] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhuHuynhs_MaTaiKhoan",
                table: "PhuHuynhs",
                column: "MaTaiKhoan",
                unique: true,
                filter: "[MaTaiKhoan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TienDos_MaBaiHoc",
                table: "TienDos",
                column: "MaBaiHoc");

            migrationBuilder.CreateIndex(
                name: "IX_TienDos_MaHocSinh",
                table: "TienDos",
                column: "MaHocSinh");

            migrationBuilder.CreateIndex(
                name: "IX_TinNhans_MaNguoiGui",
                table: "TinNhans",
                column: "MaNguoiGui");

            migrationBuilder.CreateIndex(
                name: "IX_TinNhans_MaNguoiNhan",
                table: "TinNhans",
                column: "MaNguoiNhan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangXepHangs");

            migrationBuilder.DropTable(
                name: "BaoCaoZalos");

            migrationBuilder.DropTable(
                name: "CauHoiTracNghiems");

            migrationBuilder.DropTable(
                name: "ChatBot_HocSinhs");

            migrationBuilder.DropTable(
                name: "ChuDeChatBots");

            migrationBuilder.DropTable(
                name: "HocSinh_PhanThuongs");

            migrationBuilder.DropTable(
                name: "LoiNguPhaps");

            migrationBuilder.DropTable(
                name: "NhatKyAIs");

            migrationBuilder.DropTable(
                name: "NhiemVuHocSinhs");

            migrationBuilder.DropTable(
                name: "PhanHois");

            migrationBuilder.DropTable(
                name: "PhanTichAIs");

            migrationBuilder.DropTable(
                name: "TienDos");

            migrationBuilder.DropTable(
                name: "TinNhans");

            migrationBuilder.DropTable(
                name: "PhanThuongs");

            migrationBuilder.DropTable(
                name: "NhiemVus");

            migrationBuilder.DropTable(
                name: "BaiNops");

            migrationBuilder.DropTable(
                name: "BaiTaps");

            migrationBuilder.DropTable(
                name: "HocSinhs");

            migrationBuilder.DropTable(
                name: "BaiHocs");

            migrationBuilder.DropTable(
                name: "PhuHuynhs");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "TaiKhoans");
        }
    }
}
