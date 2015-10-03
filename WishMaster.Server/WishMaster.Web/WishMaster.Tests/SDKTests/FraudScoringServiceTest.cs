using MasterCard.SDK.Services.FraudScoring.Domain;
using MasterCard.SDK.Services.FraudScoring;
using MasterCard.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WishMaster.Service.Tools;

namespace Test.Services
{
    public enum MatchIndicatorStatus
    {
        SINGLE_TRANSACTION_MATCH = 1,
        MULTIPLE_TRANS_IDENTICAL_CARD_MATCH = 2,
        MULTIPLE_TRANS_DIFFERING_CARDS_MATCH = 3,
        NO_MATCH_FOUND = 4
    }
   
    [TestClass]
    public class FraudScoringServiceTest
    {
        private FraudScoringService service;
        private ScoreLookupRequest request;
       
        [TestInitialize]
        public void TestInitialize()
        {
            service = new FraudScoringService(Environments.Environment.SANDBOX, Security.GetConsumerKey(), Security.GetPrivateKey());
            request = new ScoreLookupRequest();

            request.TransactionDetail.CustomerIdentifier = 1996;
            request.TransactionDetail.MerchantIdentifier = 123;
            request.TransactionDetail.AccountNumber = 5555555555555555555;
            request.TransactionDetail.AccountPrefix = 555555;
            request.TransactionDetail.AccountSuffix = 5555;
            request.TransactionDetail.TransactionDate = 1231;
            request.TransactionDetail.TransactionTime = "035959";
            request.TransactionDetail.BankNetReferenceNumber = "abcABC123";
            request.TransactionDetail.Stan = 123456;
        }

        [TestMethod]
        public void LowFraudScoringSingleTransactionMatch_Test()
        {
            request.TransactionDetail.TransactionAmount = 62500;
            ScoreLookup scoreLookup = service.getScoreLookup(request);
            Assert.IsTrue(scoreLookup.ScoreResponse.MatchIndicator == (short)MatchIndicatorStatus.SINGLE_TRANSACTION_MATCH); 
        }

        [TestMethod]
        public void MidFraudScoreSingleTransactionMatch_Test()
        {
            request.TransactionDetail.TransactionAmount = 10001;
            ScoreLookup scoreLookup = service.getScoreLookup(request);
            Assert.IsTrue(scoreLookup.ScoreResponse.MatchIndicator == (short)MatchIndicatorStatus.MULTIPLE_TRANS_IDENTICAL_CARD_MATCH);
        }

        [TestMethod]
        public void HighFradScoreSingleTransactionMatch_Test()
        {
            request.TransactionDetail.TransactionAmount = 20001;
            ScoreLookup scoreLookup = service.getScoreLookup(request);
            Assert.IsTrue(scoreLookup.ScoreResponse.MatchIndicator == (short)MatchIndicatorStatus.MULTIPLE_TRANS_DIFFERING_CARDS_MATCH);
        }

        [TestMethod]
        public void NoMatchFound_Test()
        {
            request.TransactionDetail.TransactionAmount = 30001;
            ScoreLookup scoreLookup = service.getScoreLookup(request);
            Assert.IsTrue(scoreLookup.ScoreResponse.MatchIndicator == (short)MatchIndicatorStatus.NO_MATCH_FOUND);
        }

        [TestMethod]
        [ExpectedException(typeof(MCApiRuntimeException))]
        public void SystemError_Test()
        {
            request.TransactionDetail.TransactionAmount = 50001;
            service.getScoreLookup(request);
            Assert.Fail("A MCApiRuntimeException should have been thrown");
        }
    }
}
