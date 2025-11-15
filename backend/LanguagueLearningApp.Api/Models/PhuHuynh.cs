using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class PhuHuynh
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaPhuHuynh { get; set; }

    [ForeignKey("TaiKhoan")]
    public int? MaTaiKhoan { get; set; }

    [MaxLength(100)]
    public string? HoTen { get; set; }

    [MaxLength(20)]
    public string? SoDienThoai { get; set; }

    [MaxLength(100)]
    public string? ZaloID { get; set; }

    public DateTime? NgayTao { get; set; }

    // Navigation properties
    public virtual TaiKhoan? TaiKhoan { get; set; }
    public virtual ICollection<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();
    public virtual ICollection<BaoCaoZalo> BaoCaoZalos { get; set; } = new List<BaoCaoZalo>();
}
