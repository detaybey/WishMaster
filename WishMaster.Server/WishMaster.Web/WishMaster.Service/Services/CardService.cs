using MasterCard.SDK;
using MasterCard.SDK.Services.LostStolen;
using MasterCard.SDK.Services.LostStolen.Domain;
using MasterCard.SDK.Services.MoneySend;
using MasterCard.SDK.Services.MoneySend.Domain;
using SimplifyCommerce.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishMaster.Service.Entities;
using WishMaster.Service.Tools;

namespace WishMaster.Service.Services
{
    public class CardService : BaseService
    {
        public UserService UserService { get; set; }

        public CardService(WishMasterDataContext db, UserService userService)
            : base(db)
        {
            UserService = userService;
        }

        /// <summary>
        /// Adds a new credit card information
        /// </summary>
        /// <param name="userid">userid of the owner</param>
        /// <param name="number">number of cc</param>
        /// <param name="month">month of expiry date</param>
        /// <param name="year">year of expiry date</param>
        /// <param name="cvv">cvv of card</param>
        /// <returns>Card object</returns>
        public Entities.Card AddCard(long userid, string number, int month, int year, int cvv)
        {
            var user = UserService.GetUserById(userid);
            var card = new Entities.Card()
            {
                CCV = cvv.ToString(),
                ExpMonth = month.ToString("d2"),
                ExpYear = year.ToString(),
                OwnerId = userid,
                Number = number,
                // we are using a default value for the card acceptor for sandbox usage
                AcceptorName = "Great Bank",
                AcceptorCity = "Saint Louis",
                AcceptorPostalCode = "63101",
                AcceptorState = "MO",
                AcceptorCountry = "USA"
            };
            user.Cards.Add(card);
            Db.SaveChanges();
            return card;
        }

        public void CheckLostStolen()
        {
            var service = new LostStolenService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
            var accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 5343434343434343;
            Account account = service.GetLostStolen(accountInquiry);
        }

        /// <summary>
        /// Fund the seller of an order
        /// </summary>
        /// <param name="usdAmount"></param>
        /// <param name="receiver"></param>
        /// <param name="order"></param>
        public void FundSeller(decimal usdAmount, Order order)
        {
            var service = new TransferService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);

            TransferRequest transferRequestCard = new TransferRequest();
            transferRequestCard.LocalDate = Sandbox.CurrentMonthTwoDigits() + Sandbox.CurrentDayTwoDigits();
            transferRequestCard.LocalTime = Sandbox.CurrentHourSixDigits();
            transferRequestCard.TransactionReference = Sandbox.GenerateLongRandomNumeric();
            transferRequestCard.Channel = "W";
            transferRequestCard.UCAFSupport = false;
            transferRequestCard.ICA = "009674";
            transferRequestCard.ProcessorId = 9000000442L;
            transferRequestCard.RoutingAndTransitNumber = 990442082;
            transferRequestCard.TransactionDesc = "P2P";
            transferRequestCard.MerchantId = 123456;
            transferRequestCard.FundingUCAF = "MjBjaGFyYWN0ZXJqdW5rVUNBRjU=1111";
            transferRequestCard.FundingMasterCardAssignedId = 123456;

            var systemUser = UserService.GetUserByNick("system");

            transferRequestCard.SenderName = systemUser.FullName;
            transferRequestCard.SenderAddress.Line1 = systemUser.AddressLine1;
            transferRequestCard.SenderAddress.Line2 = systemUser.AddressLine2;
            transferRequestCard.SenderAddress.City = systemUser.AddressCity;
            transferRequestCard.SenderAddress.CountrySubdivision = systemUser.AddressState;
            transferRequestCard.SenderAddress.PostalCode = systemUser.AddressZip;
            transferRequestCard.SenderAddress.Country = systemUser.AddressCountry;

            var systemCard = systemUser.Cards.First();

            transferRequestCard.FundingCard.AccountNumber = systemCard.Number;
            transferRequestCard.FundingCard.ExpiryMonth = systemCard.ExpMonth;
            transferRequestCard.FundingCard.ExpiryYear = systemCard.ExpYear;
            transferRequestCard.FundingAmount.Value = usdAmount;
            transferRequestCard.FundingAmount.Currency = 840;

            var userCard = order.Seller.Cards.First();

            transferRequestCard.ReceiverName = order.Seller.FullName;
            transferRequestCard.ReceiverAddress.Line1 = order.Seller.AddressLine1;
            transferRequestCard.ReceiverAddress.Line2 = order.Seller.AddressLine2;
            transferRequestCard.ReceiverAddress.City = order.Seller.AddressCity;
            transferRequestCard.ReceiverAddress.CountrySubdivision = order.Seller.AddressState;
            transferRequestCard.ReceiverAddress.PostalCode = order.Seller.AddressZip;
            transferRequestCard.ReceiverAddress.Country = order.Seller.AddressCountry;
            transferRequestCard.ReceiverPhone = order.Seller.Phone;

            transferRequestCard.ReceivingCard.AccountNumber = userCard.Number;
            transferRequestCard.ReceivingAmount.Value = usdAmount;
            transferRequestCard.ReceivingAmount.Currency = 840;

            transferRequestCard.CardAcceptor.Name = userCard.AcceptorName;
            transferRequestCard.CardAcceptor.City = userCard.AcceptorCity;
            transferRequestCard.CardAcceptor.State = userCard.AcceptorState;
            transferRequestCard.CardAcceptor.PostalCode = userCard.AcceptorPostalCode;
            transferRequestCard.CardAcceptor.Country = userCard.AcceptorCountry;

            Transfer transfer = service.GetTransfer(transferRequestCard);

            var transaction = new Transaction()
            {
                CardId = userCard.Id,
                Date = DateTime.Now,
                OrderId = order.Id,
                RequestId = transfer.RequestId,
                TransactionReference = transfer.TransactionReference,
                Hash = Guid.NewGuid(),
                UsdAmount = usdAmount,
                Type = TransactionType.Fund_Seller,
                PaymentId = "",
                AuthCode = "",
                Approved = transfer.RequestId > 0
            };
            Db.Transactions.Add(transaction);
            Db.SaveChanges();
        }


        /// <summary>
        /// Charge the buyer of an order
        /// </summary>
        /// <param name="usdAmout"></param>
        /// <param name="order"></param>
        public void ChargeBuyer(long usdAmount, Order order)
        {
            var buyer = order.Customer;
            var buyerCard = buyer.Cards.First();

            PaymentsApi.PublicApiKey = Security.GetSCPublicKey();
            PaymentsApi.PrivateApiKey = Security.GetSCPrivateKey();
            PaymentsApi api = new PaymentsApi();
            Payment payment = new Payment();
            payment.Amount = usdAmount;

            var card = new SimplifyCommerce.Payments.Card();
            card.Cvc = buyerCard.CCV;
            card.ExpMonth = Convert.ToInt16(buyerCard.ExpMonth);
            card.ExpYear = Convert.ToInt16(buyerCard.ExpYear.Substring(2, 2));
            card.Number = buyerCard.Number;

            payment.Card = card;
            payment.Currency = "USD";
            payment.Description = "PD:" + order.Product.Title;
            payment = (Payment)api.Create(payment);

            var transaction = new Transaction()
            {
                CardId = buyerCard.Id,
                Date = DateTime.Now,
                OrderId = order.Id,
                RequestId = 0,
                TransactionReference = 0,
                Hash = Guid.NewGuid(),
                UsdAmount = usdAmount,
                Type = TransactionType.Charge_Buyer,
                AuthCode = payment.AuthCode,
                PaymentId = payment.Id,
                Approved = payment.PaymentStatus == "APPROVED"
            };
            Db.Transactions.Add(transaction);
            Db.SaveChanges();

        }
    }
}
