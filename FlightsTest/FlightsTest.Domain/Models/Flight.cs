using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Domain.Models
{
    public class Flight
    {

        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TransportId { get; set; }
        public Transport Transport { get; set; }

    }
}
