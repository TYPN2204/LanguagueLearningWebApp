using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface ICauHoiTracNghiemService
{
    Task<IEnumerable<CauHoiTracNghiem>> GetAllCauHoiTracNghiemsAsync();
    Task<CauHoiTracNghiem?> GetCauHoiTracNghiemByIdAsync(int id);
    Task<CauHoiTracNghiem> CreateCauHoiTracNghiemAsync(CauHoiTracNghiem cauHoiTracNghiem);
    Task UpdateCauHoiTracNghiemAsync(CauHoiTracNghiem cauHoiTracNghiem);
    Task DeleteCauHoiTracNghiemAsync(int id);
}
