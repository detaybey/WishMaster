using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyCommerce.Payments;
using System.Diagnostics;
using WishMaster.Service.Tools;

namespace WishMaster.Tests.SDKTests
{
    [TestClass]
    public class Simplify_TESTS
    {

        [TestMethod]
        public void TestChargePayment()
        {
            PaymentsApi.PublicApiKey = Security.GetSCPublicKey();
            PaymentsApi.PrivateApiKey = Security.GetSCPrivateKey();
            PaymentsApi api = new PaymentsApi();
            Payment payment = new Payment();
            payment.Amount = 123123;
            Card card = new Card();
            card.Cvc = "123";
            card.ExpMonth = 11;
            card.ExpYear = 23;
            card.Number = "5555555555554444";
            payment.Card = card;
            payment.Currency = "USD";
            payment.Description = "payment description";
            payment = (Payment)api.Create(payment);
            Assert.AreEqual(payment.PaymentStatus, "APPROVED");
        }

        [TestMethod]
        public void TestChargeAndRefundPayment()
        {
            PaymentsApi.PublicApiKey = Security.GetSCPublicKey();
            PaymentsApi.PrivateApiKey = Security.GetSCPrivateKey();
            PaymentsApi api = new PaymentsApi();
            Payment payment = new Payment();
            payment.Amount = 123123;
            Card card = new Card();
            card.Cvc = "123";
            card.ExpMonth = 11;
            card.ExpYear = 23;
            card.Number = "5555555555554444";
            payment.Card = card;
            payment.Currency = "USD";
            payment.Description = "payment description";
            payment.Reference = "76398734634";
            payment = (Payment)api.Create(payment);
            Assert.AreEqual(payment.PaymentStatus, "APPROVED");


            Refund refund = new Refund();
            refund.Amount = 123123;
            refund.Payment = payment;
            refund.Reason = "Refund Description";
            refund.Reference = "76398734634";
            refund = (Refund)api.Create(refund);
            Assert.AreEqual(refund.PaymentStatus, "APPROVED");

        }
    }
}