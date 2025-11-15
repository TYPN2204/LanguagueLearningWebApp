using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class BaiHoc
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaBaiHoc { get; set; }

    [ForeignKey("KhoaHoc")]
    public int? MaKhoaHoc { get; set; }

    [MaxLength(255)]
    public string? TenBaiHoc { get; set; }

    public int? ThuTu { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual KhoaHoc? KhoaHoc { get; set; }
    public virtual ICollection<BaiTap> BaiTaps { get; set; } = new List<BaiTap>();
    public virtual ICollection<TienDo> TienDos { get; set; } = new List<TienDo>();
}
