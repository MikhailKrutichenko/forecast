using forecast.to;
using Microsoft.AspNetCore.Mvc;
using weather;
using weather.model;
using weather.repository;
using weather.service;
using weather.Util;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace forecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private Service service;
        private WeatherApiClient weatherApiClient;

        public WeatherForecastController(IHostingEnvironment hostingEnvironment)
        {
            ApplicationDbContext.RootPath = hostingEnvironment.ContentRootPath;
            weatherApiClient = new WeatherApiClient();
            service = new Service(new CityRepository(), new ForecastRepository());
        }

        [Route("forecasts/city")]
        [HttpGet]
        public List<ForecastTo> Get([FromQuery] string cityName, [FromQuery] string date)
        {
            return service.getForecastsPerDate(cityName, date);
        }

        [Route("forecasts/update")]
        [HttpGet]
        public void updateForecast()
        {
            service.deleteAllForecast();
            service.populateCities();
            updateForecast(Ñoordinates.PARIS_LAT, Ñoordinates.PARIS_LON, "Paris");
            updateForecast(Ñoordinates.MOSCOW_LAT, Ñoordinates.MOSCOW_LON, "Moscow");
            updateForecast(Ñoordinates.OSLO_LAT, Ñoordinates.OSLO_LOT, "Oslo");
            updateForecast(Ñoordinates.BERLIN_LAT, Ñoordinates.BERLIN_LOT, "Berlin");
        }

        private void updateForecast(String lat, String lon, String nameCity)
        {
            string response = weatherApiClient.getForecastResultXml(lat, lon);
            service.updateForecasts(nameCity, XmlParser.parseXmlToForecasts(response));
        }
    }
}