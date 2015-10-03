using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.MDES.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.MDES 
{
    public class SwapPANService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/mdes/csrapi/v1/pan/swap?Format=XML";
        private readonly string MTF_URL = "https://api.mastercard.com/mdes/csrapi/mtf/v1/pan/swap?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/mdes/csrapi/v1/pan/swap?Format=XML";

        private Environments.Environment environment;

        public SwapPANService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Responses GetResponses(SwapPANRequest swapPANRequest)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<SwapPANRequest>.Serialize(swapPANRequest).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Responses>.Deserialize(response);
        }

        private string GetURL()
        {
            string url;
            if (this.environment == Environments.Environment.PRODUCTION)
            {
                url = PRODUCTION_URL;
            }
            else if (this.environment == Environments.Environment.MTF)
            {
                url = MTF_URL;
            }
            else
            {
                url = SANDBOX_URL;
            }
            return url;
        }
    }
}
