using MasterCard.SDK;
using MasterCard.SDK.Services.LostStolen;
using MasterCard.SDK.Services.LostStolen.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WishMaster.Service.Tools;

namespace Test.Services
{
    [TestClass]
    public class LostStolen_UnitTest
    {
        private LostStolenService service;

        [TestInitialize]
        public void Init()
        {
            service = new LostStolenService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
        }

        [TestMethod]
        public void TestLostStolenService_Stolen()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 5343434343434343;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("S"));
        }

        [TestMethod]
        public void TestLostStolenService_Fraud()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 5105105105105100;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("F"));
        }

        [TestMethod]
        public void TestLostStolenService_Lost()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 5222222222222200;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("L"));
        }

        [TestMethod]
        public void TestLostStolenService_CaptureCard()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 5305305305305300;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("P"));
        }

        [TestMethod]
        public void TestLostStolenService_UnauthorizedUse()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 6011111111111117;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("U"));
        }

        [TestMethod]
        public void TestLostStolenService_Counterfeit()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 4444333322221111;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals("X"));
        }

        [TestMethod]
        public void TestLostStolenService_NotListed()
        {
            AccountInquiry accountInquiry = new AccountInquiry();
            accountInquiry.AccountNumber = 343434343434343;
            Account account = service.GetLostStolen(accountInquiry);
            Assert.AreEqual(true, account.ReasonCode.Equals(""));
        }
    }
}
