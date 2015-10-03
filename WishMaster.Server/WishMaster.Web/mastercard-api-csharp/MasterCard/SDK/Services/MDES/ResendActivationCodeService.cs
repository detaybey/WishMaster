using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MasterCard.SDK;
using MasterCard.SDK.Services.MDES.Domain;
using System.Security.Cryptography;

namespace MasterCard.SDK.Services.MDES
{
    public class ResendActivationCodeService : Connector
    {
        private readonly string PRODUCTION_URL = "https://api.mastercard.com/mdes/csrapi/v1/{tokenuniqueid}/activationcode/resend?Format=XML";
        private readonly string MTF_URL = "https://api.mastercard.com/mdes/csrapi/mtf/v1/{tokenuniqueid}/activationcode/resend?Format=XML";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/mdes/csrapi/v1/{tokenuniqueid}/activationcode/resend?Format=XML";

            private Environments.Environment environment;

            public ResendActivationCodeService(string consumerKey, AsymmetricAlgorithm privateKey, Environments.Environment environment)
                : base(consumerKey, privateKey)
            {
                this.environment = environment;
            }

            public ResendCodeResults GetResendCodeResults(ResendRequest resendRequest, String tokenUniqueId)
            {
                string response = "";
                Dictionary<string, string> responseMap = doRequest(GetURL(tokenUniqueId), "POST", Serializer<ResendRequest>.Serialize(resendRequest).InnerXml);
                responseMap.TryGetValue(MESSAGE, out response);
                return Serializer<ResendCodeResults>.Deserialize(response);
            }

            private string GetURL(String tokenUniqueId)
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
                return url.Replace("{tokenuniqueid}",tokenUniqueId);
            }
        }
    
}
