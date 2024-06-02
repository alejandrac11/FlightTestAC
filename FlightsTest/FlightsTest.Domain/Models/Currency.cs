using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Domain.Models
{
    public class Currency
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string code { get; set; }
        public string name { get; set; }
        public double rate { get; set; }

    }
}
