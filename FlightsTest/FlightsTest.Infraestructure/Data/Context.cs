using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightsTest.Domain.Models;

namespace FlightsTest.Infraestructure.Data
{
    public class Context: DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Transport> Transports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
