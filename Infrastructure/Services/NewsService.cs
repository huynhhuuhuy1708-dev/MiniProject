using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class NewsService : INewsService
{
    private readonly AppDbContext _context;
    public NewsService(AppDbContext context) => _context = context;

    public async Task<IEnumerable<NewsDtos>> GetAllAsync() =>
        await _context.Menus.Select(m => new NewsDtos { Id = m.Id, Title = m.Title }).ToListAsync();

    public async Task<NewsDtos?> GetByIdAsync(int id)
    {
        var menu = await _context.Menus.FindAsync(id);
        return menu == null ? null : new NewsDtos { Id = menu.Id, Title = menu.Title };
    }

    public async Task<NewsDtos> CreateAsync(NewsDtos dto)
    {
        var menu = new Menu { Title = dto.Title };
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
        dto.Id = menu.Id;
        return dto;
    }

    public async Task<NewsDtos> UpdateAsync(NewsDtos dto)
    {
        var menu = await _context.Menus.FindAsync(dto.Id);
        if (menu == null) throw new Exception("Not found");

        menu.Title = dto.Title;
        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu == null) return false;

        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
        return true;
    }
}
