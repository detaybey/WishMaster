//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MasterCard.SDK.Services.MoneySend;
//using MasterCard.SDK;
//using MasterCard.SDK.Services.MoneySend.Domain;
//using WishMaster.Service.Tools;

//namespace Test.Services
//{
//    [TestClass]
//    public class DeleteSubscriberIdService_UnitTest
//    {
//        private DeleteSubscriberIdService service;

//        [TestInitialize]
//        public void Init()
//        {
//            service = new DeleteSubscriberIdService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
//        }

//        [TestMethod]
//        public void TestDeleteSubscriberIdRequest()
//        {
//            DeleteSubscriberIdRequest deleteSubscriberIdRequest = new DeleteSubscriberIdRequest();
//            deleteSubscriberIdRequest.SubscriberId = "example@email.com";
//            deleteSubscriberIdRequest.SubscriberType = "PHONE_NUMBER";
//            DeleteSubscriberId deleteSubscriberId = service.GetDeleteSubscriberId(deleteSubscriberIdRequest);
//            Assert.IsTrue(deleteSubscriberId != null);
//        }

//    }
//}
