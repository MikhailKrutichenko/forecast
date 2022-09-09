using forecast.to;
using weather.model;
using weather.repository;

namespace weather.service
{
    internal class Service
    {
        private CityRepository CityRepository;
        private ForecastRepository ForecastRepository;

        public Service(CityRepository cityRepository, ForecastRepository forecastRepository)
        {
            CityRepository = cityRepository;
            ForecastRepository = forecastRepository;
        }

        public void updateForecasts(string city, List<Forecast> forecasts)
        {
            City entityCity = getCity(city);
            foreach (Forecast forecast in forecasts)
            {
                forecast.CityId = entityCity.Id;
            }
            ForecastRepository.saveForecasts(forecasts);
        }

        public void deleteAllForecast()
        {
            ForecastRepository.deleteForecasts();
        }


        public List<ForecastTo> getForecastsPerDate(string city, string date)
        {
            List<ForecastTo> result = new List<ForecastTo>();
            foreach(Forecast f in ForecastRepository.getPerDate(getCity(city), date))
            {
                result.Add(new ForecastTo(f));
            }
            return result;
        }

        public City getCity(string city)
        {
            return CityRepository.get(city);
        }

        public void populateCities()
        {
            CityRepository.deleteAll();
            CityRepository.save(new City("Paris", "France"));
            CityRepository.save(new City("Moscow", "Russia"));
            CityRepository.save(new City("Oslo", "Norway"));
            CityRepository.save(new City("Berlin", "Germany"));
        }
    }
}
