using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WishMaster.Service.ViewModels
{
    public class ProductAddModel
    {
        public string sessionid { get; set; }
        public string title { get; set; }
        public string description { get; set;  }
        public long categoryid { get; set; }
        public int daystopurchase { get; set; }
        public int daystoship { get; set; }
        public string country { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int quantity { get; set; } 
        public int price { get; set; }     
    }
}
