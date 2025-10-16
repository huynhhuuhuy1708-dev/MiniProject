using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDtos>> GetAllAsync();
        Task<NewsDtos?> GetByIdAsync(int id);
        Task<NewsDtos> CreateAsync(NewsDtos dto);
        Task<NewsDtos> UpdateAsync(NewsDtos dto);
        Task<bool> DeleteAsync(int id);
    }
}
