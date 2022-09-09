using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using weather.model;

namespace weather.repository
{
    internal class CityRepository
    {
        public void save(City city)
        {
            using (ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                contextDb.Cities.Add(city);
                contextDb.SaveChanges();
            }
        }

        public City get(string name)
        {
            using (ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                return contextDb.Cities.FromSqlRaw<City>("SELECT * FROM Cities WHERE name = @name", 
                    new SqliteParameter("@name", name)).Single<City>();
            }
        }

        public void deleteAll()
        {
            using (ApplicationDbContext contextDb = new ApplicationDbContext())
            {
                contextDb.Database.ExecuteSqlRaw("DELETE FROM Cities");
                contextDb.SaveChanges();
            }
        }
    }
}
