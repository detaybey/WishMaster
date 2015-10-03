using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterCard.SDK.Services.Location.Domain.Options
{
    public class MerchantLocationsRequestOptions
    {
        public static readonly string MILE = "mile";
        public static readonly string KILOMETER = "kilometer";

        public string Category { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CountrySubdivision { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
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
        public long MerchantId { get; set; }

        private string Details;
        private int PageOffset;
        private int PageLength;
        private int InternationalMaestroAccepted = -1;

        public MerchantLocationsRequestOptions(string details, int pageOffset, int pageLength)
        {
            this.Details = details;
            this.PageOffset = pageOffset;
            this.PageLength = pageLength;

            if (this.PageLength > 25)
            {
                this.PageLength = 25;
            }
        }

        public string GetDetails()
        {
            return this.Details;
        }

        public int GetPageLength()
        {
            return this.PageLength;
        }

        public int GetPageOffset()
        {
            return this.PageOffset;
        }

        public void SetInternationalMaestroAccepted(bool isAccepted)
        {
            if (isAccepted)
            {
                this.InternationalMaestroAccepted = 1;
            }
            else
            {
                this.InternationalMaestroAccepted = -1;
            }
        }

        public int GetInternationalMaestroAccepted()
        {
            return this.InternationalMaestroAccepted;
        }
    }
}
