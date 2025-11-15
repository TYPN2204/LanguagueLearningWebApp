using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class PhanHoi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaPhanHoi { get; set; }

    [ForeignKey("BaiNop")]
    public int? MaBaiNop { get; set; }

    public string? PhanHoiAI { get; set; }

    public string? NhanXetGV { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual BaiNop? BaiNop { get; set; }
}
