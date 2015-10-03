using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK;
using MasterCard.SDK.Services.RepowerReversalService.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.RepowerReversalService
{
    public class RepowerReversalService : Connector
    {
        private readonly Environments.Environment environment;

        private const string SANDBOX_URL = "https://sandbox.api.mastercard.com/repower/v1/repowerreversal?Format=XML";
        private const string PRODUCTION_URL = "https://api.mastercard.com/repower/v1/repowerreversal?Format=XML";

        /// <summary>
        /// Constructs Repower Reversal service
        /// </summary>
        /// <param name="environment">Environment.sandbox or Environment.product for sandbox access or production access respectively</param>
        /// <param name="consumerKey">Developer Zone consumer key</param>
        /// <param name="privateKey">PrivateKey</param>
        public RepowerReversalService(Environments.Environment environment, string consumerKey, AsymmetricAlgorithm privateKey)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Method to return Fraud Scoring reaults based on a ScoreLookupRequest Object
        /// </summary>
        /// <param name="request">ScoreLookupRequest containing query information</param>
        /// <returns>ScoreLookup Object containing scoring information</returns>
        public RepowerReversal getRepowerReveral(RepowerReversalRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(getURL(), "POST", Serializer<RepowerReversalRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<RepowerReversal>.Deserialize(response);
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
