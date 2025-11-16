using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class NhatKyAI
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaNhatKy { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    [MaxLength(255)]
    public string? HanhDong { get; set; }

    public string? KetQua { get; set; }

    [MaxLength(50)]
    public string? TrangThai { get; set; }

    public DateTime? ThoiGian { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
}
