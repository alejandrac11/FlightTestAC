using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Domain.Models
{
    public class Journey
    {
        public IEnumerable <Flight> Flights { get; set; }
        public double CalculatePrice(double rateCurrency = 1.0)
        {
            double costo = 0;
            foreach (var flight in Flights)
            {
                costo = costo + flight.Price;
            }
            return costo;
        }

    }
}
