using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK;
using MasterCard.SDK.Services.MoneySend.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.MoneySend
{
    public class PanEligibilityService : Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/moneysend/v2/eligibility/pan?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/moneysend/v2/eligibility/pan?Format=XML";

        public PanEligibilityService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public PanEligibility GetPanEligibility(PanEligibilityRequest request)
        {
            string response = "";
            string body = Serializer<PanEligibilityRequest>.Serialize(request).InnerXml;
            Dictionary<string, string> responseMap = doRequest(GetURL(), "PUT", Serializer<PanEligibilityRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<PanEligibility>.Deserialize(response);
        }

        private String GetURL()
        {
            String url;
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
