using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;
using WishMaster.Service.Tools;
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
        /// generate dummy users
        /// </summary>
        public void Init()
        {
            if (Db.Users.Count() < 13)
            {
                Db.Users.Add(new User() { Nick = "Richard", Email = "rich@uaho.com", FullName = "Richard Romero", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "LelePons", Email = "lele@pons.com", FullName = "Lele Pons Suares", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "Smite18", Email = "sm@papa.com", FullName = "John Cash", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "Juliet", Email = "jao@yuaho.com", FullName = "Juliet Nomnom", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "Dominiq", Email = "dodo@uaho.com", FullName = "Dominic Fezlo", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "LeeArc", Email = "lc@hotmail.com", FullName = "Lee Sun Toe", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "SumThinWong", Email = "sumg@babyoil.com", FullName = "Fao Tei Keff", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "TenTonHammer", Email = "tonz@gmail.com", FullName = "Dave Ferazza", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.Users.Add(new User() { Nick = "GotMilk", Email = "milk@white.com", FullName = "Sarah Doodle", Password = "x", Phone = Sandbox.RandomPhoneNumber(), AddressCountry = "USA", AddressLine1 = "123 Main Street", AddressCity = "OFallon", AddressState = "MO", AddressZip = "63368", });
                Db.SaveChanges();
            }
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
