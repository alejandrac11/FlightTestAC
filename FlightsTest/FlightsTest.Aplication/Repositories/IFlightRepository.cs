using FlightsTest.Aplication.Dtos;
using FlightsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Aplication.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<IEnumerable<string>> GetAllOriginsAsync();
        Task<IEnumerable<string>> GetAllDestinationsAsync();
        Task<IEnumerable<FlightDto>> GetAllDtoAsync(string currency);
        Task<Flight> GetByIdAsync(int id);
        Task<Flight> AddAsync(Flight entity);
        Task UpdateAsync(Flight entity);
        Task DeleteAsync(int id);
        List<Dtos.JourneyDto> FlightFinder(string origin, string destination, string currrency);


    }
}
