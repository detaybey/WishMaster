using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class FraudLog
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
    
        public long CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }
    }
}
