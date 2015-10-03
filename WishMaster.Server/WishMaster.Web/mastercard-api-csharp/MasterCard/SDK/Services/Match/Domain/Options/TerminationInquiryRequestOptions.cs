using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Match.Domain.Options
{
    public class TerminationInquiryRequestOptions
    {
        private int pageOffset;
        private int pageLength;

        public TerminationInquiryRequestOptions(int pageOffset, int pageLength)
        {
            this.pageOffset = pageOffset;
            this.pageLength = pageLength;
            if (this.pageLength > 25)
            {
                this.pageLength = 25;
            }
        }

        public int GetPageOffset()
        {
            return this.pageOffset;
        }

        public int GetPageLength()
        {
            return this.pageLength;
        }
    }
}
