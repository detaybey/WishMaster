using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Match.Domain.Options
{
    public class TerminationInquiryHistoryOptions
    {        
        private int pageOffset;
        private int pageLength;
        private int acquirerId;
        private long inquiryReferenceNumber;
    
        public TerminationInquiryHistoryOptions(int pageOffset, int pageLength, int acquirerId, long inquiryReferenceNumber)
        {
            this.pageOffset = pageOffset;
            this.pageLength = pageLength;
            this.acquirerId = acquirerId;
            this.inquiryReferenceNumber = inquiryReferenceNumber;

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

        public int GetAcquirerId()
        {
            return this.acquirerId;
        }

        public long getInquiryReferenceNumber()
        {
            return this.inquiryReferenceNumber;
        }
    }
}
