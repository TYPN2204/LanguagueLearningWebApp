using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class BaoCaoZalo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaBaoCao { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    [ForeignKey("PhuHuynh")]
    public int? MaPhuHuynh { get; set; }

    public string? NoiDung { get; set; }

    [MaxLength(20)]
    public string? TrangThai { get; set; }

    [MaxLength(255)]
    public string? Loi { get; set; }

    public DateTime? NgayGui { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
    public virtual PhuHuynh? PhuHuynh { get; set; }
}
