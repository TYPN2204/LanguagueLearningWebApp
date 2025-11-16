using Microsoft.EntityFrameworkCore;
using LanguagueLearningApp.Api.Data;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Services;

public class TaiKhoanService : ITaiKhoanService
{
    private readonly AppDbContext _context;

    public TaiKhoanService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaiKhoan>> GetAllTaiKhoansAsync()
    {
        return await _context.TaiKhoans.ToListAsync();
    }

    public async Task<TaiKhoan?> GetTaiKhoanByIdAsync(int id)
    {
        return await _context.TaiKhoans
            .FirstOrDefaultAsync(t => t.MaTaiKhoan == id);
    }

    public async Task<TaiKhoan> CreateTaiKhoanAsync(TaiKhoan taiKhoan)
    {
        taiKhoan.NgayTao = DateTime.Now;
        
        _context.TaiKhoans.Add(taiKhoan);
        await _context.SaveChangesAsync();
        
        return taiKhoan;
    }

    public async Task UpdateTaiKhoanAsync(TaiKhoan taiKhoan)
    {
        _context.Entry(taiKhoan).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await TaiKhoanExistsAsync(taiKhoan.MaTaiKhoan))
            {
                throw new KeyNotFoundException($"TaiKhoan with ID {taiKhoan.MaTaiKhoan} not found.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteTaiKhoanAsync(int id)
    {
        var taiKhoan = await _context.TaiKhoans.FindAsync(id);
        
        if (taiKhoan == null)
        {
            throw new KeyNotFoundException($"TaiKhoan with ID {id} not found.");
        }
        
        _context.TaiKhoans.Remove(taiKhoan);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> TaiKhoanExistsAsync(int id)
    {
        return await _context.TaiKhoans.AnyAsync(t => t.MaTaiKhoan == id);
    }
}
