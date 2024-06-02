using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Domain.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }

    }
}
