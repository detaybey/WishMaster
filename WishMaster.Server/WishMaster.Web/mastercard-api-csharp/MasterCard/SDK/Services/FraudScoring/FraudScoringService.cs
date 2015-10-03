using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.FraudScoring.Domain;

namespace MasterCard.SDK.Services.FraudScoring
{
    public class FraudScoringService : Connector
    {
        private readonly Environments.Environment environment;
        
        private const string SANDBOX_URL = "https://sandbox.api.mastercard.com/fraud/merchantscoring/v1/score-lookup";
        private const string PRODUCTION_URL = "https://api.mastercard.com/fraud/merchantscoring/v1/score-lookup";

        /// <summary>
        /// Constructor to obtain API for calling into the Fraud Scoring service
        /// </summary>
        /// <param name="environment">Environment.sandbox or Environment.product for sandbox access or production access respectively</param>
        /// <param name="consumerKey">Developer Zone consumer key</param>
        /// <param name="privateKey">PrivateKey</param>
        public FraudScoringService(Environments.Environment environment, string consumerKey, AsymmetricAlgorithm privateKey): base(consumerKey,privateKey)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Method to return Fraud Scoring results based on a ScoreLookupRequest Object
        /// </summary>
        /// <param name="request">ScoreLookupRequest containing query information</param>
        /// <returns>ScoreLookup Object containing scoring information</returns>
        public ScoreLookup getScoreLookup(ScoreLookupRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "PUT", Serializer<ScoreLookupRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<ScoreLookup>.Deserialize(response);
        }

        private String GetURL()
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
