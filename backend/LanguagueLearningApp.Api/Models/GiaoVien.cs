using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class GiaoVien
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaGiaoVien { get; set; }

    [ForeignKey("TaiKhoan")]
    public int? MaTaiKhoan { get; set; }

    [MaxLength(100)]
    public string? HoTen { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(255)]
    public string? Truong { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual TaiKhoan? TaiKhoan { get; set; }
    public virtual ICollection<KhoaHoc> KhoaHocs { get; set; } = new List<KhoaHoc>();
}
