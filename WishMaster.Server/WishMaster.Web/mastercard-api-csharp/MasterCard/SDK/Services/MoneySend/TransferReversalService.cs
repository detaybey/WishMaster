using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.MoneySend.Domain;

namespace MasterCard.SDK.Services.MoneySend
{
    public class TransferReversalService : Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/moneysend/v2/transferreversal?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/moneysend/v2/transferreversal?Format=XML";

        public TransferReversalService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public TransferReversal GetTransferReversal(TransferReversalRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<TransferReversalRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<TransferReversal>.Deserialize(response);
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
