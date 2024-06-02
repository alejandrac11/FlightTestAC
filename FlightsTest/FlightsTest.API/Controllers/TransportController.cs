using FlightsTest.Aplication.Repositories;
using FlightsTest.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightsTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class TransportController : ControllerBase
    {
        private readonly ILogger<TransportController> _logger;
        private readonly ITransportRepository _repository;


        public TransportController(ITransportRepository repository, ILogger<TransportController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Transport>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> GetByCode(int id)
        {
            var transport = await _repository.GetByIdAsync(id);
            if (transport == null)
            {
                return NotFound();
            }
            return Ok(transport);
        }

        // POST: api/Transport
        [HttpPost]
        public async Task<ActionResult<Transport>> AddTransport(Transport transport)
        {
            var response = await _repository.AddAsync(transport);

            if (response != null)
            {
                return Ok("Flight Transport Selected");
            }
            return BadRequest("Please select the flight transport");
        }
    }
}

