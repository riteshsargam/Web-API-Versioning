using Web_API_Versioning.Models.Domian;

namespace Web_API_Versioning
{
    public class CountriesData
    {
        public static List<Country> Get()
        {
            var countries = new[]
            {
                new Country { Id = 1, Name = "India" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "Canada" },
                new Country { Id = 4, Name = "Brazil" },
                new Country { Id = 5, Name = "Argentina" },
                new Country { Id = 6, Name = "Chile" },
                new Country { Id = 7, Name = "Peru" },
                new Country { Id = 8, Name = "Colombia" },
                new Country { Id = 9, Name = "Venezuela" },
                new Country { Id = 10, Name = "Uruguay" },
            };

            return countries.Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }
    }
}
