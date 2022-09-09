using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using weather.model;

namespace weather.repository
{
    public class ForecastRepository
    {
        public void saveForecasts(List<Forecast> forecasts)
        {
            using (ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                foreach (Forecast forecast in forecasts)
                {
                    contextDb.Forecast.Add(forecast);
                }
                contextDb.SaveChanges();
            }
        }

        public List<Forecast> getPerDate(City city, string date)
        {
            using(ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                date = date + "%";
                int cityId = city.Id;
                return contextDb.Forecast.FromSqlRaw<Forecast>("SELECT * FROM Forecast WHERE CityId = @cityId AND DateFrom LIKE @date",
                    new SqliteParameter("@cityId", cityId),
                    new SqliteParameter("@date", date)).ToList();
            }
        }

        public void deleteForecasts()
        {
            using (ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                contextDb.Database.ExecuteSqlRaw("DELETE FROM Forecast");
                contextDb.SaveChanges();
            }
        }
    }
}

