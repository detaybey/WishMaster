using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MasterCard.SDK;
using MasterCard.SDK.Util;
using MasterCard.SDK.Services.Common.Domain;

namespace MasterCard.SDK.Services.Common
{
    public class RequestTokenService : Connector
    {
        private const String NULL_RESPONSE_PARAMETERS_ERROR = "ResponseParameters can not be null.";

        //Request Token Response
        private const String XOAUTH_REQUEST_AUTH_URL = "xoauth_request_auth_url";
        private const String OAUTH_CALLBACK_CONFIRMED = "oauth_callback_confirmed";
        private const String OAUTH_EXPIRES_IN = "oauth_expires_in";

        //Request Token Response
        private const String OAUTH_TOKEN_SECRET = "oauth_token_secret";

        // Callback URL parameters
        private const String OAUTH_TOKEN = "oauth_token";
        private const String OAUTH_VERIFIER = "oauth_verifier";
        private const String CHECKOUT_RESOURCE_URL = "checkout_resource_url";
        private const String OAUTH_CALLBACK = "oauth_callback";

        private readonly string PRODUCTION_URL = "https://api.mastercard.com/oauth/consumer/v1/request_token";
        private readonly string SANDBOX_URL = "https://sandbox.api.mastercard.com/oauth/consumer/v1/request_token";

        private readonly Environments.Environment environment;

        public RequestTokenService(Environments.Environment environment, string consumerKey, AsymmetricAlgorithm privateKey)
            : base(consumerKey, privateKey)
        {
            this.environment = environment;

            // ignore possible security certificate errors
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        protected static AsymmetricAlgorithm GetPrivateKey(string keystorePath, string keystorePassword)
        {
            X509Certificate2 mcIssuedCertificate = new X509Certificate2(keystorePath, keystorePassword);
            return mcIssuedCertificate.PrivateKey;
        }

        protected override OAuthParameters OAuthParametersFactory()
        {
            OAuthParameters oap = base.OAuthParametersFactory();
            oap.put(RequestTokenService.REALM, "eWallet");
            return oap;
        }

        /// <summary>
        /// SDK: 
        /// Get the user's request token and store it in the current user session.
        /// </summary>
        public RequestTokenResponse GetRequestTokenReponse(string callbackUrl = "http://www.google.com")
        {
            var oauthParams = OAuthParametersFactory();
            oauthParams.addParameter(OAUTH_CALLBACK, callbackUrl);
            //oauthParams.addParameter(REALM, "eWallet");

            var resp = doRequest(GetURL(), WebRequestMethods.Http.Post, oauthParams, null);
            var returnParams = parseOAuthResponseParameters(resp[Connector.MESSAGE]);

            var response = new RequestTokenResponse();
            response.AuthorizeUrl = HttpUtility.UrlDecode(returnParams["xoauth_request_auth_url"]);
            response.RequestToken = returnParams["oauth_token"];
            response.CallbackConfirmed = ("true" == returnParams["oauth_callback_confirmed"]);
            response.OAuthExpiresIn = returnParams["oauth_expires_in"];
            response.OAuthSecret = returnParams["oauth_token_secret"];
            return response;
        }

        private string GetURL()
        {
            string url;
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
