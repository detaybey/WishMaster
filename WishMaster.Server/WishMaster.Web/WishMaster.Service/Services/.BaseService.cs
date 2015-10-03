using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;

namespace WishMaster.Service.Services
{
    public class BaseService
    {
        public WishMasterDataContext Db { get; set; }
        public BaseService(WishMasterDataContext db)
        {
            Db = db;
        }
    }
}
