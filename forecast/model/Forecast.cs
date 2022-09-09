
namespace weather.model
{
    public class Forecast
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }
    }
}
