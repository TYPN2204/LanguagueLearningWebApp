using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets for all entities
    public DbSet<TaiKhoan> TaiKhoans { get; set; }
    public DbSet<PhuHuynh> PhuHuynhs { get; set; }
    public DbSet<GiaoVien> GiaoViens { get; set; }
    public DbSet<HocSinh> HocSinhs { get; set; }
    public DbSet<KhoaHoc> KhoaHocs { get; set; }
    public DbSet<BaiHoc> BaiHocs { get; set; }
    public DbSet<BaiTap> BaiTaps { get; set; }
    public DbSet<CauHoiTracNghiem> CauHoiTracNghiems { get; set; }
    public DbSet<BaiNop> BaiNops { get; set; }
    public DbSet<PhanTichAI> PhanTichAIs { get; set; }
    public DbSet<LoiNguPhap> LoiNguPhaps { get; set; }
    public DbSet<PhanHoi> PhanHois { get; set; }
    public DbSet<NhiemVu> NhiemVus { get; set; }
    public DbSet<NhiemVuHocSinh> NhiemVuHocSinhs { get; set; }
    public DbSet<PhanThuong> PhanThuongs { get; set; }
    public DbSet<HocSinh_PhanThuong> HocSinh_PhanThuongs { get; set; }
    public DbSet<TienDo> TienDos { get; set; }
    public DbSet<BangXepHang> BangXepHangs { get; set; }
    public DbSet<BaoCaoZalo> BaoCaoZalos { get; set; }
    public DbSet<TinNhan> TinNhans { get; set; }
    public DbSet<ChuDeChatBot> ChuDeChatBots { get; set; }
    public DbSet<ChatBot_HocSinh> ChatBot_HocSinhs { get; set; }
    public DbSet<NhatKyAI> NhatKyAIs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure composite keys
        modelBuilder.Entity<NhiemVuHocSinh>()
            .HasKey(nvhs => new { nvhs.MaHocSinh, nvhs.MaNhiemVu });

        modelBuilder.Entity<HocSinh_PhanThuong>()
            .HasKey(hspt => new { hspt.MaHocSinh, hspt.MaPhanThuong });

        // Configure relationships for TinNhan to avoid cycles
        modelBuilder.Entity<TinNhan>()
            .HasOne(tn => tn.NguoiGui)
            .WithMany(tk => tk.TinNhanGui)
            .HasForeignKey(tn => tn.MaNguoiGui)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TinNhan>()
            .HasOne(tn => tn.NguoiNhan)
            .WithMany(tk => tk.TinNhanNhan)
            .HasForeignKey(tn => tn.MaNguoiNhan)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure unique constraints
        modelBuilder.Entity<PhanTichAI>()
            .HasIndex(pt => pt.MaBaiNop)
            .IsUnique();

        modelBuilder.Entity<PhanHoi>()
            .HasIndex(ph => ph.MaBaiNop)
            .IsUnique();

        // Configure default values
        modelBuilder.Entity<TaiKhoan>()
            .Property(t => t.NgayTao)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<HocSinh>()
            .Property(h => h.TongDiem)
            .HasDefaultValue(0);

        modelBuilder.Entity<BaiTap>()
            .Property(b => b.DiemToiDa)
            .HasDefaultValue(10);

        modelBuilder.Entity<BaiNop>()
            .Property(b => b.TrangThai)
            .HasDefaultValue("Chờ chấm");

        modelBuilder.Entity<NhiemVu>()
            .Property(n => n.DiemThuong)
            .HasDefaultValue(0);

        modelBuilder.Entity<NhiemVu>()
            .Property(n => n.DangHoatDong)
            .HasDefaultValue(true);

        modelBuilder.Entity<NhiemVuHocSinh>()
            .Property(nvhs => nvhs.TrangThai)
            .HasDefaultValue("Đang giao");

        modelBuilder.Entity<BaoCaoZalo>()
            .Property(bc => bc.TrangThai)
            .HasDefaultValue("Chờ gửi");

        modelBuilder.Entity<ChuDeChatBot>()
            .Property(cd => cd.KichHoat)
            .HasDefaultValue(true);

        modelBuilder.Entity<NhatKyAI>()
            .Property(nk => nk.TrangThai)
            .HasDefaultValue("Thành công");
    }
}
