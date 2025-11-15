using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class TienDo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaTienDo { get; set; }

    [ForeignKey("HocSinh")]
    public int? MaHocSinh { get; set; }

    [ForeignKey("BaiHoc")]
    public int? MaBaiHoc { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? TiLeHoanThanh { get; set; }

    public DateTime? LanCuoiHoatDong { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
    public virtual BaiHoc? BaiHoc { get; set; }
}
