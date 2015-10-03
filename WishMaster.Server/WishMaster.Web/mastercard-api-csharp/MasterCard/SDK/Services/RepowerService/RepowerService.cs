using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.RepowerService.Domain;

namespace MasterCard.SDK.Services.RepowerService
{
    public class RepowerService : Connector
    {
        private readonly Environments.Environment environment;

        private const string SANDBOX_URL = "https://sandbox.api.mastercard.com/repower/v1/repower?Format=XML";
        private const string PRODUCTION_URL = "https://api.mastercard.com/repower/v1/repower?Format=XML";

        public RepowerService(Environments.Environment environment, string consumerKey, AsymmetricAlgorithm privateKey)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Repower getRepower(RepowerRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(getURL(), "POST", Serializer<RepowerRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Repower>.Deserialize(response);
        }

        private String getURL()
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
