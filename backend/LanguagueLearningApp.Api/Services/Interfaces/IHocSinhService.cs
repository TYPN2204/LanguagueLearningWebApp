using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface IHocSinhService
{
    Task<IEnumerable<HocSinh>> GetAllHocSinhsAsync();
    Task<HocSinh?> GetHocSinhByIdAsync(int id);
    Task<HocSinh> CreateHocSinhAsync(HocSinh hocSinh);
    Task UpdateHocSinhAsync(HocSinh hocSinh);
    Task DeleteHocSinhAsync(int id);
}
