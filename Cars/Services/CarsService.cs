using Cars.Cars.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

namespace Cars.Services
{
    public class CarsService
    {
        private readonly CarContext _context;

        public CarsService(CarContext context)
        {
            _context = context;
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public Car AddCar(CreateDTO car)
        {
            var CarCreate = MapToCar(car);
            _context.Cars.Add(CarCreate);
            _context.SaveChanges();

            return CarCreate;
        }

        public Car UpdateCar(int id, UpdateDTO updatedCar) { 
        
            var carInDB = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carInDB == null)
            {
                throw new ArgumentException("Item not found");
            }
            carInDB.Brand = updatedCar.Brand;
            carInDB.Model = updatedCar.Model;
            carInDB.Colour = updatedCar.Colour;
            carInDB.EngineType = updatedCar.EngineType;
            carInDB.EngineSize = updatedCar.EngineSize;

            _context.SaveChanges();

            return carInDB;
        }


        public void DeleteCar(int id)
        {
            var deletingCar = _context.Cars.FirstOrDefault(c => c.Id == id);

            if (deletingCar == null)
            {
                throw new ArgumentException("Item not found");
            }

            _context.Cars.Remove(deletingCar);
            _context.SaveChanges();
        }

        private Car MapToCar(ICar value)
        {
            return new Car()
            {
                Brand = value.Brand,
                Model = value.Model,
                Colour = value.Colour,
                EngineType = value.EngineType,
                EngineSize = value.EngineSize 
            };
        }
        

    }
}
