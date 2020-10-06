using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class CityCountry
    {
        public CityCountry()
        {
            City = new HashSet<City>();
        }
        public CityCountry(CityCountry c)
        {
            if (c!=null )
            {
                CityCountryId = c.CityCountryId;
                Name = c.Name;
            }
            City = new HashSet<City>();
        }

        public int CityCountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
