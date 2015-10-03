using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterCard.SDK.Services.MoneySend;
using MasterCard.SDK;
using MasterCard.SDK.Services.MoneySend.Domain;
using WishMaster.Service.Tools;

namespace Test.Services
{
    [TestClass]
    public class PanEligibilityService_UnitTest
    {
        PanEligibilityService service;

        [TestInitialize]
        public void Init()
        {
            service = new PanEligibilityService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
        }

        [TestMethod]
        public void TestPanEligibilityService_NotEligible()
        {
            PanEligibilityRequest panEligibilityRequest = new PanEligibilityRequest();
            panEligibilityRequest.SendingAccountNumber = 5184680990000024L;
            panEligibilityRequest.ReceivingAccountNumber = 5184680060000201L;
            PanEligibility panEligibility = service.GetPanEligibility(panEligibilityRequest);
            Assert.IsTrue(panEligibility != null);
            Assert.IsTrue(panEligibility.RequestId != null && panEligibility.RequestId > 0);
            Assert.IsTrue(panEligibility.SendingEligibility.AccountNumber > 0);
            Assert.IsTrue(panEligibility.ReceivingEligibility.AccountNumber > 0);
            Assert.IsTrue(panEligibility.SendingEligibility.Eligible == false);
            Assert.IsTrue(panEligibility.SendingEligibility.AccountNumber > 0);
            Assert.IsTrue(panEligibility.RequestId > 0);
            Assert.IsTrue(panEligibility.ReceivingEligibility.Eligible == false);
            Assert.IsTrue(panEligibility.ReceivingEligibility.AccountNumber > 0);
        }

        [TestMethod]
        public void TestPanEligibilityServiceSending_Eligible()
        {
            PanEligibilityRequest panEligibilityRequest = new PanEligibilityRequest();
            panEligibilityRequest.SendingAccountNumber = 5184680430000006L;
            PanEligibility panEligibility = service.GetPanEligibility(panEligibilityRequest);
            Assert.IsTrue(panEligibility != null);
            Assert.IsTrue(panEligibility.RequestId != null && panEligibility.RequestId > 0);
            Assert.IsTrue(panEligibility.SendingEligibility.AccountNumber > 0);
        }

        [TestMethod]
        public void TestPanEligibilityServiceReceiving_Eligible()
        {
            PanEligibilityRequest panEligibilityRequest = new PanEligibilityRequest();
            panEligibilityRequest.ReceivingAccountNumber = 5184680430000006L;
            PanEligibility panEligibility = service.GetPanEligibility(panEligibilityRequest);
            Assert.IsTrue(panEligibility != null);
            Assert.IsTrue(panEligibility.RequestId != null && panEligibility.RequestId > 0);
            Assert.IsTrue(panEligibility.ReceivingEligibility.AccountNumber > 0);
        }
    }
}
