using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CPS.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPS.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string package = 
                @"<xml>
    <package>
        <packageName>PackageName</packageName>
        <packageCategory>PackageCategory</packageCategory>
        <baseFee>49.99</baseFee> 
        <baseFeeAbsoluteFormatted>49.99</baseFeeAbsoluteFormatted>
        <billingCycle>1</billingCycle>       
        <recurringDiscounts>
            <discount>
            <title>SomeDiscountName</title>
            <description>SomeDiscountDescription</description>
            <amount>12.00</amount>
            <amountAbsoluteFormatted>12.00</amountAbsoluteFormatted>
		</discount>
        </recurringDiscounts>
        <recurringFees>
            <fee isAdditionalResource=""False"" addOnId=""101"" addOnGroup=""SomeGroup"">
            <title>SomeAddOnTitle</title>
            <description>SomeAddOnDescription</description>
            <amount>9.99</amount>
            <amountAbsoluteFormatted>9.99</amountAbsoluteFormatted>
        </fee>
        </recurringFees>
        <recurringTotal>47.98</recurringTotal>
        <recurringTotalAbsoluteFormatted>47.98</recurringTotalAbsoluteFormatted>
        <nonRecurringTotal>0.00</nonRecurringTotal>
        <nonRecurringTotalAbsoluteFormatted>0.00</nonRecurringTotalAbsoluteFormatted>
        <creditsTotal>0.00</creditsTotal>
        <creditsTotalAbsoluteFormatted>0.00</creditsTotalAbsoluteFormatted>
        <isNewBillingSystem>True</isNewBillingSystem>
        <isAutoBill>True</isAutoBill>
        <invoicesBalanceTotal>29.99</invoicesBalanceTotal>
        <invoicesBalanceTotalAbsoluteFormatted>29.99</invoicesBalanceTotalAbsoluteFormatted>
    </package>
</xml>";

            string addOns = @"<AddOns>
	<Group Name=""Support"">
		<AddOn>
<FeeId>1234</FeeId>
<AddOnId>1111</AddOnId>
<Title>Support1</Title>
<Description>SomeDescription</Description>
<Checked>True</Checked>
<CanBeChanged>False</CanBeChanged>
<SetUpFee>0.00</SetUpFee>
<SetUpFeeAbsoluteFormatted>0.00</SetUpFeeAbsoluteFormatted>
<MonthlyFee>79.99</MonthlyFee>
<MonthlyFeeAbsoluteFormatted>79.99</MonthlyFeeAbsoluteFormatted>
<Rewritten>False</Rewritten>
<Automated>True</Automated>
</AddOn>
		<AddOn>
<FeeId>1234</FeeId>
<AddOnId>1111</AddOnId>
<Title>Support2</Title>
<Description>SomeDescription</Description>
<Checked>True</Checked>
<CanBeChanged>False</CanBeChanged>
<SetUpFee>0.00</SetUpFee>
<SetUpFeeAbsoluteFormatted>0.00</SetUpFeeAbsoluteFormatted>
<MonthlyFee>79.99</MonthlyFee>
<MonthlyFeeAbsoluteFormatted>79.99</MonthlyFeeAbsoluteFormatted>
<Rewritten>False</Rewritten>
<Automated>True</Automated>
</AddOn>
	</Group>
	<Group Name=""Other"">
	<AddOn>
<FeeId>1234</FeeId>
<AddOnId>1111</AddOnId>
<Title>Other1</Title>
<Description>SomeDescription</Description>
<Checked>True</Checked>
<CanBeChanged>False</CanBeChanged>
<SetUpFee>0.00</SetUpFee>
<SetUpFeeAbsoluteFormatted>0.00</SetUpFeeAbsoluteFormatted>
<MonthlyFee>79.99</MonthlyFee>
<MonthlyFeeAbsoluteFormatted>79.99</MonthlyFeeAbsoluteFormatted>
<Rewritten>False</Rewritten>
<Automated>True</Automated>
</AddOn>
	</Group>
</AddOns>
";

            XElement root = XElement.Parse(addOns);
            var addOnsGroups = from g in root.Elements() 
                                   select new AddOnGroupViewModel
                                              {
                                                  GroupName = g.Attribute("Name").Value,
                                                  AddOns = from a in g.Elements()
                                                                    select new AddOnItemViewModel
                                                                               {
                                                                                   AddOnId = Int32.Parse(a.Element("AddOnId").Value)

                                                                               }
                                              };



            IEnumerable<XElement> address =
                from el in root.Elements("Address")
                where (string) el.Attribute("Type") == "Billing"
                select el;
            foreach (XElement el in address)
                Console.WriteLine(el);

            int whiteSpaceNodes;

            XElement xmlTree1 = XElement.Parse("<Root> <Child> </Child> </Root>",
                LoadOptions.None);
            whiteSpaceNodes = xmlTree1
                .DescendantNodesAndSelf()
                .OfType<XText>()
                .Where(tNode => tNode.ToString().Trim().Length == 0)
                .Count();
            Console.WriteLine("Count of white space nodes (not preserving whitespace): {0}",
                whiteSpaceNodes);

            XElement xmlTree2 = XElement.Parse("<Root> <Child> </Child> </Root>",
                LoadOptions.PreserveWhitespace);
            
            whiteSpaceNodes = xmlTree2
                .DescendantNodesAndSelf()
                .OfType<XText>().Count(tNode => tNode.ToString().Trim().Length == 0);
            Console.WriteLine("Count of white space nodes (preserving whitespace): {0}",
                whiteSpaceNodes);
        }
    }
}
