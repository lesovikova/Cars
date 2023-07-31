namespace Cars.Cars.Models
{
    public interface ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string EngineType { get; set; }
        public double EngineSize { get; set; }
    }
}
