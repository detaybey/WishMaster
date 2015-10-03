using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using MasterCard.SDK.Util;
using MasterCard.SDK.Services.Match.Domain;
using MasterCard.SDK.Services.Match.Domain.Options;

namespace MasterCard.SDK.Services.Match
{
    public class TerminationInquiryHistoryService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/fraud/merchant/v1/termination-inquiry/XYZ: IRN}?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/fraud/merchant/v1/termination-inquiry/XYZ?Format=XML";

        private Environments.Environment environment;

        public TerminationInquiryHistoryService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public TerminationInquiry GetTerminationInquiry(TerminationInquiryHistoryOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<TerminationInquiry>.Deserialize(response);
        }

        private string GetURL(TerminationInquiryHistoryOptions options)
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

            url = url.Replace("XYZ", options.getInquiryReferenceNumber().ToString());
            url = URLUtil.AddQueryParameter(url, "PageOffset", options.GetPageOffset().ToString(), false, "");
            url = URLUtil.AddQueryParameter(url, "PageLength", options.GetPageLength().ToString(), false, "");
            url = URLUtil.AddQueryParameter(url, "AcquirerId", options.GetAcquirerId().ToString(), false, "");
            return url;
        }
    }
}
