namespace AstroData.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DistanceFromSunKm { get; set; }
        public decimal DiameterKm { get; set; }
    }
}