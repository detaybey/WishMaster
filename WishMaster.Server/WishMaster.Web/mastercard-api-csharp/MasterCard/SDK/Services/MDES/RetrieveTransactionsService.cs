using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using MasterCard.SDK.Services;
using MasterCard.SDK.Services.MDES.Domain;

namespace MasterCard.SDK.Services.MDES
{
    public class RetrieveTransactionsService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/mdes/csrapi/v1/retrieveTxs?Format=XML";
        private readonly string MTF_URL = "https://api.mastercard.com/mdes/csrapi/mtf/v1/retrieveTxs?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/mdes/csrapi/v1/retrieveTxs?Format=XML";

        private Environments.Environment environment;

        public RetrieveTransactionsService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public deviceTransaction GetDeviceTransaction(TransactionRequest transactionRequest)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<TransactionRequest>.Serialize(transactionRequest).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<deviceTransaction>.Deserialize(response);
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
