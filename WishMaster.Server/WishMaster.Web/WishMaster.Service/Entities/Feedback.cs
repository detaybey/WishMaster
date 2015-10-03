using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class Feedback
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public short StarCount { get; set; }
        public string Comment { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
