using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface INhiemVuService
{
    Task<IEnumerable<NhiemVu>> GetAllNhiemVusAsync();
    Task<NhiemVu?> GetNhiemVuByIdAsync(int id);
    Task<NhiemVu> CreateNhiemVuAsync(NhiemVu nhiemVu);
    Task UpdateNhiemVuAsync(NhiemVu nhiemVu);
    Task DeleteNhiemVuAsync(int id);
}
