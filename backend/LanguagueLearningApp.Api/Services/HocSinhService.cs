using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class HocSinhService : IHocSinhService
{
    private readonly AppDbContext _context;

    public HocSinhService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HocSinh>> GetAllHocSinhsAsync()
    {
        return await _context.HocSinhs
            .Include(h => h.TaiKhoan)
            .Include(h => h.PhuHuynh)
            .ToListAsync();
    }

    public async Task<HocSinh?> GetHocSinhByIdAsync(int id)
    {
        return await _context.HocSinhs
            .Include(h => h.TaiKhoan)
            .Include(h => h.PhuHuynh)
            .FirstOrDefaultAsync(h => h.MaHocSinh == id);
    }

    public async Task<HocSinh> CreateHocSinhAsync(HocSinh hocSinh)
    {
        hocSinh.NgayTao = DateTime.Now;
        hocSinh.TongDiem = hocSinh.TongDiem ?? 0;
        
        _context.HocSinhs.Add(hocSinh);
        await _context.SaveChangesAsync();
        
        return hocSinh;
    }

    public async Task UpdateHocSinhAsync(HocSinh hocSinh)
    {
        _context.Entry(hocSinh).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HocSinhExistsAsync(hocSinh.MaHocSinh))
            {
                throw new KeyNotFoundException($"HocSinh with ID {hocSinh.MaHocSinh} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteHocSinhAsync(int id)
    {
        var hocSinh = await _context.HocSinhs.FindAsync(id);
        
        if (hocSinh == null)
        {
            throw new KeyNotFoundException($"HocSinh with ID {id} not found.");
        }
        
        _context.HocSinhs.Remove(hocSinh);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> HocSinhExistsAsync(int id)
    {
        return await _context.HocSinhs.AnyAsync(h => h.MaHocSinh == id);
    }
}
