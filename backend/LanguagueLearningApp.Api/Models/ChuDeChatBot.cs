using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguagueLearningApp.Api.Models;

public class ChuDeChatBot
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaChuDe { get; set; }

    [MaxLength(255)]
    public string? TenChuDe { get; set; }

    public string? MoTa { get; set; }

    public bool? KichHoat { get; set; }

    public DateTime? NgayTao { get; set; }
}
