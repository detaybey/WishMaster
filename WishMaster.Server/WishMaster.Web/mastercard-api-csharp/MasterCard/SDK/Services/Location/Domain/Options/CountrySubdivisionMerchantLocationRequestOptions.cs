using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Location.Domain.Options
{
    public class CountrySubdivisionMerchantLocationRequestOptions
    {
        private string Details;
        private string Country;

        public CountrySubdivisionMerchantLocationRequestOptions(string details, string country)
        {
            this.Details = details;
            this.Country = country;
        }

        public string GetDetails()
        {
            return this.Details;
        }

        public string GetCountry()
        {
            return this.Country;
        }
    }
}
