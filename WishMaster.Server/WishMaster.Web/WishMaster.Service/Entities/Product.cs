using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Desc { get; set; }

        public decimal UsdPrice { get; set; }

        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EarliestShipDate { get; set; }

        public int Quantity { get; set; }

        public long SellerId { get; set; }
        [ForeignKey("SellerId")]
        public User Seller { get; set; }

        public float Lat { get; set; }
        public float Lng { get; set; }

        [StringLength(2)]
        public string CountryCode { get; set; }

        [StringLength(20)]
        public string DestinationCountry { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        public double SellDaysLeft
        {
            get
            {
                var value = Math.Ceiling((DueDate - DateTime.Now).TotalDays);
                if (value < 0) { value = 0; }
                return value;
            }
        }

        [NotMapped]
        public double ShipDaysLeft
        {
            get
            {
                var value = Math.Ceiling((EarliestShipDate - DateTime.Now).TotalDays);
                if (value < 0) { value = 0; }
                return value;
            }
        }


        public string DaysLeftStr(double daysleft)
        {
            if (daysleft > 1)
            {
                return string.Format("{0} days", daysleft);
            }
            else if (daysleft == 1)
            {
                return "1 day";
            }
            else if (daysleft == 0)
            {
                return "Today!";
            }
            else
            {
                return "Not available anymore";
            }
        }
    }
}
