using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class AccountSummaryViewModel
    {
        /// <summary>
        /// Gets or sets the monthly fees.
        /// </summary>
        /// <value>
        /// The monthly fees.
        /// </value>
        public List<AccountFeeModelView> MonthlyFees { get; set; }

        /// <summary>
        /// Gets or sets the total of monthly fee .
        /// </summary>
        /// <value>
        /// The monthly fee total.
        /// </value>
        public Decimal MonthlyFeeTotal { get; set; }

        /// <summary>
        /// Gets the monthly fee total in absolute format.
        /// </summary>
        /// <value>
        /// The monthly fee total absolute formatted.
        /// </value>
        public String MonthlyFeeTotalAbsoluteFormatted { get { return MonthlyFeeTotal.ToString("###,##0.00"); }}

        /// <summary>
        /// Gets or sets the one time fees.
        /// </summary>
        /// <value>
        /// The one time fees.
        /// </value>
        public List<AccountFeeModelView> OneTimeFees { get; set; }

        /// <summary>
        /// Gets or sets the one time fee total.
        /// </summary>
        /// <value>
        /// The one time fee total.
        /// </value>
        public Decimal OneTimeFeeTotal { get; set; }

        /// <summary>
        /// Gets the one time fee total in absolute format.
        /// </summary>
        /// <value>
        /// The one time fee total absolute formatted.
        /// </value>
        public String OneTimeFeeTotalAbsoluteFormatted { get { return OneTimeFeeTotal.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the discounts title.
        /// </summary>
        /// <value>
        /// The discounts title.
        /// </value>
        public String DiscountsTitle { get; set; }

        /// <summary>
        /// Gets or sets the discount value.
        /// </summary>
        /// <value>
        /// The discount value.
        /// </value>
        public Decimal DiscountValue { get; set; }

        /// <summary>
        /// Gets the discount value absolute formatted.
        /// </summary>
        /// <value>
        /// The discount value absolute formatted.
        /// </value>
        public String DiscountValueAbsoluteFormatted { get { return DiscountValue.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets the total fee.
        /// </summary>
        /// <value>
        /// The total fee.
        /// </value>
        public String TotalFee { get { return (MonthlyFeeTotal * BillingCycle + OneTimeFeeTotal - DiscountValue).ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the billing cycle.
        /// </summary>
        /// <value>
        /// The billing cycle.
        /// </value>
        public int BillingCycle { get; set; }
    }
}