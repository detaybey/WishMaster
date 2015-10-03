// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.37595
//    <NameSpace>Location</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace MasterCard.SDK.Services.Location.Domain
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Atms
    {

        private string pageOffsetField;

        private string totalCountField;

        private List<AtmsAtm> atmField;

        public Atms()
        {
            this.atmField = new List<AtmsAtm>();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PageOffset
        {
            get
            {
                return this.pageOffsetField;
            }
            set
            {
                if (value == null)
                {
                    this.pageOffsetField = "";
                    return;
                }
                this.pageOffsetField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TotalCount
        {
            get
            {
                return this.totalCountField;
            }
            set
            {
                if (value == null)
                {
                    this.totalCountField = "";
                    return;
                }
                this.totalCountField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Atm", Order = 2)]
        public List<AtmsAtm> Atm
        {
            get
            {
                return this.atmField;
            }
            set
            {
                this.atmField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtm
    {

        private AtmsAtmLocation locationField;

        private string handicapAccessibleField;

        private string cameraField;

        private string availabilityField;

        private string accessFeesField;

        private string ownerField;

        private string sharedDepositField;

        private string surchargeFreeAllianceField;

        private string surchargeFreeAllianceNetworkField;

        private string sponsorField;

        private string supportEMVField;

        public AtmsAtm()
        {
            this.locationField = new AtmsAtmLocation();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public AtmsAtmLocation Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string HandicapAccessible
        {
            get
            {
                return this.handicapAccessibleField;
            }
            set
            {
                this.handicapAccessibleField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Camera
        {
            get
            {
                return this.cameraField;
            }
            set
            {
                this.cameraField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string Availability
        {
            get
            {
                return this.availabilityField;
            }
            set
            {
                this.availabilityField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AccessFees
        {
            get
            {
                return this.accessFeesField;
            }
            set
            {
                this.accessFeesField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string Owner
        {
            get
            {
                return this.ownerField;
            }
            set
            {
                this.ownerField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SharedDeposit
        {
            get
            {
                return this.sharedDepositField;
            }
            set
            {
                this.sharedDepositField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SurchargeFreeAlliance
        {
            get
            {
                return this.surchargeFreeAllianceField;
            }
            set
            {
                this.surchargeFreeAllianceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string SurchargeFreeAllianceNetwork
        {
            get
            {
                return this.surchargeFreeAllianceNetworkField;
            }
            set
            {
                this.surchargeFreeAllianceNetworkField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string Sponsor
        {
            get
            {
                return this.sponsorField;
            }
            set
            {
                this.sponsorField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string SupportEMV
        {
            get
            {
                return this.supportEMVField;
            }
            set
            {
                if (value == null)
                {
                    this.supportEMVField = "";
                    return;
                }
                this.supportEMVField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocation
    {

        private string nameField;

        private float distanceField;

        private string distanceUnitField;

        private AtmsAtmLocationAddress addressField;

        private AtmsAtmLocationPoint pointField;

        private AtmsAtmLocationLocationType locationTypeField;

        public AtmsAtmLocation()
        {
            this.locationTypeField = new AtmsAtmLocationLocationType();
            this.pointField = new AtmsAtmLocationPoint();
            this.addressField = new AtmsAtmLocationAddress();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public float Distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string DistanceUnit
        {
            get
            {
                return this.distanceUnitField;
            }
            set
            {
                this.distanceUnitField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public AtmsAtmLocationAddress Address
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

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public AtmsAtmLocationPoint Point
        {
            get
            {
                return this.pointField;
            }
            set
            {
                this.pointField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public AtmsAtmLocationLocationType LocationType
        {
            get
            {
                return this.locationTypeField;
            }
            set
            {
                this.locationTypeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocationAddress
    {

        private string line1Field;

        private string line2Field;

        private string cityField;

        private string postalCodeField;

        private AtmsAtmLocationAddressCountrySubdivision countrySubdivisionField;

        private AtmsAtmLocationAddressCountry countryField;

        public AtmsAtmLocationAddress()
        {
            this.countryField = new AtmsAtmLocationAddressCountry();
            this.countrySubdivisionField = new AtmsAtmLocationAddressCountrySubdivision();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Line1
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

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Line2
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

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string City
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

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                if (value == null)
                {
                    this.postalCodeField = "";
                    return;
                }
                this.postalCodeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public AtmsAtmLocationAddressCountrySubdivision CountrySubdivision
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

        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public AtmsAtmLocationAddressCountry Country
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

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocationAddressCountrySubdivision
    {

        private string nameField;

        private string codeField;

        //[System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        //[System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocationAddressCountry
    {

        private string nameField;

        private string codeField;

        //[System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        //[System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocationPoint
    {

        private string latitudeField;

        private string longitudeField;

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                if (value == null)
                {
                    this.latitudeField = "";
                    return;
                }
                this.latitudeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                if (value == null)
                {
                    this.longitudeField = "";
                    return;
                }
                this.longitudeField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AtmsAtmLocationLocationType
    {

        private string typeField;

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
}
