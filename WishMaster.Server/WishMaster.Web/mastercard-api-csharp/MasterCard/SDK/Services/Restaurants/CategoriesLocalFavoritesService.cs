using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK.Services.Restaurants.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.Restaurants
{
    public class CategoriesLocalFavoritesService : Connector
    {
        private Environments.Environment environment;
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/restaurants/v1/category?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/restaurants/v1/category?Format=XML";

        public CategoriesLocalFavoritesService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Categories GetCategories()
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Categories>.Deserialize(response);
        }

        private string GetURL()
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

            return url;
        }
    }
}
