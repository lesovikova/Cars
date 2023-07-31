
namespace Cars.Cars.Models
{
    public class CreateDTO : ICar
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string EngineType { get; set; }
        public double EngineSize { get; set; }
    }
}
