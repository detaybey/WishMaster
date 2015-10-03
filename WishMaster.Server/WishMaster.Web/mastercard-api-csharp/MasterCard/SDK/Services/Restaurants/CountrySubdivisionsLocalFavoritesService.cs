using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK;
using System.Security.Cryptography;
using MasterCard.SDK.Util;
using MasterCard.SDK.Services.Restaurants.Domain.Options;
using MasterCard.SDK.Services.Restaurants.Domain;

namespace MasterCard.SDK.Services.Restaurants
{
    public class CountrySubdivisionsLocalFavoritesService : Connector
    {
        private Environments.Environment environment;
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/restaurants/v1/countrysubdivision?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/restaurants/v1/countrysubdivision?Format=XML";

        public CountrySubdivisionsLocalFavoritesService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public CountrySubdivisions GetCountrySubdivisions(CountrySubdivisionsLocalFavoritesOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<CountrySubdivisions>.Deserialize(response);
        }

        private string GetURL(CountrySubdivisionsLocalFavoritesOptions options)
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

            url = URLUtil.AddQueryParameter(url, "Country", options.Country, false, null);
            return url;
        }
    }
}
