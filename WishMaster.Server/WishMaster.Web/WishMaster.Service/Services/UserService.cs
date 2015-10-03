using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;
using WishMaster.Service.ViewModels;

namespace WishMaster.Service.Services
{
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : BaseService
    {
        public UserService(WishMasterDataContext db)
                 : base(db)
        {

        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>User object / or null</returns>
        public User GetUserById(long id)
        {
            return Db.Users.Find(id);
        }

        /// <summary>
        /// Returns user by nick
        /// </summary>
        /// <param name="nick">nick of user</param>
        /// <returns>User object / or null</returns>
        public User GetUserByNick(string nick)
        {
            return Db.Users.FirstOrDefault(x => x.Nick == nick);
        }


        /// <summary>
        /// Gets a user by session id
        /// </summary>
        /// <param name="sessionid">session guid</param>
        /// <returns>User object / or null</returns>
        public User GetUserBySessionId(string sessionid)
        {
            return Db.Users.FirstOrDefault(x => x.SessionId == sessionid);
        }


        /// <summary>
        /// Tests user credentials against database and returns a LoginResult object
        /// </summary>
        /// <param name="model">Contains the user credentials</param>
        /// <param name="mobile">Is this a mobile login?</param>
        /// <returns>LoginResult object</returns>
        public LoginResult TryLogin(LoginModel model, bool mobile = false)
        {
            var result = new LoginResult();

            if (string.IsNullOrEmpty(model.username))
            {
                return result;
            }
            if (string.IsNullOrEmpty(model.password))
            {
                return result;
            }
            var user = Db.Users.Where(x => x.Nick == model.username || x.Email == model.username)
                               .Where(x => x.Password == model.password)
                               .FirstOrDefault();

            if (user != null)
            {
                user.SessionId = Guid.NewGuid().ToString();
                Db.SaveChanges();

                result.Success = true;
                result.UserId = user.Id;
                if (mobile)
                {
                    result.SessionId = user.SessionId;
                    result.Categories = Db.Categories.Select(x => new { id = x.Id, name = x.Name }).ToArray();
                }
            }
            return result;
        }
    }
}
