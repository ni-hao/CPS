using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class RecurringFeeViewModel
    {

        /// <summary>
        /// Gets or sets the add-on id of the recurring fee.
        /// </summary>
        /// <value>
        /// The add on id.
        /// </value>
        public int AddOnId { get; set; }

        /// <summary>
        /// Gets or sets the if it is additional resource.
        /// </summary>
        /// <value>
        /// The is additional resource.
        /// </value>
        public Boolean IsAdditionalResource { get; set; }

        /// <summary>
        /// Gets or sets the group name of the add-on of the recurring fee.
        /// </summary>
        /// <value>
        /// The name of the add on group.
        /// </value>
        public String AddOnGroupName { get; set; }

        /// <summary>
        /// Gets or sets the title of the recurring fee.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the recurring fee.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the amount of the fee.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public Decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the formatted amount of the fee.
        /// </summary>
        /// <value>
        /// The amount absolute formatted.
        /// </value>
        public String AmountAbsoluteFormatted { get { return Amount.ToString("###,##0.00"); } }
    }
}