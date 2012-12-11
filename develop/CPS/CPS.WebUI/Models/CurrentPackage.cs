using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class CurrentPackage
    {
        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        public String PackageName { get; set; }

        /// <summary>
        /// Gets or sets the category of the package.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public String Category { get; set; }

        /// <summary>
        /// Gets or sets the base fee.
        /// </summary>
        /// <value>
        /// The base fee.
        /// </value>
        public Decimal BaseFee { get; set; }

        /// <summary>
        /// Gets or sets the formatted base fee of the package.
        /// </summary>
        /// <value>
        /// The base fee absolute formatted.
        /// </value>
        public String BaseFeeAbsoluteFormatted { get; set; }

        /// <summary>
        /// Gets or sets the billing cycle.
        /// </summary>
        /// <value>
        /// The billing cycle.
        /// </value>
        public int BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discounts.
        /// </value>
        public DiscountViewModel Discount { get; set; }

        /// <summary>
        /// Gets or sets the recurring fees.
        /// </summary>
        /// <value>
        /// The recurring fees.
        /// </value>
        public IEnumerable<RecurringFeeViewModel> RecurringFees { get; set; }

        /// <summary>
        /// Gets or sets the total recurring fee.
        /// </summary>
        /// <value>
        /// The recurring total.
        /// </value>
        public Decimal RecurringTotal { get; set; }

        /// <summary>
        /// Gets the formatted total recurring fee.
        /// </summary>
        /// <value>
        /// The recurring total absolute formatted.
        /// </value>
        public String RecurringTotalAbsoluteFormatted { get { return RecurringTotal.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the credits.
        /// </summary>
        /// <value>
        /// The credits.
        /// </value>
        public Decimal Credits { get; set; }

        /// <summary>
        /// Gets or sets the formatted credits .
        /// </summary>
        /// <value>
        /// The credits absolute formatted.
        /// </value>
        public String CreditsAbsoluteFormatted { get { return Credits.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the cycle due fee.
        /// </summary>
        /// <value>
        /// The cycle due.
        /// </value>
        public Decimal CycleDue { get; set; }

        /// <summary>
        /// Gets or sets the formatted cycle due fee.
        /// </summary>
        /// <value>
        /// The cycle due absolute formatted.
        /// </value>
        public String CycleDueAbsoluteFormatted { get { return CycleDue.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the plan in current package.
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>
        public PlanViewModel Plan { get; set; }

    }
}