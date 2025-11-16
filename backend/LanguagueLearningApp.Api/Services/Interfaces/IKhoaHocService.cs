using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface IKhoaHocService
{
    Task<IEnumerable<KhoaHoc>> GetAllKhoaHocsAsync();
    Task<KhoaHoc?> GetKhoaHocByIdAsync(int id);
    Task<KhoaHoc> CreateKhoaHocAsync(KhoaHoc khoaHoc);
    Task UpdateKhoaHocAsync(KhoaHoc khoaHoc);
    Task DeleteKhoaHocAsync(int id);
}
