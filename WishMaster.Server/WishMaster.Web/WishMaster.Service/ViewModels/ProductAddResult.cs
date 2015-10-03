using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.ViewModels
{
    public class ProductAddResult
    {
        public ProductAddResult()
        {
            Success = false;
        }
        public bool Success { get; set; }
    }
}
