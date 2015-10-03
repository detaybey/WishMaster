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
        public User Seller { get; set;  }

        public float Lat { get; set; }
        public float Lng { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
