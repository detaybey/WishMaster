using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MasterCard.SDK.Services.MoneySend.Domain;
using MasterCard.SDK.Services.MoneySend.Domain.Options;
using MasterCard.SDK.Util;

namespace MasterCard.SDK.Services.MoneySend
{
    public class CardMappingService: Connector
    {
        private Environments.Environment environment;
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/moneysend/v2/mapping/card?Format=XML";
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/moneysend/v2/mapping/card?Format=XML";

        public CardMappingService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;
        }

        public CreateMapping GetCreateMapping(CreateMappingRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "POST", Serializer<CreateMappingRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<CreateMapping>.Deserialize(response);
        }

        public InquireMapping GetInquireMapping(InquireMappingRequest request)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(), "PUT", Serializer<InquireMappingRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<InquireMapping>.Deserialize(response);
        }

        public UpdateMapping GetUpdateMapping(UpdateMappingRequest request, UpdateMappingRequestOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options.MappingId), "PUT", Serializer<UpdateMappingRequest>.Serialize(request).InnerXml);
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<UpdateMapping>.Deserialize(response);
        }

        public DeleteMapping GetDeleteMapping(DeleteMappingRequestOptions options)
        {
            string response = "";
            Dictionary<string, string> responseMap = doRequest(GetURL(options.MappingId), "DELETE");
            responseMap.TryGetValue(MESSAGE, out response);
            return Serializer<DeleteMapping>.Deserialize(response);
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

        private String GetURL(int? idNumber)
        {
            String url;
            if (this.environment == Environments.Environment.PRODUCTION)
            {
                url = "https://api.mastercard.com/moneysend/v2/mapping/card/{0}";
            }
            else
            {
                url = "https://sandbox.api.mastercard.com/moneysend/v2/mapping/card/{0}";
            }

            url = String.Format(url, idNumber);
            return url;
        }
    }
}
