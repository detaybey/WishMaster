using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.Restaurants.Domain.Options;
using MasterCard.SDK.Util;

namespace MasterCard.SDK.Services.Restaurants
{
    public class RestaurantsLocalFavoritesService : Connector
    {
        private Environments.Environment environment;
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/restaurants/v1/restaurant?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/restaurants/v1/restaurant?Format=XML";

        public RestaurantsLocalFavoritesService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Restaurants.Domain.Restaurants GetRestaurants(RestaurantsLocalFavoritesOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Restaurants.Domain.Restaurants>.Deserialize(response);
        }

        private string GetURL(RestaurantsLocalFavoritesOptions options)
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

            url = URLUtil.AddQueryParameter(url, "PageOffset", options.PageOffset.ToString(), false, null);
            url = URLUtil.AddQueryParameter(url, "PageLength", options.PageLength.ToString(), false, null);
            url = URLUtil.AddQueryParameter(url, "Category", options.Category, false, null);
            url = URLUtil.AddQueryParameter(url, "AddressLine1", options.AddressLine1, false, null);
            url = URLUtil.AddQueryParameter(url, "AddressLine2", options.AddressLine2, false, null);
            url = URLUtil.AddQueryParameter(url, "City", options.City, false, null);
            url = URLUtil.AddQueryParameter(url, "CountrySubdivision", options.CountrySubdivision, false, null);
            url = URLUtil.AddQueryParameter(url, "PostalCode", options.PostalCode, false, null);
            url = URLUtil.AddQueryParameter(url, "Country", options.Country, false, null);
            url = URLUtil.AddQueryParameter(url, "Latitude", options.Latitude == null ? options.Latitude.ToString() : null, false, null);
            url = URLUtil.AddQueryParameter(url, "Longitude", options.Longitude == null ? options.Longitude.ToString() : null, false, null);
            url = URLUtil.AddQueryParameter(url, "DistanceUnit", options.DistanceUnit, false, null);
            url = URLUtil.AddQueryParameter(url, "Radius", options.Radius == null ? options.Radius.ToString() : null, false, null);
            
            return url;
        }
    }
}
