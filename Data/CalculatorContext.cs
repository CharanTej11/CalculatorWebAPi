using CalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CalculatorAPI.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options) { }

        public DbSet<Calculation> Calculations { get; set; }
    }
}
