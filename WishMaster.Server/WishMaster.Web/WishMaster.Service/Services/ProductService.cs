using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;
using WishMaster.Service.ViewModels;

namespace WishMaster.Service.Services
{
    public class ProductService : BaseService
    {
        public ProductService(WishMasterDataContext db)
            : base(db)
        {

        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="user">Seller user</param>
        /// <param name="model">Product information</param>
        /// <param name="mediaRoot">Root path for photo</param>
        /// <returns>New created product record</returns>
        public Product Add(User user, ProductAddModel model, string mediaRoot)
        {
            if (model.file == null)
            {
                return null;
            }

            var product = new Product()
            {
                CategoryId = model.categoryid,
                CreateDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(model.daystopurchase),
                EarliestShipDate = DateTime.Now.AddDays(model.daystoship),
                Desc = model.description,
                Lat = model.lat,
                Lng = model.lng,
                Quantity = model.quantity,
                SellerId = user.Id,
                Title = model.title,
                UsdPrice = model.price
            };
            Db.Products.Add(product);
            Db.SaveChanges();

            var savePath = System.IO.Path.Combine(mediaRoot, product.Id.ToString() + ".jpg");
            if (System.IO.File.Exists(savePath))
            {
                System.IO.File.Delete(savePath);
            }
            model.file.SaveAs(savePath);
            return product;
        }
    }

}
 
