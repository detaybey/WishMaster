using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Location.Domain.Options
{
    public class CountrySubdivisionAtmLocationRequestOptions
    {
        private string Country;

        public CountrySubdivisionAtmLocationRequestOptions(string country)
        {
            this.Country = country;
        }

        public string GetCountry()
        {
            return this.Country;
        }
    }
}
