using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class PhanTichAI
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaPhanTich { get; set; }

    [ForeignKey("BaiNop")]
    public int? MaBaiNop { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DoChinhXacPhatAm { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DoChinhXacNguPhap { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DoLuuLoat { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DoDaDangTuVung { get; set; }

    public string? NhanXetAI { get; set; }

    public string? ChiTiet { get; set; }

    public DateTime? NgayPhanTich { get; set; }

    // Navigation properties
    public virtual BaiNop? BaiNop { get; set; }
}
