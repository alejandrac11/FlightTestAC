using FlightsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Aplication.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency> GetByIdAsync(string code);
        Task<Currency> AddAsync(Currency entity);
        Task UpdateAsync(Currency entity);
        Task DeleteAsync(string code);
        
    }
}
