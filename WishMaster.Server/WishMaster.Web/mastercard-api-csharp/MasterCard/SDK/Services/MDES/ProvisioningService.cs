using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.MDES.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.MDES
{
    public class ProvisioningService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/mdes/csrapi/v1/token/provision?Format=XML";
        private readonly string MTF_URL = "https://api.mastercard.com/mdes/csrapi/mtf/v1/token/provision?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/mdes/csrapi/v1/token/provision?Format=XML";

        private Environments.Environment environment;

        public ProvisioningService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Response GetResponse(ProvisioningDomainMarker provisioningDomainMarker)
        {
            string response = "";
            Dictionary<string, string> responseMap;
            if (provisioningDomainMarker.GetType() == typeof(SwapProvisioningRequest))
            {
                string xml = Serializer<SwapProvisioningRequest>.Serialize((SwapProvisioningRequest)provisioningDomainMarker).InnerXml;
                xml = xml.Replace("SwapProvisioningRequest","ProvisioningRequest");
                responseMap = doRequest(GetURL(), "POST", xml);
            }
            else
            {
                string xml = Serializer<GeneralizedProvisioningRequest>.Serialize((GeneralizedProvisioningRequest)provisioningDomainMarker).InnerXml;
                xml = xml.Replace("GeneralizedProvisioningRequest","ProvisioningRequest");
                responseMap = doRequest(GetURL(), "POST", xml);
            }
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Response>.Deserialize(response);
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
