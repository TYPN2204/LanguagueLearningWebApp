using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class HocSinh
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaHocSinh { get; set; }

    [ForeignKey("TaiKhoan")]
    public int? MaTaiKhoan { get; set; }

    [ForeignKey("PhuHuynh")]
    public int? MaPhuHuynh { get; set; }

    [Required]
    [MaxLength(100)]
    public string HoTen { get; set; } = string.Empty;

    public DateTime? NgaySinh { get; set; }

    [MaxLength(50)]
    public string? Lop { get; set; }

    [MaxLength(255)]
    public string? Truong { get; set; }

    public int? TongDiem { get; set; }

    [MaxLength(255)]
    public string? AnhDaiDien { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual TaiKhoan? TaiKhoan { get; set; }
    public virtual PhuHuynh? PhuHuynh { get; set; }
    public virtual ICollection<BaiNop> BaiNops { get; set; } = new List<BaiNop>();
    public virtual ICollection<NhiemVuHocSinh> NhiemVuHocSinhs { get; set; } = new List<NhiemVuHocSinh>();
    public virtual ICollection<HocSinh_PhanThuong> HocSinh_PhanThuongs { get; set; } = new List<HocSinh_PhanThuong>();
    public virtual ICollection<TienDo> TienDos { get; set; } = new List<TienDo>();
    public virtual ICollection<BangXepHang> BangXepHangs { get; set; } = new List<BangXepHang>();
    public virtual ICollection<BaoCaoZalo> BaoCaoZalos { get; set; } = new List<BaoCaoZalo>();
    public virtual ICollection<ChatBot_HocSinh> ChatBot_HocSinhs { get; set; } = new List<ChatBot_HocSinh>();
    public virtual ICollection<NhatKyAI> NhatKyAIs { get; set; } = new List<NhatKyAI>();
}
