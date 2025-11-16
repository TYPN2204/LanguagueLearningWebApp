using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class NhiemVuService : INhiemVuService
{
    private readonly AppDbContext _context;

    public NhiemVuService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NhiemVu>> GetAllNhiemVusAsync()
    {
        return await _context.NhiemVus.ToListAsync();
    }

    public async Task<NhiemVu?> GetNhiemVuByIdAsync(int id)
    {
        return await _context.NhiemVus
            .FirstOrDefaultAsync(n => n.MaNhiemVu == id);
    }

    public async Task<NhiemVu> CreateNhiemVuAsync(NhiemVu nhiemVu)
    {
        nhiemVu.NgayTao = DateTime.Now;
        nhiemVu.DiemThuong = nhiemVu.DiemThuong ?? 0;
        nhiemVu.DangHoatDong = nhiemVu.DangHoatDong ?? true;
        
        _context.NhiemVus.Add(nhiemVu);
        await _context.SaveChangesAsync();
        
        return nhiemVu;
    }

    public async Task UpdateNhiemVuAsync(NhiemVu nhiemVu)
    {
        _context.Entry(nhiemVu).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await NhiemVuExistsAsync(nhiemVu.MaNhiemVu))
            {
                throw new KeyNotFoundException($"NhiemVu with ID {nhiemVu.MaNhiemVu} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteNhiemVuAsync(int id)
    {
        var nhiemVu = await _context.NhiemVus.FindAsync(id);
        
        if (nhiemVu == null)
        {
            throw new KeyNotFoundException($"NhiemVu with ID {id} not found.");
        }
        
        _context.NhiemVus.Remove(nhiemVu);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> NhiemVuExistsAsync(int id)
    {
        return await _context.NhiemVus.AnyAsync(n => n.MaNhiemVu == id);
    }
}
