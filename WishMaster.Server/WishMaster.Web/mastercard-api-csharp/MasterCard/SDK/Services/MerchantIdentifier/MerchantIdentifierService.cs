using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK;
using System.Security.Cryptography;
using MasterCard.SDK.Util;
using MasterCard.SDK.Services.MerchantIdentifier.Domain;
using MasterCard.SDK.Services.MerchantIdentifier.Domain.Options;

namespace MasterCard.SDK.Services.MerchantIdentifier
{
    public class MerchantIdentifierService : Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/merchantid/v1/merchantid?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/merchantid/v1/merchantid?Format=XML";

        /// <summary>
        /// Constructor to obtain API for calling into the Merchant Identifier service
        /// </summary>
        /// <param name="consumerKey">Developer Zone consumer key</param>
        /// <param name="privateKey">PrivateKey</param>
        /// <param name="environment">Environment.sandbox or Environment.product for sandbox access or production access respectively</param>
        public MerchantIdentifierService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountInquiry">HTTP request to send to MasterCard containing the Merchant ID and Type</param>
        /// <returns>MerchantIds - Recognizable merchant descriptors and location information</returns>
        public MerchantIds GetMerchantId(MerchantIdentifierRequestOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options), "GET");
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<MerchantIds>.Deserialize(response);
        }

        private String GetURL(MerchantIdentifierRequestOptions options)
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
            url = URLUtil.AddQueryParameter(url, "MerchantId", options.GetMerchantId(), false, "");
            url = URLUtil.AddQueryParameter(url, "Type", options.Type, false, "");
            return url;
        }
    }
}
