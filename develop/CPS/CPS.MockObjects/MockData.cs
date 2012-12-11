using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CPS.MockObjects
{
    public static class MockData
    {
        public static DataTable CPSGetAccountPackages()
        {
            DataTable accountPackages = new DataTable("AccountPackages");
            DataColumn[] packageColumns = new DataColumn[]
                                              {
                                                  new DataColumn
                                                      {
                                                          ColumnName = "acct_type_id",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 1
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "acct_type_name",
                                                          DataType = typeof (String),
                                                          DefaultValue = "Free Trial"
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "bandwidth",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 250
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "category_name",
                                                          DataType = typeof (String),
                                                          DefaultValue = "Trial"
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "standard_fee",
                                                          DataType = typeof (Decimal),
                                                          DefaultValue = 0
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "data_transfer_unit",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 50
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "data_transfer_fee",
                                                          DataType = typeof (Decimal),
                                                          DefaultValue = 5
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "data_pages_unit",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 40
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "data_pages_fee",
                                                          DataType = typeof (Decimal),
                                                          DefaultValue = 4
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "emails_unit",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 30
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "emails_fee",
                                                          DataType = typeof (Decimal),
                                                          DefaultValue = 3
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "storage_unit",
                                                          DataType = typeof (Int32),
                                                          DefaultValue = 80
                                                      },
                                                  new DataColumn
                                                      {
                                                          ColumnName = "stogare_fee",
                                                          DataType = typeof (Decimal),
                                                          DefaultValue = 8
                                                      },
                                              };
            accountPackages.Columns.AddRange(packageColumns);

            DataRow newRow;
            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 1;
            newRow["acct_type_name"] = "Free Trial";
            newRow["bandwidth"] = 0;
            newRow["category_name"] = "Trial";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);

            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 2;
            newRow["acct_type_name"] = "Small";
            newRow["bandwidth"] = 250;
            newRow["category_name"] = "Others";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);


            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 3;
            newRow["acct_type_name"] = "Medium";
            newRow["bandwidth"] = 2000;
            newRow["category_name"] = "Business";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);


            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 4;
            newRow["acct_type_name"] = "Large";
            newRow["bandwidth"] = 5000;
            newRow["category_name"] = "Others";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);


            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 5;
            newRow["acct_type_name"] = "Extra Large";
            newRow["bandwidth"] = 10000;
            newRow["category_name"] = "Others";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);


            newRow = accountPackages.NewRow();
            newRow["acct_type_id"] = 6;
            newRow["acct_type_name"] = "SUPER Size";
            newRow["bandwidth"] = 100000;
            newRow["category_name"] = "Others";
            newRow["standard_fee"] = 1;
            newRow["data_transfer_unit"] = 1;
            newRow["data_transfer_fee"] = 1;
            newRow["data_pages_unit"] = 1;
            newRow["data_pages_fee"] = 1;
            newRow["emails_unit"] = 1;
            newRow["emails_fee"] = 1;
            newRow["storage_unit"] = 1;
            newRow["stogare_fee"] = 1;
            accountPackages.Rows.Add(newRow);

            return accountPackages;
        }

        public static String CPSGetCurrentAccountPackage()
        {
            return @"<xml>
    <package>
        <packageName>Small</packageName>
        <packageCategory>Others</packageCategory>
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
            <fee isAdditionalResource=""False"" addOnId=""1"" addOnGroup=""Support"">
            <title>SomeAddOnTitle</title>
            <description>SomeAddOnDescription</description>
            <amount>9.99</amount>
            <amountAbsoluteFormatted>9.99</amountAbsoluteFormatted>
        </fee>
            <fee isAdditionalResource=""False"" addOnId=""1"">
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
        <creditsTotal>10.00</creditsTotal>
        <creditsTotalAbsoluteFormatted>10.00</creditsTotalAbsoluteFormatted>
        <isNewBillingSystem>True</isNewBillingSystem>
        <isAutoBill>True</isAutoBill>
        <invoicesBalanceTotal>29.99</invoicesBalanceTotal>
        <invoicesBalanceTotalAbsoluteFormatted>29.99</invoicesBalanceTotalAbsoluteFormatted>
    </package>
</xml>
";
        }

        public static string CPSGetAvailableAddOns()
        {
            return @"<AddOns>
	<Group Name=""Support"">
		<AddOn>
<FeeId>1</FeeId>
<AddOnId>1</AddOnId>
<Title>SomeTitle</Title>
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
<FeeId>2</FeeId>
<AddOnId>2</AddOnId>
<Title>SomeTitle</Title>
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
	<AddOn>
<FeeId>3</FeeId>
<AddOnId>3</AddOnId>
<Title>Technology1</Title>
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
<FeeId>4</FeeId>
<AddOnId>4</AddOnId>
<Title>Technology2</Title>
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
</AddOns>
";
        }
    }
}
