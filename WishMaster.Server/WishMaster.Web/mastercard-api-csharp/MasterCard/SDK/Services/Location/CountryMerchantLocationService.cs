using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.Location.Domain;
using MasterCard.SDK.Services.Location.Domain.Options;

namespace MasterCard.SDK.Services.Location
{
    public class CountryMerchantLocationService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/merchants/v1/country?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/merchants/v1/country?Format=XML";

        private Environments.Environment environment;

        public CountryMerchantLocationService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Countries GetCountries()
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Countries>.Deserialize(response);
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
