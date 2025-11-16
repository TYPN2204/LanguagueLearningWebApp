using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class KhoaHocService : IKhoaHocService
{
    private readonly AppDbContext _context;

    public KhoaHocService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<KhoaHoc>> GetAllKhoaHocsAsync()
    {
        return await _context.KhoaHocs
            .Include(k => k.GiaoVien)
            .ToListAsync();
    }

    public async Task<KhoaHoc?> GetKhoaHocByIdAsync(int id)
    {
        return await _context.KhoaHocs
            .Include(k => k.GiaoVien)
            .FirstOrDefaultAsync(k => k.MaKhoaHoc == id);
    }

    public async Task<KhoaHoc> CreateKhoaHocAsync(KhoaHoc khoaHoc)
    {
        khoaHoc.NgayTao = DateTime.Now;
        
        _context.KhoaHocs.Add(khoaHoc);
        await _context.SaveChangesAsync();
        
        return khoaHoc;
    }

    public async Task UpdateKhoaHocAsync(KhoaHoc khoaHoc)
    {
        _context.Entry(khoaHoc).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await KhoaHocExistsAsync(khoaHoc.MaKhoaHoc))
            {
                throw new KeyNotFoundException($"KhoaHoc with ID {khoaHoc.MaKhoaHoc} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteKhoaHocAsync(int id)
    {
        var khoaHoc = await _context.KhoaHocs.FindAsync(id);
        
        if (khoaHoc == null)
        {
            throw new KeyNotFoundException($"KhoaHoc with ID {id} not found.");
        }
        
        _context.KhoaHocs.Remove(khoaHoc);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> KhoaHocExistsAsync(int id)
    {
        return await _context.KhoaHocs.AnyAsync(k => k.MaKhoaHoc == id);
    }
}
