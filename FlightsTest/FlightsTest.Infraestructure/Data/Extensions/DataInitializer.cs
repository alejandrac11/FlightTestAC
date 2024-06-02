using FlightsTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTest.Infraestructure.Data.Extensions
{
    public class DataInitializer
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                try
                {
                    if (context.Flights.Any() || context.Transports.Any())
                        return;

                    //recovering flights
                    var path = System.IO.Directory.GetCurrentDirectory();
                    string flightsJSON = System.IO.File.ReadAllText(path + @"\\markets.json");
                    List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(flightsJSON);
                    if (flights != null)
                    {
                        await context.Flights.AddRangeAsync(flights);
                        await context.SaveChangesAsync();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }

        }
    }
}