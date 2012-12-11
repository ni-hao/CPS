using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class AddOnItemViewModel
    {
        /// <summary>
        /// Gets or sets the add-on id.
        /// </summary>
        /// <value>
        /// The add on id.
        /// </value>
        public int AddOnId { get; set; }

        // todo Can't understand property
        /// <summary>
        /// Gets or sets the fee id.
        /// </summary>
        /// <value>
        /// The fee id.
        /// </value>
        public int FeeId { get; set; }

        /// <summary>
        /// Gets or sets the group name of the AddOn.
        /// </summary>
        /// <value>
        /// The name of the group.
        /// </value>
        public String GroupName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets if it is checked.
        /// </summary>
        /// <value>
        /// The is checked.
        /// </value>
        public Boolean IsChecked { get; set; }

        /// <summary>
        /// Gets or sets if it can be changed.
        /// </summary>
        /// <value>
        /// The can be changed.
        /// </value>
        public Boolean CanBeChanged { get; set; }

        /// <summary>
        /// Gets or sets the setting up fee.
        /// </summary>
        /// <value>
        /// The set up fee.
        /// </value>
        public Decimal SetUpFee { get; set; }

        /// <summary>
        /// Gets or sets the formatted setting up fee.
        /// </summary>
        /// <value>
        /// The set up fee absolute formatted.
        /// </value>
        public string SetUpFeeAbsoluteFormatted { get { return MonthlyFee.ToString("###,##0.00"); } }

        /// <summary>
        /// Gets or sets the monthly fee.
        /// </summary>
        /// <value>
        /// The monthly fee.
        /// </value>
        public Decimal MonthlyFee { get; set; }

        /// <summary>
        /// Gets or sets the formatted monthly fee.
        /// </summary>
        /// <value>
        /// The monthly fee absolute formatted.
        /// </value>
        public String MonthlyFeeAbsoluteFormatted { get { return MonthlyFee.ToString("###,##0.00"); } }

        // todo Can't understand property
        public Boolean Rewritten { get; set; }

        // todo Can't understand property
        public Boolean Automated { get; set; }

        public AddOnItemViewModel Clone()
        {
            return (AddOnItemViewModel)this.MemberwiseClone();
        }

    }
}