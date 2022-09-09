using weather.model;

namespace forecast.to
{
    public class ForecastTo
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }

        public ForecastTo(Forecast forecast)
        {
            this.Date = forecast.DateFrom.Split("T").First();
            this.Time = forecast.DateTo.Split("T").Last().Replace("Z", "");
            this.Temperature = forecast.Temperature;
            this.Pressure = forecast.Pressure;
        }
    }
}
