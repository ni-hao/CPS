using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace CPS.Abstract.BridgePay
{
        public interface IBridgePayWS
        {

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetInvoicesList",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string GetInvoicesList(string key, int accountId);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetReceiptsList",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string GetReceiptsList(string key, int accountId, System.DateTime fromDateUTC, System.DateTime toDateUTC);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetInvoicesPrintableFile",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            [return: XmlElement(DataType = "base64Binary")]
            byte[] GetInvoicesPrintableFile(string key, int accountId, int invoiceId);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetReceiptsPrintableFile",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            [return: XmlElement(DataType = "base64Binary")]
            byte[] GetReceiptsPrintableFile(string key, int accountId, int receiptId);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetAccountPackage",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string GetAccountPackage(string key, int accountId);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CheckPromotionCode",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CheckPromotionCode(string key, int accountId, string promotionCodeValue, int newAccountTypeId);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CalcNewPackage",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CalcNewPackage(string key, int accountId, string requestXml);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/GetAvailableAddOns",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string GetAvailableAddOns(string key, int accountId, int newTypeId);



            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/ListIndustries",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            System.Data.DataTable ListIndustries();


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/ListCountries",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            System.Data.DataTable ListCountries();


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSValidateSession",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            void CPSValidateSession(string key, string sessionKey);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSValidateAccountPassword",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSValidateAccountPassword(string key, string AccountName, string UserName, string Password);



            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSGetAccountPackages",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            System.Data.DataTable CPSGetAccountPackages(string key, string sessionKey);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSGetCurrentAccountPackage",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSGetCurrentAccountPackage(string key, string sessionKey);


            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSGetAvailableAddOns",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSGetAvailableAddOns(string key, string sessionKey, string newPackageName);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSCheckPromotionCode",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSCheckPromotionCode(string key, string sessionKey, string promotionCodeValue, int packageId);

           
            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSGetContactInfo",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            System.Data.DataTable CPSGetContactInfo(string key, string sessionKey);

            
            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSGetBillingInfo",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            System.Data.DataTable CPSGetBillingInfo(string key, string sessionKey);

           
            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSSetContactInfo",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            void CPSSetContactInfo(
                string key,
                string sessionKey,
                string firstName,
                string lastName,
                string title,
                string company,
                string employees,
                string industry,
                string phone,
                string secondaryPhone,
                string email,
                string url,
                string address1,
                string address2,
                string city,
                string state,
                string country,
                string zip);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSSetBillingInfo",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            void CPSSetBillingInfo(
                string firstName,
                string lastName,
                string address1,
                string address2,
                string city,
                string state,
                string zip,
                string country,
                string phone,
                string email,
                string ccNumber,
                string ccType,
                string ccExpMonth,
                string ccExpYear,
                bool emailReceipt,
                string receiptEmails);

            
            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSCalcNewPackage",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSCalcNewPackage(string key, string sessionKey, string newPackageName, int newBillingCycle,
                                                     int promoCodeId, string addOnsXml);

            /// <remarks/>
            [SoapDocumentMethod(
                "http://federation.caspio.com/BridgePayWS/CPSDoUpgradeDowngradeAccount",
                RequestNamespace = "http://federation.caspio.com/BridgePayWS",
                ResponseNamespace = "http://federation.caspio.com/BridgePayWS",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            string CPSDoUpgradeDowngradeAccount(string key, string sessionKey, string newPackageName,
                                                                int newBillingCycle, int promoCodeId, string addOnsXml);

        }

}
