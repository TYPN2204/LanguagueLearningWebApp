using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class CauHoiTracNghiemService : ICauHoiTracNghiemService
{
    private readonly AppDbContext _context;

    public CauHoiTracNghiemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CauHoiTracNghiem>> GetAllCauHoiTracNghiemsAsync()
    {
        return await _context.CauHoiTracNghiems
            .Include(c => c.BaiTap)
            .ToListAsync();
    }

    public async Task<CauHoiTracNghiem?> GetCauHoiTracNghiemByIdAsync(int id)
    {
        return await _context.CauHoiTracNghiems
            .Include(c => c.BaiTap)
            .FirstOrDefaultAsync(c => c.MaCauHoi == id);
    }

    public async Task<CauHoiTracNghiem> CreateCauHoiTracNghiemAsync(CauHoiTracNghiem cauHoiTracNghiem)
    {
        cauHoiTracNghiem.Diem = cauHoiTracNghiem.Diem ?? 1;
        
        _context.CauHoiTracNghiems.Add(cauHoiTracNghiem);
        await _context.SaveChangesAsync();
        
        return cauHoiTracNghiem;
    }

    public async Task UpdateCauHoiTracNghiemAsync(CauHoiTracNghiem cauHoiTracNghiem)
    {
        _context.Entry(cauHoiTracNghiem).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CauHoiTracNghiemExistsAsync(cauHoiTracNghiem.MaCauHoi))
            {
                throw new KeyNotFoundException($"CauHoiTracNghiem with ID {cauHoiTracNghiem.MaCauHoi} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteCauHoiTracNghiemAsync(int id)
    {
        var cauHoiTracNghiem = await _context.CauHoiTracNghiems.FindAsync(id);
        
        if (cauHoiTracNghiem == null)
        {
            throw new KeyNotFoundException($"CauHoiTracNghiem with ID {id} not found.");
        }
        
        _context.CauHoiTracNghiems.Remove(cauHoiTracNghiem);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> CauHoiTracNghiemExistsAsync(int id)
    {
        return await _context.CauHoiTracNghiems.AnyAsync(c => c.MaCauHoi == id);
    }
}
