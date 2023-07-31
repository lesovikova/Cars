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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car() { Id=1, Brand = "Toyota", Model="Corolla", Colour="Black", EngineSize=2, EngineType="Hybrid" },
                new Car() { Id=2, Brand = "Honda", Model="Accord", Colour="Blue", EngineSize=1.9, EngineType="Diesel" },
                new Car() { Id=3, Brand = "Ford", Model="F-150", Colour="Blue", EngineSize=5.2, EngineType="Petrol" },
                new Car() { Id=4, Brand = "Toyota", Model="Camry", Colour="Grey", EngineSize=2.5, EngineType="Diesel" },
                new Car() { Id=5, Brand = "Volkswagen", Model="Golf", Colour="White", EngineSize=1.5, EngineType="Hybrid" },
                new Car() { Id=6, Brand = "Honda", Model="CR-V", Colour="Silver", EngineSize=2, EngineType="Hybrid" },
                new Car() { Id=7, Brand = "Honda", Model="Civic", Colour="White", EngineSize=2, EngineType="Petrol" },
                new Car() { Id=8, Brand = "Chevrolet", Model="Silverado", Colour="Silver", EngineSize=5.3, EngineType="Diesel" },
                new Car() { Id=9, Brand = "Mazda", Model="CX-60", Colour="Red", EngineSize=3.3, EngineType="Hybrid" },
                new Car() { Id=10, Brand = "Porsche", Model="911", Colour="Red", EngineSize=3.9, EngineType="Petrol" }
            });
        }
    }
}
