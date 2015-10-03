using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterCard.SDK;
using MasterCard.SDK.Services.LostStolen.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.LostStolen
{
    public class LostStolenService : Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/fraud/loststolen/v1/account-inquiry?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/fraud/loststolen/v1/account-inquiry?Format=XML";

        /// <summary>
        /// Constructor to obtain API for calling into the Lost/Stolen Account List service
        /// </summary>
        /// <param name="consumerKey">Developer Zone consumer key</param>
        /// <param name="privateKey">PrivateKey</param>
        /// <param name="environment">Environment.sandbox or Environment.product for sandbox access or production access respectively</param>
        public LostStolenService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment) : base(consumerKey, privateKey) 
        {
            this.environment = environment;
        }

        /// <summary>
        /// Checks provided credit card against the Lost/Stolen Account List
        /// </summary>
        /// <param name="accountInquiry">XML to send to MasterCard containing the Account Number</param>
        /// <returns>Account - Account Object containing status information</returns>
        public Account GetLostStolen(AccountInquiry accountInquiry)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "PUT", Serializer<AccountInquiry>.Serialize(accountInquiry).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Account>.Deserialize(response);
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
