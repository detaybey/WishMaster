using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class Score
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int Value { get; set; }
    }
}
