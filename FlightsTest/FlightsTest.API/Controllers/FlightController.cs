using FlightsTest.Aplication.Dtos;
using FlightsTest.Aplication.Repositories;
using FlightsTest.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightsTest.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class FlightController : ControllerBase

    {
        private readonly ILogger<FlightController> _logger;
        private readonly IFlightRepository _repository;


        public FlightController(IFlightRepository repository, ILogger<FlightController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{currency}")]
        public async Task<IEnumerable<FlightDto>> Get(string currency = "USD")
        {
            return await _repository.GetAllDtoAsync(currency);
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAllOrigins()
        {
            return await _repository.GetAllOriginsAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAllDestinations()
        {
            return await _repository.GetAllDestinationsAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<FlightDto>> GetAll()
        {
            return await _repository.GetAllDtoAsync("USD");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetByCode(int id)
        {
            var flight = await _repository.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        // POST: api/Flight
        [HttpPost]
        public async Task<ActionResult<Flight>> AddFlight(Flight flight)
        {
            var response = await _repository.AddAsync(flight);

            if (response != null)
            {
                return Ok("Selected Flight");
            }
            return BadRequest("No flight has been registered");
        }

        [HttpGet("{origin}/{destination}/{currency}")]
        public async Task<ActionResult<List<JourneyDto>>> GetJourney([FromRoute] string origin, string destination, string currency)
        {
            var Journeys = _repository.FlightFinder(origin,destination, currency);
            return Ok(Journeys);
        }

    }
}



    

