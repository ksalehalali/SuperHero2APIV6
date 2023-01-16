using Microsoft.EntityFrameworkCore;


namespace SuperHero2.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<SuperHero> SuperHeroes23 { get; set; }

    }
}
