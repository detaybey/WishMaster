using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.MoneySend.Domain;

namespace MasterCard.SDK.Services.MoneySend
{
    public class TransferService : Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/moneysend/v2/transfer?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/moneysend/v2/transfer?Format=XML";

        public TransferService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public Transfer GetTransfer(TransferRequest transferRequest)
        {
            //Determine if TransferRequest is specifying card account number or mapped account
            if (transferRequest.FundingMapped.SubscriberId == null)
            {
                transferRequest.FundingMapped = null;
            }
            else
            {
                transferRequest.SenderAddress = null;
                transferRequest.FundingCard = null;
            }
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<TransferRequest>.Serialize(transferRequest).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Transfer>.Deserialize(response);
        }

        public Transfer GetTransfer(PaymentRequest paymentRequest)
        {
            //Determine if PaymentRequest is specifying card account number or mapped account
            if (paymentRequest.ReceivingMapped.SubscriberId == null)
            {
                paymentRequest.ReceivingMapped = null;
            }
            else
            {
                paymentRequest.ReceivingCard = null;
            }
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<PaymentRequest>.Serialize(paymentRequest).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<Transfer>.Deserialize(response);
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
