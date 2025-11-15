using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class LoiNguPhap
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaLoi { get; set; }

    [ForeignKey("BaiNop")]
    public int? MaBaiNop { get; set; }

    [MaxLength(255)]
    public string? DoanLoi { get; set; }

    [MaxLength(255)]
    public string? GoiYSua { get; set; }

    [MaxLength(100)]
    public string? LoaiLoi { get; set; }

    public int? ViTriBatDau { get; set; }

    public int? ViTriKetThuc { get; set; }

    // Navigation properties
    public virtual BaiNop? BaiNop { get; set; }
}
