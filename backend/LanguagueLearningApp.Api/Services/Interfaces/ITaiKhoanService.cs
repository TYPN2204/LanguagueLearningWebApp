using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface ITaiKhoanService
{
    Task<IEnumerable<TaiKhoan>> GetAllTaiKhoansAsync();
    Task<TaiKhoan?> GetTaiKhoanByIdAsync(int id);
    Task<TaiKhoan> CreateTaiKhoanAsync(TaiKhoan taiKhoan);
    Task UpdateTaiKhoanAsync(TaiKhoan taiKhoan);
    Task DeleteTaiKhoanAsync(int id);
}
