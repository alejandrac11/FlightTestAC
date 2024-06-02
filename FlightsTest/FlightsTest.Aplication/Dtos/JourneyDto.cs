using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Aplication.Dtos
{
    public class JourneyDto
    {
        public IEnumerable <FlightDto> Flights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Costo { get; set; }
        public void CalculatePrice()
        {
            double costo = 0;
            foreach (var flight in Flights)
            {
                costo = costo + flight.PriceCurrencyCode;
            }
            this.Costo = costo;
        }

    }
}
