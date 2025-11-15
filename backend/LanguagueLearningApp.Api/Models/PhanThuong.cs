using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class PhanThuong
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaPhanThuong { get; set; }

    [MaxLength(255)]
    public string? TenPhanThuong { get; set; }

    public string? MoTa { get; set; }

    public int? DiemCan { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual ICollection<HocSinh_PhanThuong> HocSinh_PhanThuongs { get; set; } = new List<HocSinh_PhanThuong>();
}
