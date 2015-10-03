using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Location.Domain.Options
{
    public class CountryMerchantLocationRequestOptions
    {
        private string Details;

        public CountryMerchantLocationRequestOptions(string details)
        {
            this.Details = details;
        }

        public string GetDetails()
        {
            return this.Details;
        }
    }
}
