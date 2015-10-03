using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.MerchantIdentifier.Domain.Options
{
    public class MerchantIdentifierRequestOptions
    {
        private String MerchantId;
        public String Type { get; set; }

        public MerchantIdentifierRequestOptions(String merchantId)
        {
            this.MerchantId = merchantId;
        }

        public String GetMerchantId()
        {
            return MerchantId;
        }
    }
}
