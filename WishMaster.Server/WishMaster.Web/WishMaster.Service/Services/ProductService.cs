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

        public CardService CardService { get; set; }

        public ProductService(WishMasterDataContext db, CardService cardService)
            : base(db)
        {
            CardService = cardService;
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="user">Seller user</param>
        /// <param name="model">Product information</param>
        /// <param name="mediaRoot">Root path for photo</param>
        /// <returns>New created product record</returns>
        public Product Add(User user, ProductAddModel model)
        {
            // if no category was picked select other
            if (model.categoryid == 0)
            {
                var other = Db.Categories.FirstOrDefault(x => x.Name == "Other");
                model.categoryid = other.Id;
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
                UsdPrice = model.price,
                CountryCode = "TR",
                DestinationCountry = model.country
            };
            Db.Products.Add(product);
            Db.SaveChanges();

            return product;
        }


        /// <summary>
        /// Creates an order using a product
        /// </summary>
        /// <param name="buyer">Buyer user</param>
        /// <param name="productId">productid</param>
        /// <returns>New created order record</returns>
        public Order Buy(User buyer, long productId)
        {
            var product = Db.Products.Find(productId);

            var payment = CardService.ChargeBuyer(buyer, product);
            var approved = payment.PaymentStatus == "APPROVED";
            if (!approved)
            {
                return null;
            }
            var buyerCard = buyer.Cards.First();
            var order = new Order()
            {
                Created = DateTime.Now,
                CustomerId = buyer.Id,
                ProductId = productId,
                SellerId = product.SellerId,
                State = OrderState.Paid,
            };
            Db.Orders.Add(order);
            Db.SaveChanges();

            var transaction = new Transaction()
            {
                CardId = buyerCard.Id,
                Date = DateTime.Now,
                OrderId = order.Id,
                RequestId = 0,
                TransactionReference = 0,
                Hash = Guid.NewGuid(),
                UsdAmount = product.UsdPrice,
                Type = TransactionType.Charge_Buyer,
                AuthCode = payment.AuthCode,
                PaymentId = payment.Id,
                Approved = approved
            };
            Db.Transactions.Add(transaction);
            Db.SaveChanges();

            return order;
        }
    }

}

