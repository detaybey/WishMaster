using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.ViewModels
{
    public class CheckoutModel
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Confirm { get; set; }
        public Product Product { get; set; }
        public User Seller { get; set; }
    }
}
