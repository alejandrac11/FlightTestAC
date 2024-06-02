namespace FlightsTest.Tests
{
    using NUnit.Framework;
    using Moq;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using FlightsTest.API.Controllers;  
    using FlightsTest.Domain.Models;      
    using FlightsTest.Aplication.Repositories; 

    [TestFixture]
    public class CurrencyControllerTests
    {
        private Mock<ICurrencyRepository> _mockRepository;
        private Mock<ILogger<CurrenciesController>> _mockLogger;
        private CurrenciesController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ICurrencyRepository>();
            _mockLogger = new Mock<ILogger<CurrenciesController>>();
            _controller = new CurrenciesController(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Get_ReturnsAllCurrencies()
        {
            // Arrange
            var currencies = new List<Currency>
        {
            new Currency { code = "USD", name = "US Dollar" },
            new Currency { code = "EUR", name = "Euro" }
        };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(currencies);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.AreEqual(currencies, result);
        }

        [Test]
        public async Task GetByCode_ExistingCode_ReturnsCurrency()
        {
            // Arrange
            var currency = new Currency { code = "USD", name = "US Dollar" };
            _mockRepository.Setup(repo => repo.GetByIdAsync("USD")).ReturnsAsync(currency);

            // Act
            var result = await _controller.GetByCode("USD");

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetByCode_NonExistingCode_ReturnsNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync("XYZ")).ReturnsAsync((Currency)null);

            // Act
            var result = await _controller.GetByCode("XYZ");

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task AddCurrency_ValidCurrency_ReturnsOk()
        {
            // Arrange
            var currency = new Currency { code = "GBP", name = "British Pound" };
            _mockRepository.Setup(repo => repo.AddAsync(currency)).ReturnsAsync(currency);

            // Act
            var result = await _controller.AddCurrency(currency);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
