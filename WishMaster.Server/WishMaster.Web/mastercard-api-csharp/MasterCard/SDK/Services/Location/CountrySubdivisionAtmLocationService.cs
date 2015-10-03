using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.Location.Domain;
using MasterCard.SDK.Services.Location.Domain.Options;
using MasterCard.SDK.Util;

namespace MasterCard.SDK.Services.Location
{
    public class CountrySubdivisionAtmLocationService : Connector
    {
        private readonly Environments.Environment environment;

        private readonly string PRODUCTION_URL = "https://api.mastercard.com/atms/v1/countrysubdivision?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/atms/v1/countrysubdivision?Format=XML";

        public CountrySubdivisionAtmLocationService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public CountrySubdivisions GetCountrySubdivisions(CountrySubdivisionAtmLocationRequestOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<CountrySubdivisions>.Deserialize(response);
        }

        private string GetURL(CountrySubdivisionAtmLocationRequestOptions options)
        {
            string url;
            if (this.environment == Environments.Environment.PRODUCTION)
            {
                url = PRODUCTION_URL;
            }
            else
            {
                url = SANDBOX_URL;
            }

            return URLUtil.AddQueryParameter(url, "Country", options.GetCountry(), false, null);
        }
    }
}
