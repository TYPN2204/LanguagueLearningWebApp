using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class BaiTap
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaBaiTap { get; set; }

    [ForeignKey("BaiHoc")]
    public int? MaBaiHoc { get; set; }

    [MaxLength(50)]
    public string? Loai { get; set; }

    [MaxLength(255)]
    public string? TieuDe { get; set; }

    public string? CauHoi { get; set; }

    public string? DapAnDung { get; set; }

    public int? DiemToiDa { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual BaiHoc? BaiHoc { get; set; }
    public virtual ICollection<CauHoiTracNghiem> CauHoiTracNghiems { get; set; } = new List<CauHoiTracNghiem>();
    public virtual ICollection<BaiNop> BaiNops { get; set; } = new List<BaiNop>();
}
