using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class TaiKhoan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaTaiKhoan { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(255)]
    public string? MatKhau { get; set; }

    [MaxLength(20)]
    public string? VaiTro { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? LanDangNhapCuoi { get; set; }

    // Navigation properties
    public virtual PhuHuynh? PhuHuynh { get; set; }
    public virtual GiaoVien? GiaoVien { get; set; }
    public virtual HocSinh? HocSinh { get; set; }
    public virtual ICollection<TinNhan> TinNhanGui { get; set; } = new List<TinNhan>();
    public virtual ICollection<TinNhan> TinNhanNhan { get; set; } = new List<TinNhan>();
}
