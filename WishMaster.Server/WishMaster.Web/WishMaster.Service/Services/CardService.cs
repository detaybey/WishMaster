using MasterCard.SDK;
using MasterCard.SDK.Services.MoneySend;
using MasterCard.SDK.Services.MoneySend.Domain;
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

        public void FundUser()
        {
            var service = new TransferService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
            PaymentRequest paymentRequestCard = new PaymentRequest();

            paymentRequestCard.ICA = "009674";
            paymentRequestCard.ProcessorId = 9000000442L;
            paymentRequestCard.RoutingAndTransitNumber = 990442082;
            paymentRequestCard.MerchantId = 123456;
            paymentRequestCard.TransactionDesc = "P2P";

            paymentRequestCard.LocalDate = Sandbox.CurrentMonthTwoDigits() + Sandbox.CurrentDayTwoDigits();
            paymentRequestCard.LocalTime = Sandbox.CurrentHourSixDigits();

            paymentRequestCard.TransactionReference = Sandbox.GenerateLongRandomNumeric();

            paymentRequestCard.SenderName = "John Doe";
            paymentRequestCard.SenderAddress.Line1 = "123 Main Street";
            paymentRequestCard.SenderAddress.Line2 = "#5A";
            paymentRequestCard.SenderAddress.City = "Arlington";
            paymentRequestCard.SenderAddress.CountrySubdivision = "VA";
            paymentRequestCard.SenderAddress.PostalCode = 22207;
            paymentRequestCard.SenderAddress.Country = "USA";

            paymentRequestCard.ReceivingCard.AccountNumber = "5184680430000014";
            paymentRequestCard.ReceivingAmount.Value = 11;
            paymentRequestCard.ReceivingAmount.Currency = 484;

            paymentRequestCard.CardAcceptor.Name = "My Local Bank";
            paymentRequestCard.CardAcceptor.City = "Saint Louis";
            paymentRequestCard.CardAcceptor.State = "MO";
            paymentRequestCard.CardAcceptor.PostalCode = 63101;
            paymentRequestCard.CardAcceptor.Country = "USA";

            Transfer transfer = service.GetTransfer(paymentRequestCard);
            

        }

    }
}
