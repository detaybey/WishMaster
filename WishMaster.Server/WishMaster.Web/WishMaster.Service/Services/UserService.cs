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

        public long TryLogin(string nickoremail, string password)
        {
            if (string.IsNullOrEmpty(nickoremail))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }
            var user = Db.Users.Where(x => x.Nick == nickoremail || x.Email == nickoremail)
                               .Where(x => x.Password == password)
                               .FirstOrDefault();

            if(user == null)
            {
                return 0;
            }
            return user.Id;
        }
    }
}
