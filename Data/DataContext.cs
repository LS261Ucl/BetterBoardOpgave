using BetterboardOpgave.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterboardOpgave.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperheroQoute> SuperheroQoutes { get; set; }
    }
}
