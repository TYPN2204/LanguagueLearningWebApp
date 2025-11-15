using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class BaiNop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaBaiNop { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    [ForeignKey("BaiTap")]
    public int? MaBaiTap { get; set; }

    public string? BaiLam { get; set; }

    [MaxLength(255)]
    public string? LinkAmThanh { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Diem { get; set; }

    [MaxLength(20)]
    public string? TrangThai { get; set; }

    public DateTime? NgayNop { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
    public virtual BaiTap? BaiTap { get; set; }
    public virtual PhanTichAI? PhanTichAI { get; set; }
    public virtual ICollection<LoiNguPhap> LoiNguPhaps { get; set; } = new List<LoiNguPhap>();
    public virtual PhanHoi? PhanHoi { get; set; }
}
