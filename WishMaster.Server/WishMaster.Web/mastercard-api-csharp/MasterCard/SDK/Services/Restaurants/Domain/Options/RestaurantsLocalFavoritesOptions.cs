using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Restaurants.Domain.Options
{
    public class RestaurantsLocalFavoritesOptions
    {
        public int PageOffset { get; set; }
        public int PageLength { get; set; }
        public string Category { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CountrySubdivision { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string DistanceUnit { get; set; }
        public int? Radius { get; set; }

        public RestaurantsLocalFavoritesOptions(int pageOffset, int pageLength)
        {
            PageOffset = pageOffset;
            PageLength = pageLength > 25 ? 25 : pageLength;
        }
    }
}
