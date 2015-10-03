using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.Services
{
   public class UserService : BaseService
    {
        public UserService(WishMasterDataContext db)
                 : base(db)
        {

        }

        public User GetUserById(long id)
        {
            return Db.Users.Find(id);
        }

        public User GetUserByNick(string nick)
        {
            return Db.Users.FirstOrDefault(x => x.Nick == nick);
        }
    }
}
