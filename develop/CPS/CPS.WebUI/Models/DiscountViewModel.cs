using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class DiscountViewModel
    {
        /// <summary>
        /// Gets or sets the title of the discount.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the discount.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the amount of the discount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public Decimal Amount { get; set; }

        /// <summary>
        /// Gets the formatted amount of the discount.
        /// </summary>
        /// <value>
        /// The amount absolute formatted.
        /// </value>
        public String AmountAbsoluteFormatted { get { return Amount.ToString("###,##0.00"); } }
    }
}