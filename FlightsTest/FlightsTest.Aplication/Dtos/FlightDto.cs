using FlightsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Aplication.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public double PriceCurrencyCode { get; set; }
        public int TransportId { get; set; }
        public string Transport { get; set; }
    }
}
