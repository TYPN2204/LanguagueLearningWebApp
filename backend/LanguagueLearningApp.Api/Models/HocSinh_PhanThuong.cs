using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class HocSinh_PhanThuong
{
    [Key, Column(Order = 0)]
    [ForeignKey("HocSinh")]
    public int MaHocSinh { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("PhanThuong")]
    public int MaPhanThuong { get; set; }

    public DateTime? NgayNhan { get; set; }

    // Navigation properties
    public virtual HocSinh? HocSinh { get; set; }
    public virtual PhanThuong? PhanThuong { get; set; }
}
