using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.Services
{
    public class ScoreService : BaseService
    {
        public UserService UserService { get; set; }

        public ScoreService(WishMasterDataContext db, UserService userService)
            : base(db)
        {
            UserService = userService;
        }


        /// <summary>
        /// set dummy scores for users
        /// </summary>
        public void Init()
        {
            var random = new Random();
            foreach (var user in Db.Users)
            {
                if (user.Scores.Any() == false)
                {
                    var days = random.Next(3, 45);
                    var count = random.Next(3, 8);
                    var scoreValue = random.Next(1, 20);
                    for(var j = 0; j < count; j++)
                    {
                        var score = new Score()
                        {
                            Date = DateTime.Now.AddDays(-1 * days),
                            UserId = user.Id,
                            Value = scoreValue
                        };
                        Db.Scores.Add(score);
                    }
                    Db.SaveChanges();
                }
            }
        }
    }
}
