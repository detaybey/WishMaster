using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Location.Domain.Options
{
    public class AtmLocationRequestOptions
    {
        private int PageOffset;
        private int PageLength;

        public static readonly string MILE = "MILE";
        public static readonly string KILOMETER = "KILOMETER";

        public static readonly int SUPPORT_EMV_YES = 1;
        public static readonly int SUPPORT_EMV_NO = 2;
        public static readonly int SUPPORT_EMV_UNKNOWN = 0;

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CountrySubdivision { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string DistanceUnit { get; set; }
        private int _radius;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value > 100)
                {
                    _radius = 100;
                }
                else
                {
                    _radius = value;
                }
            }
        }
        private int _supportEMV = -1;
        public int SupportEMV
        {
            get 
            { 
                return _supportEMV; 
            }
            set 
            {
                this._supportEMV = value;
            }
        }

        public AtmLocationRequestOptions(int pageOffset, int pageLength)
        {
            this.PageOffset = pageOffset;
            this.PageLength = pageLength;

            if (this.PageLength > 25)
            {
                this.PageLength = 25;
            }
        }

        public int getPageOffset()
        {
            return this.PageOffset;
        }

        public int getPageLength()
        {
            return this.PageLength;
        }
    }
}
