using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Domain.Models
{
    public class ListJourney
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double RateCurrency { get; set; }
        public ICollection<Journey> Journeys { get; set; }

        public void CalculateJourneys()
        {

        }
    }
}
