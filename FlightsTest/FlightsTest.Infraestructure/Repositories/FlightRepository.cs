using FlightsTest.Aplication.Dtos;
using FlightsTest.Aplication.Repositories;
using FlightsTest.Domain.Models;
using FlightsTest.Infraestructure.Data;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Infraestructure.Repositories
{

    public class FlightRepository : IFlightRepository
    {
        private readonly ILogger<FlightRepository> _logger;

        private readonly Context _context;
        private Dictionary<string, List<FlightDto>> flightMap;
        private string _origin, _destination;

        public FlightRepository(Context context, ILogger<FlightRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Flight> AddAsync(Flight entity)
        {
            try
            {
                var result = await _context.Flights.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al añadir vuelo");
            }

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FlightDto>> GetAllDtoAsync(string CurrencyCode = "USD")
        {

            try
            {
                double rate = 1;

                if (!CurrencyCode.Equals("USD"))
                {
                    var currency = _context.Currencies.FirstOrDefault(x => x.code.Equals(CurrencyCode));
                    rate = currency!.rate;
                }

                var flights = await _context.Flights.Include(x => x.Transport).ToListAsync();
                var flightsDtos = new List<FlightDto>();
                foreach (var flight in flights)
                {

                    flightsDtos.Add(new FlightDto
                    {
                        Id = flight.Id,
                        Origin = flight.Origin,
                        Destination = flight.Destination,
                        Price = flight.Price,
                        PriceCurrencyCode = flight.Price * rate,
                        TransportId = flight.TransportId,
                        Transport = flight.Transport.FlightCarrier + flight.Transport.FlightNumber
                    });
                }
                return flightsDtos;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener los datos del vuelo");
            }

            
        }

        public Task<Flight> GetByIdAsync(int id)
        {
            try
            {
                var flight = _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
                return flight;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener el vuelo");
            }
            
        }

        public Task UpdateAsync(Flight entity)
        {
            throw new NotImplementedException();
        }

        public List<Aplication.Dtos.JourneyDto> FlightFinder(string origin, string destination, string currency)
        {
            try
            {
                var flights = GetAllDtoAsync(currency).Result;
                _origin = origin;
                _destination = destination;

                flightMap = new Dictionary<string, List<FlightDto>>();
                foreach (var flight in flights)
                {
                    if (!flightMap.ContainsKey(flight.Origin))
                    {
                        flightMap[flight.Origin] = new List<FlightDto>();
                    }
                    flightMap[flight.Origin].Add(flight);
                }
                var journeys = FindAllJourneys(origin, destination);
                return journeys;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener el itinerario del vuelo");
            }

            

        }

        private List<Aplication.Dtos.JourneyDto> FindAllJourneys(string origin, string destination)
        {
            try
            {
                var results = new List<Aplication.Dtos.JourneyDto>();
                var path = new List<FlightDto>();
                var visited = new HashSet<string>();

                DFS(origin, destination, path, results, visited);

                foreach (var j in results)
                {
                    j.CalculatePrice();
                }

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener precios");
            }
            
        }

        private void DFS(string current, string destination, List<FlightDto> path, List<Aplication.Dtos.JourneyDto> results, HashSet<string> visited)
        {
            try
            {
                if (current == destination)
                {
                    results.Add(new JourneyDto
                    {
                        Flights = new List<FlightDto>(path),
                        Origin = _origin,
                        Destination = _destination
                    });
                    return;
                }

                if (!flightMap.ContainsKey(current))
                {
                    return;
                }
                visited.Add(current);

                foreach (var flight in flightMap[current])
                {
                    if (!visited.Contains(flight.Destination))
                    {
                        path.Add(flight);
                        DFS(flight.Destination, destination, path, results, visited);
                        path.RemoveAt(path.Count - 1);
                    }
                }

                visited.Remove(current);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener destino");
            }
            

        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            try
            {
                return await _context.Flights.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener lista de vuelos");
            }
        }

        public async Task<IEnumerable<string>> GetAllOriginsAsync()
        {
            try
            {
                return await _context.Flights.Select(f => f.Origin).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener lista de vuelos");
            }
        }

        public async Task<IEnumerable<string>> GetAllDestinationsAsync()
        {
            try
            {
                return await _context.Flights.Select(f => f.Destination).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error al obtener lista de destinos");
            }
        }
    }
}
