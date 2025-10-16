using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDtos>> GetAllAsync();
        Task<MenuDtos?> GetByIdAsync(int id);
        Task<MenuDtos> CreateAsync(MenuDtos dto);
        Task<MenuDtos> UpdateAsync(MenuDtos dto);
        Task<bool> DeleteAsync(int id);
        Task<object?> UpdateAsync(NewsDtos dto);
        Task<object?> CreateAsync(NewsDtos dto);
    }
}
