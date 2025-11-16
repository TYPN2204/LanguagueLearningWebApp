using LanguagueLearningApp.Api.Models;

namespace LanguagueLearningApp.Api.Services.Interfaces;

public interface IBaiHocService
{
    Task<IEnumerable<BaiHoc>> GetAllBaiHocsAsync();
    Task<BaiHoc?> GetBaiHocByIdAsync(int id);
    Task<BaiHoc> CreateBaiHocAsync(BaiHoc baiHoc);
    Task UpdateBaiHocAsync(BaiHoc baiHoc);
    Task DeleteBaiHocAsync(int id);
}
