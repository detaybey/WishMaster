using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{

    public enum OrderState
    {
        Paid = 1,
        Shipped = 2,
        Cancelled_WaitingForRefund = 200,
        Cancelled_Complete = 201,
        Delivered = 255
    };

    public class Order
    {
        public Order()
        {
            Transactions = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public DateTime Created { get; set; }

        public long SellerId { get; set; }
        [ForeignKey("SellerId")]
        public User Seller { get; set; }

        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public OrderState State { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
