using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class TinNhan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaTinNhan { get; set; }

    [ForeignKey("NguoiGui")]
    public int? MaNguoiGui { get; set; }

    [ForeignKey("NguoiNhan")]
    public int? MaNguoiNhan { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayGui { get; set; }

    // Navigation properties
    public virtual TaiKhoan? NguoiGui { get; set; }
    public virtual TaiKhoan? NguoiNhan { get; set; }
}
