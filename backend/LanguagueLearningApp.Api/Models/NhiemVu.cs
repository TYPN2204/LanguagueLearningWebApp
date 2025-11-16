using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class NhiemVu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaNhiemVu { get; set; }

    [MaxLength(255)]
    public string? TenNhiemVu { get; set; }

    public string? MoTa { get; set; }

    public int? DiemThuong { get; set; }

    [MaxLength(20)]
    public string? ChuKy { get; set; }

    public bool? DangHoatDong { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual ICollection<NhiemVuHocSinh> NhiemVuHocSinhs { get; set; } = new List<NhiemVuHocSinh>();
}
