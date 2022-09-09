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
            updateForecast(�oordinates.PARIS_LAT, �oordinates.PARIS_LON, "Paris");
            updateForecast(�oordinates.MOSCOW_LAT, �oordinates.MOSCOW_LON, "Moscow");
            updateForecast(�oordinates.OSLO_LAT, �oordinates.OSLO_LOT, "Oslo");
            updateForecast(�oordinates.BERLIN_LAT, �oordinates.BERLIN_LOT, "Berlin");
        }

        private void updateForecast(String lat, String lon, String nameCity)
        {
            string response = weatherApiClient.getForecastResultXml(lat, lon);
            service.updateForecasts(nameCity, XmlParser.parseXmlToForecasts(response));
        }
    }
}