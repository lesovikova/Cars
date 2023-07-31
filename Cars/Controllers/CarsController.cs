
using Cars.Cars.Models;
using Cars.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsService _carsService;

        public CarsController(CarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = _carsService.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] CreateDTO newCar)
        {
            try
            {
                var car = _carsService.AddCar(newCar);
                return CreatedAtAction(nameof(CreateCar), car);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Could not create new instance");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, [FromBody] UpdateDTO car)
        {
            try
            {
                var updatedCar = _carsService.UpdateCar(id, car);
                return Ok(updatedCar);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Couldn't update the item");
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            try
            {
                _carsService.DeleteCar(id);
                return Ok();
            }
            catch (ArgumentException ex) {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while deleting item");
            }

    
        }
    }
}
