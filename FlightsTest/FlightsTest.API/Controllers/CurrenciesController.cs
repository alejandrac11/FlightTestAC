using FlightsTest.Aplication.Repositories;
using FlightsTest.Domain.Models;
using FlightsTest.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class CurrenciesController : ControllerBase
    {

        private readonly ILogger<CurrenciesController> _logger;
        private readonly ICurrencyRepository _repository;


        public CurrenciesController(ICurrencyRepository repository, ILogger<CurrenciesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Currency>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Currency>> GetByCode(string code)
        {
            var currency = await _repository.GetByIdAsync(code);
            if (currency == null)
            {
                return  NotFound();
            }
            return Ok(currency);
        }

        // POST: api/Currency
        [HttpPost]
        public async Task<ActionResult<Currency>> AddCurrency(Currency currency)
        {
            var response = await _repository.AddAsync(currency);
            
            if (response != null)
            {
                return Ok("Successfully created currency");
            }
            return BadRequest("Currency could not be created");
        }
    }
}