using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class AccountFeeModelView
    {
        /// <summary>
        /// Gets or sets the title of the Fee.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the value of the fee.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public Decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the value of feee in absolute formatted.
        /// </summary>
        /// <value>
        /// The value absolute formatted.
        /// </value>
        public String ValueAbsoluteFormatted { get; set; }

        /// <summary>
        /// Gets or sets the fee type
        /// </summary>
        /// <value>
        /// The monthly or onetime.
        /// </value>
        public FeeType MonthlyOrOneTime { get; set; }

    }

    public enum FeeType
    {
        Monthly,
        OneTime
    }
}