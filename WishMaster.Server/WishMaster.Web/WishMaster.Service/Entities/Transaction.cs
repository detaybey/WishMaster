using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public enum TransactionType
    {
        Charge_Buyer=1,
        Fund_Seller=2
    }

    public class Transaction
    {
        public long Id { get; set; }
        public Guid Hash { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }

        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public long CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }

        public decimal UsdAmount { get; set; }

        public int? RequestId { get; set; }
        public long? TransactionReference { get; set; }
        [StringLength(20)]
        public string PaymentId { get; set; }
        [StringLength(20)]
        public string AuthCode { get; set; }
        public bool Approved { get; set; }
    }
}
