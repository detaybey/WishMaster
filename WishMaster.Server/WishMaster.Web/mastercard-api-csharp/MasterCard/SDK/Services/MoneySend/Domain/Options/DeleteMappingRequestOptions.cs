using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.MoneySend.Domain.Options
{
    public class DeleteMappingRequestOptions
    {
        public int? CardId { get; set; }
        public int? MappingId { get; set; }
    }
}
