using Cars.Cars.Models;
using Microsoft.EntityFrameworkCore;


namespace Cars
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
