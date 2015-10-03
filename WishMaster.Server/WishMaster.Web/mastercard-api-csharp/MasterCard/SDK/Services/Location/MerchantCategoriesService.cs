using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.Location.Domain;

namespace MasterCard.SDK.Services.Location
{
    public class MerchantCategoriesService : Connector
    {
        private Environments.Environment environment;

        private readonly string PRODUCTION_URL = "https://api.mastercard.com/merchants/v1/category?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/merchants/v1/category?Format=XML";

        public MerchantCategoriesService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
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
            if (this.environment == Environments.Environment.PRODUCTION)
            {
                return PRODUCTION_URL;
            }
            else
            {
                return SANDBOX_URL;
            }
        }
    }
}
