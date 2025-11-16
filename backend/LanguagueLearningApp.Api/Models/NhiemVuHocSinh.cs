using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class NhiemVuHocSinh
{
    [Key, Column(Order = 0)]
    [ForeignKey("HocSinh")]
    public int MaHocSinh { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("NhiemVu")]
    public int MaNhiemVu { get; set; }

    [MaxLength(20)]
    public string? TrangThai { get; set; }

    public DateTime? NgayGiao { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
    public virtual NhiemVu? NhiemVu { get; set; }
}
