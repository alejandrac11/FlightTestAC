using FlightsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Aplication.Repositories
{
    public interface ITransportRepository
    {
        Task<IEnumerable<Transport>> GetAllAsync();
        Task<Transport> GetByIdAsync(int id);
        Task<Transport> AddAsync(Transport entity);
        Task UpdateAsync(Transport entity);
        Task DeleteAsync(int id);

    }
}
