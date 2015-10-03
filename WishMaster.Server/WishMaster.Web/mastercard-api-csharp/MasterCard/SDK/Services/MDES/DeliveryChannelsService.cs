using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using MasterCard.SDK;
using MasterCard.SDK.Services.MDES.Domain;

namespace MasterCard.SDK.Services.MDES
{
    public class DeliveryChannelsService : Connector
    {
        private Environments.Environment environment;

        private readonly string PRODUCTION_URL = "https://api.mastercard.com/mdes/csrapi/v1/{tokenuniqueid}/deliverychannels?Format=XML";
        private readonly string MTF_URL = "https://api.mastercard.com/mdes/csrapi/mtf/v1/{tokenuniqueid}/deliverychannels?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/mdes/csrapi/v1/{tokenuniqueid}/deliverychannels?Format=XML";

        public DeliveryChannelsService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public DeliveryChannels GetDeliveryChannels(string tokenUniqueId)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(tokenUniqueId), "GET", null);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<DeliveryChannels>.Deserialize(response);
        }

        private string GetURL(string tokenUniqueId)
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
            return url.Replace("{tokenuniqueid}", tokenUniqueId);
        }
    }
}
