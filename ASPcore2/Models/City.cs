using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPcore2.Models
{
    public partial class City
    {
        public City()
        {
            Journal = new HashSet<Journal>();
        }
        public City(City c)
        {
            if (c != null)
            {
                CityId = c.CityId;
                Name = c.Name;
                Latitude = c.Latitude;
                Longtitude = c.Longtitude;
                CityCountryId = c.CityCountryId;
            }
            Journal = new HashSet<Journal>();
        }
        public int CityId { get; set; }
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longtitude { get; set; }
        public int CityCountryId { get; set; }

        public CityCountry CityCountry { get; set; }
        public ICollection<Journal> Journal { get; set; }
    }
}
