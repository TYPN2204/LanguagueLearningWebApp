using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class KhoaHoc
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaKhoaHoc { get; set; }

    [MaxLength(255)]
    public string? TenKhoaHoc { get; set; }

    [MaxLength(50)]
    public string? CapDo { get; set; }

    public string? MoTa { get; set; }

    [ForeignKey("GiaoVien")]
    public int? MaGiaoVien { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual GiaoVien? GiaoVien { get; set; }
    public virtual ICollection<BaiHoc> BaiHocs { get; set; } = new List<BaiHoc>();
}
