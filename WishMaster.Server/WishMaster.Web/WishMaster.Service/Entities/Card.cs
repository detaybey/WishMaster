using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class Card
    {
        public Card()
        {
            Transactions = new HashSet<Transaction>();
            FraudLogs = new HashSet<FraudLog>();
            StolenLogs = new HashSet<StolenLog>();
        }
        public long Id { get; set; }

        public long OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        [StringLength(20)]
        public string Number { get; set; }
        [StringLength(2)]
        public string ExpMonth { get; set; }
        [StringLength(4)]
        public string ExpYear { get; set; }
        [StringLength(3)]
        public string CCV { get; set; }

        [StringLength(22)]
        public string AcceptorName { get; set; }
        [StringLength(13)]
        public string AcceptorCity { get; set; }
        [StringLength(2)]
        public string AcceptorState { get; set; }
        [StringLength(10)]
        public string AcceptorPostalCode { get; set; }
        [StringLength(3)]
        public string AcceptorCountry { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<FraudLog> FraudLogs { get; set; }
        public ICollection<StolenLog> StolenLogs { get; set; }
    }
}
