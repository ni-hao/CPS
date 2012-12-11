using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using CPS.Abstract.BridgePay;
using CPS.WebUI.Common;
using CPS.WebUI.Models;
using log4net;

namespace CPS.WebUI.Controllers
{
    public class PackageController : Controller
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private String _key = WebConfigurationManager.AppSettings["key"];

        public IBridgePayWS BridgePayWS { get; set; }
        //
        // GET: /Package/

        public ActionResult Index(String sessionKey)
        {
            PackageViewModel package = new PackageViewModel(); ;

            // Query the plans of the account;
            DataTable accountPackages = BridgePayWS.CPSGetAccountPackages(_key, sessionKey);
            var plans = from p in accountPackages.AsEnumerable()
                        select new PlanViewModel
                                   {
                                       PlanId = p.Field<int>("acct_type_id"),
                                       PlanName = p.Field<String>("acct_type_name"),
                                       Bandwidth = p.Field<int>("bandwidth"),
                                       CategoryName = p.Field<String>("category_name"),
                                       StandardFee = p.Field<Decimal>("standard_fee"),
                                       DataTransferUnit = p.Field<int>("data_transfer_unit"),
                                       DataTransferFee = p.Field<Decimal>("data_transfer_fee"),
                                       DataPagesUnit = p.Field<int>("data_pages_unit"),
                                       DataPagesFee = p.Field<Decimal>("data_pages_fee"),
                                       EmailsUnit = p.Field<int>("emails_unit"),
                                       EmailsFee = p.Field<Decimal>("emails_fee"),
                                       StorageUnit = p.Field<int>("storage_unit"),
                                       StorageFee = p.Field<Decimal>("stogare_fee")
                                   };
            package.Plans = plans;

            // Query current account's contact information
            package.ContactInfo = fetchContactInfo(sessionKey);

            // Query the current account package.
            String currentAccountPackageStr = BridgePayWS.CPSGetCurrentAccountPackage(_key, sessionKey);
            XElement currentPackageX = XElement.Parse(currentAccountPackageStr).Element("package");
            XElement currentDiscountX = currentPackageX.Element("recurringDiscounts").Element("discount");
            XElement currentResurringFeeX = currentPackageX.Element("recurringFees");
            var currentPackage = new CurrentPackage
                                     {
                                         BaseFee = Decimal.Parse(currentPackageX.Element("baseFee").Value),
                                         BillingCycle = Int32.Parse(currentPackageX.Element("billingCycle").Value),
                                         Category = currentPackageX.Element("packageCategory").Value,
                                         Credits = Decimal.Parse(currentPackageX.Element("creditsTotal").Value),
                                         CycleDue = Decimal.Parse(currentPackageX.Element("invoicesBalanceTotal").Value),
                                         Discount = new DiscountViewModel
                                                        {
                                                            Amount = Decimal.Parse(currentDiscountX.Element("amount").Value),
                                                            Description = currentDiscountX.Element("description").Value,
                                                            Title = currentDiscountX.Element("title").Value
                                                        },
                                         PackageName = currentPackageX.Element("packageName").Value,
                                         RecurringTotal = Decimal.Parse(currentPackageX.Element("recurringTotal").Value),
                                         RecurringFees = from rx in currentResurringFeeX.Elements("fee")
                                                         select new RecurringFeeViewModel
                                                                    {
                                                                        AddOnGroupName = rx.Attribute("addOnGroup") == null ? null : rx.Attribute("addOnGroup").Value,
                                                                        AddOnId = Int32.Parse(rx.Attribute("addOnId").Value),
                                                                        Amount = Decimal.Parse(rx.Element("amount").Value),
                                                                        Description = rx.Element("description").Value,
                                                                        IsAdditionalResource = rx.Attribute("isAdditionalResource").Equals("True"),
                                                                        Title = rx.Element("title").Value
                                                                    }
                                     };
            currentPackage.Plan = plans.FirstOrDefault(p => p.PlanName == currentPackage.PackageName);
            package.CurrentPackage = currentPackage;

            // Query the Add-Ons
            var addOns = BridgePayWS.CPSGetAvailableAddOns(_key, sessionKey, currentPackage.PackageName);
            XElement addOnsXElement = XElement.Parse(addOns);
            // Add in-group Add-Ons
            var addOnsGroups = from g in addOnsXElement.Elements("Group")
                               select new AddOnGroupViewModel
                                          {
                                              GroupName = g.Attribute("Name").Value,
                                              AddOns = from a in g.Elements()
                                                       select new AddOnItemViewModel
                                                                  {
                                                                      AddOnId = Int32.Parse(a.Element("AddOnId").Value),
                                                                      Automated =
                                                                          a.Element("Automated").Value.Equals("True"),
                                                                      CanBeChanged =
                                                                          a.Element("CanBeChanged").Value.Equals("True"),
                                                                      Description = a.Element("Description").Value,
                                                                      FeeId = Int32.Parse(a.Element("FeeId").Value),
                                                                      IsChecked =
                                                                          a.Element("Checked").Value.Equals("True"),
                                                                      MonthlyFee =
                                                                          Decimal.Parse(a.Element("MonthlyFee").Value),
                                                                      Rewritten =
                                                                          a.Element("Rewritten").Value.Equals("True"),
                                                                      SetUpFee =
                                                                          Decimal.Parse(a.Element("SetUpFee").Value),
                                                                      Title = a.Element("Title").Value
                                                                  }
                                          };
            package.AddOnGroups = addOnsGroups;

            // Add out-group Add-Ons
            var outGroupAddOns = from g in addOnsXElement.Elements("AddOn")
                                 select new AddOnItemViewModel
                                            {
                                                AddOnId = Int32.Parse(g.Element("AddOnId").Value),
                                                Automated =
                                                    g.Element("Automated").Value.Equals("True"),
                                                CanBeChanged =
                                                    g.Element("CanBeChanged").Value.Equals("True"),
                                                Description = g.Element("Description").Value,
                                                FeeId = Int32.Parse(g.Element("FeeId").Value),
                                                IsChecked =
                                                    g.Element("Checked").Value.Equals("True"),
                                                MonthlyFee =
                                                    Decimal.Parse(g.Element("MonthlyFee").Value),
                                                Rewritten =
                                                    g.Element("Rewritten").Value.Equals("True"),
                                                SetUpFee =
                                                    Decimal.Parse(g.Element("SetUpFee").Value),
                                                Title = g.Element("Title").Value
                                            };
            package.OtherAddOns = outGroupAddOns;

            return View(package);
        }

        [ChildActionOnly]
        public ActionResult FetchCountries(string selectedCountry)
        {
            ViewBag.Country = selectedCountry;
            DataTable countriesData = BridgePayWS.ListCountries();

            var countries = from p in countriesData.AsEnumerable()
                            select new CountriesViewModel()
                            {
                                CountryId = p.Field<int>("CountryId"),
                                CountryCode = p.Field<String>("CountryCode"),
                                CountryName = p.Field<String>("Name"),
                            };

            return PartialView("PartialView/Countries", countries);
        }

        [ChildActionOnly]
        public ActionResult FetchIndustries(string selectedIndustry)
        {
            ViewBag.Industry = selectedIndustry;
            DataTable industriesData = BridgePayWS.ListIndustries();

            var industries = from p in industriesData.AsEnumerable()
                            select new IndustriesViewModel()
                            {
                                IndustryId = p.Field<int>("industry_id"),
                                IndustryCode = p.Field<String>("industry_code"),
                                IndustryName = p.Field<String>("industry_name"),
                            };

            return PartialView("PartialView/Industries", industries);
        }

        [HttpPost]
        public ActionResult AjaxDemo(string h2)
        {
            string result = h2 + " from server";
            if (log.IsDebugEnabled)
            {
                log.Debug("debug" + result);
            }

            return Json(new { info = BridgePayWS.ToString() });
        }


        #region private method

        private ContactInfoViewModel fetchContactInfo(String sessionKey)
        {
            DataTable contactData = BridgePayWS.CPSGetContactInfo(_key, sessionKey);

            var contactInfo = new ContactInfoViewModel
                                  {
                                      Address1 = contactData.Rows[0]["address1"].ToString(),
                                      Address2 = contactData.Rows[0]["address2"].ToString(),
                                      City = contactData.Rows[0]["city"].ToString(),
                                      Company = contactData.Rows[0]["company"].ToString(),
                                      CompanySize = contactData.Rows[0]["company_size"].ToString(),
                                      Country = contactData.Rows[0]["country"].ToString(),
                                      Email = contactData.Rows[0]["email"].ToString(),
                                      FirstName = contactData.Rows[0]["contact_first_name"].ToString(),
                                      Industry = contactData.Rows[0]["industry"].ToString(),
                                      LastName = contactData.Rows[0]["contact_last_name"].ToString(),
                                      Phone = contactData.Rows[0]["phone"].ToString(),
                                      PostalCode = contactData.Rows[0]["postalcode"].ToString(),
                                      SecondaryPhone = contactData.Rows[0]["secondary_phone"].ToString(),
                                      State = contactData.Rows[0]["state"].ToString(),
                                      Title = contactData.Rows[0]["title"].ToString(),
                                      Url = contactData.Rows[0]["url"].ToString()
                                  };
            return contactInfo;

        }

        #endregion
    }
}
