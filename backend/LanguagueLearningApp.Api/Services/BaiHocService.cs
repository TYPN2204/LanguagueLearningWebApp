using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class BaiHocService : IBaiHocService
{
    private readonly AppDbContext _context;

    public BaiHocService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BaiHoc>> GetAllBaiHocsAsync()
    {
        return await _context.BaiHocs
            .Include(b => b.KhoaHoc)
            .ToListAsync();
    }

    public async Task<BaiHoc?> GetBaiHocByIdAsync(int id)
    {
        return await _context.BaiHocs
            .Include(b => b.KhoaHoc)
            .FirstOrDefaultAsync(b => b.MaBaiHoc == id);
    }

    public async Task<BaiHoc> CreateBaiHocAsync(BaiHoc baiHoc)
    {
        baiHoc.NgayTao = DateTime.Now;
        baiHoc.ThuTu = baiHoc.ThuTu ?? 0;
        
        _context.BaiHocs.Add(baiHoc);
        await _context.SaveChangesAsync();
        
        return baiHoc;
    }

    public async Task UpdateBaiHocAsync(BaiHoc baiHoc)
    {
        _context.Entry(baiHoc).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await BaiHocExistsAsync(baiHoc.MaBaiHoc))
            {
                throw new KeyNotFoundException($"BaiHoc with ID {baiHoc.MaBaiHoc} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteBaiHocAsync(int id)
    {
        var baiHoc = await _context.BaiHocs.FindAsync(id);
        
        if (baiHoc == null)
        {
            throw new KeyNotFoundException($"BaiHoc with ID {id} not found.");
        }
        
        _context.BaiHocs.Remove(baiHoc);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> BaiHocExistsAsync(int id)
    {
        return await _context.BaiHocs.AnyAsync(b => b.MaBaiHoc == id);
    }
}
