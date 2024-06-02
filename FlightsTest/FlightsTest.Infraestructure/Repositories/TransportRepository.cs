using FlightsTest.Aplication.Repositories;
using FlightsTest.Domain.Models;
using FlightsTest.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Infraestructure.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly ILogger<CurrencyRepository> _logger;
        private readonly Context _context;

        public TransportRepository(Context context, ILogger<CurrencyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Transport> AddAsync(Transport entity)
        {
            try
            {
                var result = await _context.Transports.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al añadir transporte");
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transport>> GetAllAsync()
        {
            try
            {
                return await _context.Transports.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener transportes");
            }
        }

        public Task<Transport> GetByIdAsync(int id)
        {
            try
            {
                var transport = _context.Transports.FirstOrDefaultAsync(f => f.Id == id);
                return transport;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener transporte");
            }
        }

        public Task UpdateAsync(Transport entity)
        {
            throw new NotImplementedException();
        }
    }
}
