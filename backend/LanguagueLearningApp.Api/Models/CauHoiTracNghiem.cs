using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class CauHoiTracNghiem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaCauHoi { get; set; }

    [ForeignKey("BaiTap")]
    public int? MaBaiTap { get; set; }

    public string? NoiDungCauHoi { get; set; }

    public string? LuaChon { get; set; }

    [MaxLength(255)]
    public string? DapAn { get; set; }

    public int? Diem { get; set; }

    // Navigation properties
    public virtual BaiTap? BaiTap { get; set; }
}
