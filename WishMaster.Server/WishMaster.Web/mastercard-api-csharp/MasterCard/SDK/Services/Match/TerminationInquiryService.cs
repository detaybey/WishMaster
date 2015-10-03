using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.Match.Domain;
using MasterCard.SDK.Services.Match.Domain.Options;

using MasterCard.SDK.Util;

namespace MasterCard.SDK.Services.Match
{
    public class TerminationInquiryService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/fraud/merchant/v1/termination-inquiry?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/fraud/merchant/v1/termination-inquiry?Format=XML";

        private Environments.Environment environment;

        public TerminationInquiryService(string consumerKey, AsymmetricAlgorithm privateKey,Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public TerminationInquiry GetTerminationInquiry(TerminationInquiryRequest request, TerminationInquiryRequestOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "POST", Serializer<TerminationInquiryRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<TerminationInquiry>.Deserialize(response);
        }

        private string GetURL(TerminationInquiryRequestOptions options)
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
            url = URLUtil.AddQueryParameter(url, "PageOffset", options.GetPageOffset().ToString(), false, ""); 
            url = URLUtil.AddQueryParameter(url, "PageLength", options.GetPageLength().ToString(), false, ""); 

            return url;
        }
    }
}
