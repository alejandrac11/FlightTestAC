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
    public class CurrencyRepository : ICurrencyRepository
    {

        private readonly Context _context;
        private readonly ILogger<CurrencyRepository> _logger;

        public CurrencyRepository(Context context, ILogger<CurrencyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Currency> AddAsync(Currency entity)
        {
            try
            {
                _context.Currencies.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("No se pudo agregar una moneda");
            }
            
            return entity;
        }

        public Task DeleteAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            try
            {
                return await _context.Currencies.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("No se pudo obtener las monedas");
            }
        }

        public Task<Currency> GetByIdAsync(string code)
        {
            try
            {
                var currency = _context.Currencies.FirstOrDefaultAsync(f => f.code == code);
                return currency;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("NO se pudo obtener la moneda");
            }
        }

        public Task UpdateAsync(Currency entity)
        {
            throw new NotImplementedException();
        }
    }
}
