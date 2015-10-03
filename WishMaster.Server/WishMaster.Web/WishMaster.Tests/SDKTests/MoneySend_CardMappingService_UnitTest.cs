//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MasterCard.SDK.Services.MoneySend;
//using MasterCard.SDK;
//using MasterCard.SDK.Services.MoneySend.Domain.Options;
//using MasterCard.SDK.Services.MoneySend.Domain;
//using WishMaster.Service.Tools;

//namespace Test.Services
//{
//    [TestClass]
//    public class CardMappingService_UnitTest
//    {
//        private CardMappingService service;
//        InquireMapping inquireMapping;
//        private UpdateMappingRequestOptions updateOptions = new UpdateMappingRequestOptions();
//        private DeleteMappingRequestOptions deleteOptions = new DeleteMappingRequestOptions();

//        [TestInitialize]
//        public void Init()
//        {
//            service = new CardMappingService(Security.GetConsumerKey(), Security.GetPrivateKey(), Environments.Environment.SANDBOX);
//        }

//        [TestMethod]
//        public void TestCreateMappingRequestSuccess()
//        {
//            CreateMappingRequest createRequest = new CreateMappingRequest();
//            createRequest.ICA = "009674";
//            createRequest.SubscriberId = "5321112991";
//            createRequest.SubscriberType = "PHONE_NUMBER";
//            createRequest.AccountUsage = "RECEIVING";
//            createRequest.AccountNumber = "5184680430000006";
//            createRequest.DefaultIndicator = "T";
//            createRequest.ExpiryDate = 201701;
//            createRequest.Alias = "MyYYY Debit Card";
//            createRequest.Address.Line1 = "123 Main Street";
//            createRequest.Address.City = "OFallon";
//            createRequest.Address.PostalCode = 63368;
//            createRequest.Address.CountrySubdivision = "MO";
//            createRequest.Address.Country = "USA";
//            createRequest.CardholderFullName.CardholderFirstName = "John";
//            createRequest.CardholderFullName.CardholderMiddleName = "Q";
//            createRequest.CardholderFullName.CardholderLastName = "Public";
//            createRequest.DateOfBirth = 19460102;
//            CreateMapping createMapping = service.GetCreateMapping(createRequest);
//            Assert.IsTrue(createMapping != null);
//            Assert.IsTrue(createMapping.RequestId != null && createMapping.RequestId > 0);
//            Assert.IsTrue(createMapping.Mapping.MappingId != null && createMapping.Mapping.MappingId > 0);
//        }

//        [TestMethod]
//        public void TestInquireMappingRequestSuccess()
//        {
//            //InquireMappingRequest inquireRequest0 = new InquireMappingRequest();
//            //inquireRequest0.SubscriberId = "13147449999";
//            //inquireRequest0.SubscriberType = "PHONE_NUMBER";
//            //inquireRequest0.AccountUsage = "RECEIVING";
//            //inquireRequest0.Alias = "My Debit Card";
//            //inquireRequest0.DataResponseFlag = 0;
//            //inquireMapping = service.GetInquireMapping(inquireRequest0);
//            //InquireMappingRequest inquireRequest1 = new InquireMappingRequest();
//            //inquireRequest1.SubscriberId = "13147449999";
//            //inquireRequest1.SubscriberType = "PHONE_NUMBER";
//            //inquireRequest1.AccountUsage = "RECEIVING";
//            //inquireRequest1.Alias = "My Debit Card";
//            //inquireRequest1.DataResponseFlag = 1;
//            //inquireMapping = service.GetInquireMapping(inquireRequest1);
//            //InquireMappingRequest inquireRequest2 = new InquireMappingRequest();
//            //inquireRequest2.SubscriberId = "13147449999";
//            //inquireRequest2.SubscriberType = "PHONE_NUMBER";
//            //inquireRequest2.AccountUsage = "RECEIVING";
//            //inquireRequest2.Alias = "My Debit Card";
//            //inquireRequest2.DataResponseFlag = 2;
//            //inquireMapping = service.GetInquireMapping(inquireRequest2);
//            InquireMappingRequest inquireRequest3 = new InquireMappingRequest();
//            inquireRequest3.SubscriberId = "example2@email.com";
//            inquireRequest3.SubscriberType = "EMAIL_ADDRESS";
//            inquireRequest3.AccountUsage = "RECEIVING";
//            inquireRequest3.Alias = "My Debit Card";
//            inquireRequest3.DataResponseFlag = 3;
//            inquireMapping = service.GetInquireMapping(inquireRequest3);
//            Assert.IsTrue(inquireMapping != null);
//            Assert.IsTrue(inquireMapping.RequestId != null && inquireMapping.RequestId > 0);
//            Assert.IsTrue(inquireMapping.Mappings[0].MappingId != null && inquireMapping.Mappings[0].MappingId > 0);
//            Assert.IsTrue(inquireMapping.Mappings[0].Address != null);
//            Assert.IsTrue(inquireMapping.Mappings[0].ReceivingEligibility != null);
//        }

//        [TestMethod]
//        public void TestUpdateMappingRequestSuccess()
//        {
//            UpdateMappingRequest updateRequest = new UpdateMappingRequest();
//            //Obtain Mapping ID from Inquire Mapping test results.
//            updateOptions.MappingId = inquireMapping.Mappings[0].MappingId;
//            updateRequest.AccountUsage = "SENDING";
//            updateRequest.AccountNumber = 5184680430000006;
//            updateRequest.DefaultIndicator = "T";
//            updateRequest.ExpiryDate = 201407;
//            updateRequest.Alias = "The Debit Card";
//            updateRequest.Address.Line1 = "123 Main Street";
//            updateRequest.Address.City = "OFallon";
//            updateRequest.Address.CountrySubdivision = "MO";
//            updateRequest.Address.Country = "USA";
//            updateRequest.Address.PostalCode = 63368;
//            updateRequest.CardholderFullName.CardholderFirstName = "John";
//            updateRequest.CardholderFullName.CardholderMiddleName = "X";
//            updateRequest.CardholderFullName.CardholderLastName = "Public";
//            updateRequest.DateOfBirth = 19460102;
//            UpdateMapping updateMapping = service.GetUpdateMapping(updateRequest, updateOptions);
//            Assert.IsTrue(updateMapping != null);
//            Assert.IsTrue(updateMapping.RequestId != null && updateMapping.RequestId > 0);
//            Assert.IsTrue(updateMapping.Mapping.MappingId != null && updateMapping.Mapping.MappingId > 0);
//        }

//        [TestMethod]
//        public void TestDeleteMappingRequestSuccess()
//        {
//            //Obtain Mapping ID from Inquire Mapping test results.
//            deleteOptions.MappingId = inquireMapping.Mappings[0].MappingId;
//            DeleteMapping deleteMapping = service.GetDeleteMapping(deleteOptions);
//            Assert.IsTrue(deleteMapping != null);
//            Assert.IsTrue(deleteMapping.RequestId != null && deleteMapping.RequestId > 0);
//            Assert.IsTrue(deleteMapping.Mapping.MappingId != null && deleteMapping.Mapping.MappingId > 0);
//        }
//    }
//}
