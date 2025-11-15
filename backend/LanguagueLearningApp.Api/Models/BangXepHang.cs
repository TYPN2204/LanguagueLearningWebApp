using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class BangXepHang
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaBXH { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    public int? TongDiem { get; set; }

    public int? Hang { get; set; }

    [MaxLength(50)]
    public string? KyHan { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
}
