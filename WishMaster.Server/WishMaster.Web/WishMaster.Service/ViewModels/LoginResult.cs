using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.ViewModels
{
    public class LoginResult
    {
        public LoginResult()
        {
            Success = false;
        }

        public long UserId { get; set; }
        public Boolean Success { get; set; }
        public dynamic Categories { get; set; }
    }
}
