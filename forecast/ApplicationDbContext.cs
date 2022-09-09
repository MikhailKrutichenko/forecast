using Microsoft.EntityFrameworkCore;
using weather.model;

public class ApplicationDbContext : DbContext
{
    public static string RootPath; 

    public DbSet<City> Cities => Set<City>();
    public DbSet<Forecast> Forecast => Set<Forecast>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Data Source="+ RootPath + "\\db\\CitiesForecast.db");
    }
}