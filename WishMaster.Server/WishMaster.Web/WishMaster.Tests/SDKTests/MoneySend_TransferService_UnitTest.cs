using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterCard.SDK;
using MasterCard.SDK.Services.MoneySend;
using MasterCard.SDK.Services.MoneySend.Domain;
using WishMaster.Service.Tools;

namespace Test.Services
{

    [TestClass]
    public class TransferService_UnitTest
    {
        TransferService service;

        [TestInitialize]
        public void Init()
        {
            service = new TransferService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
        }

        //        [TestMethod]
        //        public void TestTransferRequestCardTest()
        //        {
        //            TransferRequest transferRequestCard = new TransferRequest();
        //            transferRequestCard.LocalDate = "1212";
        //            transferRequestCard.LocalTime = "161222";
        //            transferRequestCard.TransactionReference = 4000000001010102028L;
        //            transferRequestCard.SenderName = "John Doe";
        //            transferRequestCard.SenderAddress.Line1 = "123 Main Street";
        //            transferRequestCard.SenderAddress.Line2 = "#5A";
        //            transferRequestCard.SenderAddress.City = "Arlington";
        //            transferRequestCard.SenderAddress.CountrySubdivision = "VA";
        //            transferRequestCard.SenderAddress.PostalCode = 22207;
        //            transferRequestCard.SenderAddress.Country = "USA";
        //            transferRequestCard.FundingCard.AccountNumber = 5184680430000006L;
        //            transferRequestCard.FundingCard.ExpiryMonth = 11;
        //            transferRequestCard.FundingCard.ExpiryYear = 2014;
        //            transferRequestCard.FundingUCAF = "MjBjaGFyYWN0ZXJqdW5rVUNBRjU=1111";
        //            transferRequestCard.FundingMasterCardAssignedId = 123456;
        //            transferRequestCard.FundingAmount.Value = 15000;
        //            transferRequestCard.FundingAmount.Currency = 840;
        //            transferRequestCard.ReceiverName = "Jose Lopez";
        //            transferRequestCard.ReceiverAddress.Line1 = "Pueblo Street";
        //            transferRequestCard.ReceiverAddress.Line2 = "PO BOX 12";
        //            transferRequestCard.ReceiverAddress.City = "El PASO";
        //            transferRequestCard.ReceiverAddress.CountrySubdivision = "TX";
        //            transferRequestCard.ReceiverAddress.PostalCode = 79906;
        //            transferRequestCard.ReceiverAddress.Country = "USA";
        //            transferRequestCard.ReceiverPhone = 1800639426;
        //            transferRequestCard.ReceivingCard.AccountNumber = 5184680430000006L;
        //            transferRequestCard.ReceivingAmount.Value = 182206;
        //            transferRequestCard.ReceivingAmount.Currency = 484;
        //            transferRequestCard.Channel = "W";
        //            transferRequestCard.UCAFSupport = false;
        //            transferRequestCard.ICA = "009674";
        //            transferRequestCard.ProcessorId = 9000000442L;
        //            transferRequestCard.RoutingAndTransitNumber = 990442082;
        //            transferRequestCard.CardAcceptor.Name = "My Local Bank";
        //            transferRequestCard.CardAcceptor.City = "Saint Louis";
        //            transferRequestCard.CardAcceptor.State = "MO";
        //            transferRequestCard.CardAcceptor.PostalCode = 63101;
        //            transferRequestCard.CardAcceptor.Country = "USA";
        //            transferRequestCard.TransactionDesc = "P2P";
        //            transferRequestCard.MerchantId = 123456;
        //            Transfer transfer = service.GetTransfer(transferRequestCard);
        //            Assert.IsTrue(transfer != null);
        //            Assert.IsTrue(transfer.TransactionReference > 0);
        //            Assert.IsTrue(transfer.TransactionHistory != null);
        //            Assert.IsTrue(transfer.TransactionHistory[0].Response.Code == 00);
        //            Assert.IsTrue(transfer.TransactionHistory[1].Response.Code == 00);
        //        }

        //        [TestMethod]
        //        public void TestTransferRequestMappedTest()
        //        {
        //            TransferRequest transferRequestMapped = new TransferRequest();
        //            transferRequestMapped.LocalDate = "1212";
        //            transferRequestMapped.LocalTime = "161222";
        //            transferRequestMapped.TransactionReference = 4000000003010101016L;
        //            transferRequestMapped.FundingMapped.SubscriberId = "example@email.com";
        //            transferRequestMapped.FundingMapped.SubscriberType = "EMAIL_ADDRESS";
        //            transferRequestMapped.FundingMapped.SubscriberAlias = "My Debit Card";
        //            transferRequestMapped.FundingUCAF = "MjBjaGFyYWN0ZXJqdW5rVUNBRjU=1111";
        //            transferRequestMapped.FundingMasterCardAssignedId = 123456;
        //            transferRequestMapped.FundingAmount.Value = 15000;
        //            transferRequestMapped.FundingAmount.Currency = 840;
        //            transferRequestMapped.ReceiverName = "Jose Lopez";
        //            transferRequestMapped.ReceiverAddress.Line1 = "Pueblo Street";
        //            transferRequestMapped.ReceiverAddress.Line2 = "PO BOX 12";
        //            transferRequestMapped.ReceiverAddress.City = "El PASO";
        //            transferRequestMapped.ReceiverAddress.CountrySubdivision = "TX";
        //            transferRequestMapped.ReceiverAddress.PostalCode = 79906;
        //            transferRequestMapped.ReceiverAddress.Country = "USA";
        //            transferRequestMapped.ReceiverPhone = 1800639426;
        //            transferRequestMapped.ReceivingCard.AccountNumber = 5184680430000014L;
        //            transferRequestMapped.ReceivingAmount.Value = 182206;
        //            transferRequestMapped.ReceivingAmount.Currency = 484;
        //            transferRequestMapped.Channel = "W";
        //            transferRequestMapped.UCAFSupport = false;
        //            transferRequestMapped.ICA = "009674";
        //            transferRequestMapped.ProcessorId = 9000000442L;
        //            transferRequestMapped.RoutingAndTransitNumber = 990442082;
        //            transferRequestMapped.CardAcceptor.Name = "My Local Bank";
        //            transferRequestMapped.CardAcceptor.City = "Saint Louis";
        //            transferRequestMapped.CardAcceptor.State = "MO";
        //            transferRequestMapped.CardAcceptor.PostalCode = 63101;
        //            transferRequestMapped.CardAcceptor.Country = "USA";
        //            transferRequestMapped.TransactionDesc = "P2P";
        //            transferRequestMapped.MerchantId = 123456;
        //            Transfer transfer = service.GetTransfer(transferRequestMapped);
        //            Assert.IsTrue(transfer != null);
        //            Assert.IsTrue(transfer.TransactionReference > 0);
        //            Assert.IsTrue(transfer.TransactionHistory != null);
        //            Assert.IsTrue(transfer.TransactionHistory[0].Response.Code == 00);
        //            Assert.IsTrue(transfer.TransactionHistory[1].Response.Code == 00);
        //        }

        [TestMethod]
        public void TestPaymentRequestCardTest()
        {
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
            Assert.IsTrue(transfer != null);
            Assert.IsTrue(transfer.TransactionReference > 0);
            Assert.IsTrue(transfer.TransactionHistory != null);
            Assert.IsTrue(transfer.TransactionHistory[0].Response.Code == 00);
        }

        //        [TestMethod]
        //        public void TestPaymentRequestMappedTest()
        //        {
        //            PaymentRequest paymentRequestMapped = new PaymentRequest();
        //            paymentRequestMapped.LocalDate = Sandbox.CurrentMonthTwoDigits() + Sandbox.CurrentDayTwoDigits();
        //            paymentRequestMapped.LocalTime = Sandbox.CurrentHourSixDigits();
        //            paymentRequestMapped.TransactionReference = Sandbox.GenerateLongRandomNumeric();
        //            paymentRequestMapped.SenderName = "John Doe";
        //            paymentRequestMapped.SenderAddress.Line1 = "123 Main Street";
        //            paymentRequestMapped.SenderAddress.Line2 = "#5A";
        //            paymentRequestMapped.SenderAddress.City = "Arlington";
        //            paymentRequestMapped.SenderAddress.CountrySubdivision = "VA";
        //            paymentRequestMapped.SenderAddress.PostalCode = 22207;
        //            paymentRequestMapped.SenderAddress.Country = "USA";
        //            paymentRequestMapped.ReceivingMapped.SubscriberId = "exzmpl32@email.com";
        //            paymentRequestMapped.ReceivingMapped.SubscriberType = "EMAIL_ADDRESS";
        //            paymentRequestMapped.ReceivingMapped.SubscriberAlias = "MyzDebit2Card";
        //            paymentRequestMapped.ReceivingAmount.Value = 10000;
        //            paymentRequestMapped.ReceivingAmount.Currency = 840;
        //            paymentRequestMapped.ICA = "009674";
        //            paymentRequestMapped.ProcessorId = 9000000442L;
        //            paymentRequestMapped.RoutingAndTransitNumber = 990442082;
        //            paymentRequestMapped.CardAcceptor.Name = "My Local Bank";
        //            paymentRequestMapped.CardAcceptor.City = "Saint Louis";
        //            paymentRequestMapped.CardAcceptor.State = "MO";
        //            paymentRequestMapped.CardAcceptor.PostalCode = 63101;
        //            paymentRequestMapped.CardAcceptor.Country = "USA";
        //            paymentRequestMapped.TransactionDesc = "P2P";
        //            paymentRequestMapped.MerchantId = 123456;
        //            Transfer transfer = service.GetTransfer(paymentRequestMapped);
        //            Assert.IsTrue(transfer != null);
        //            Assert.IsTrue(transfer.TransactionReference > 0);
        //            Assert.IsTrue(transfer.TransactionHistory != null);
        //            Assert.IsTrue(transfer.TransactionHistory[0].Response.Code == 00);
        //        }
    }
}
