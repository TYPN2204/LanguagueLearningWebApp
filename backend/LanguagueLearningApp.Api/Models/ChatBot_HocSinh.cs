using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class ChatBot_HocSinh
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaTinChat { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    public string? NoiDungNguoiDung { get; set; }

    public string? PhanHoiAI { get; set; }

    [MaxLength(100)]
    public string? ChuDe { get; set; }

    [MaxLength(100)]
    public string? YDinh { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DoChinhXac { get; set; }

    public DateTime? ThoiGian { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
}
