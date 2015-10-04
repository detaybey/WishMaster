using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.ViewModels
{
   public class HomePageModel
    {
        public List<Product> Products = new List<Product>();
        public List<Category> Categories = new List<Category>();
        public List<User> TopUsers = new List<User>();
        public long SelectedCategoryId = 0;
    }
}
