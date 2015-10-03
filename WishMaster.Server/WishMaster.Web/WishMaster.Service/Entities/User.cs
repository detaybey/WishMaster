using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Cards = new HashSet<Card>();
            Products = new HashSet<Product>();
            Products = new HashSet<Product>();
            Scores = new HashSet<Score>();
            Feedbacks = new HashSet<Feedback>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Nick { get; set; }

        // TODO: Hash+Salt this
        [StringLength(14)]
        public string Password { get; set; }

        [StringLength(50)]
        public string AddressLine1 { get; set;  }
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        [StringLength(25)]
        public string AddressCity { get; set; }
        [StringLength(10)]
        public string AddressZip { get; set; }
        [StringLength(3)]
        public string AddressCountry { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
