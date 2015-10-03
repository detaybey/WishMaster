// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.37595
//    <NameSpace>moneysend</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace MasterCard.SDK.Services.MoneySend.Domain
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    public partial class CreateMappingRequest
    {

        private String subscriberIdField;

        private String subscriberTypeField;

        private String accountUsageField;

        private String defaultIndicatorField;

        private String aliasField;

        private String iCAField;

        private String accountNumberField;

        private int? expiryDateField;

        private CreateMappingRequestCardholderFullName cardholderFullNameField;

        private CreateMappingRequestAddress addressField;

        private int? dateOfBirthField;

        public CreateMappingRequest()
        {
            this.addressField = new CreateMappingRequestAddress();
            this.cardholderFullNameField = new CreateMappingRequestCardholderFullName();
        }

        public String SubscriberId
        {
            get
            {
                return this.subscriberIdField;
            }
            set
            {
                this.subscriberIdField = value;
            }
        }

        public String SubscriberType
        {
            get
            {
                return this.subscriberTypeField;
            }
            set
            {
                this.subscriberTypeField = value;
            }
        }

        public String AccountUsage
        {
            get
            {
                return this.accountUsageField;
            }
            set
            {
                this.accountUsageField = value;
            }
        }

        public String DefaultIndicator
        {
            get
            {
                return this.defaultIndicatorField;
            }
            set
            {
                this.defaultIndicatorField = value;
            }
        }

        public String Alias
        {
            get
            {
                return this.aliasField;
            }
            set
            {
                this.aliasField = value;
            }
        }

        public String ICA
        {
            get
            {
                return this.iCAField;
            }
            set
            {
                this.iCAField = value;
            }
        }

        public String AccountNumber
        {
            get
            {
                return this.accountNumberField;
            }
            set
            {
                this.accountNumberField = value;
            }
        }

        public int? ExpiryDate
        {
            get
            {
                return this.expiryDateField;
            }
            set
            {
                this.expiryDateField = value;
            }
        }

        public CreateMappingRequestCardholderFullName CardholderFullName
        {
            get
            {
                return this.cardholderFullNameField;
            }
            set
            {
                this.cardholderFullNameField = value;
            }
        }

        public CreateMappingRequestAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        public int? DateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }
    }

    public partial class CreateMappingRequestCardholderFullName
    {

        private String cardholderFirstNameField;

        private String cardholderMiddleNameField;

        private String cardholderLastNameField;

        public String CardholderFirstName
        {
            get
            {
                return this.cardholderFirstNameField;
            }
            set
            {
                this.cardholderFirstNameField = value;
            }
        }

        public String CardholderMiddleName
        {
            get
            {
                return this.cardholderMiddleNameField;
            }
            set
            {
                this.cardholderMiddleNameField = value;
            }
        }

        public String CardholderLastName
        {
            get
            {
                return this.cardholderLastNameField;
            }
            set
            {
                this.cardholderLastNameField = value;
            }
        }
    }

    public partial class CreateMappingRequestAddress
    {

        private String line1Field;

        private String line2Field;

        private String cityField;

        private String countrySubdivisionField;

        private int? postalCodeField;

        private String countryField;

        public String Line1
        {
            get
            {
                return this.line1Field;
            }
            set
            {
                this.line1Field = value;
            }
        }

        public String Line2
        {
            get
            {
                return this.line2Field;
            }
            set
            {
                this.line2Field = value;
            }
        }

        public String City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        public String CountrySubdivision
        {
            get
            {
                return this.countrySubdivisionField;
            }
            set
            {
                this.countrySubdivisionField = value;
            }
        }

        public int? PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        public String Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }
}
