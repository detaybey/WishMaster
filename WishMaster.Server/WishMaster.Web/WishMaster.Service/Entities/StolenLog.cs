using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class StolenLog
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        [StringLength(1)]
        public string Flag { get; set; }
        [StringLength(10)]
        public string FlagDesc { get; set; }

        public long CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }
    }
}
