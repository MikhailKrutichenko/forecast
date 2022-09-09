using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace weather.model
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public City(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        public City(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}
