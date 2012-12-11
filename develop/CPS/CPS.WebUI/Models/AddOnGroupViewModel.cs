using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class AddOnGroupViewModel
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>
        /// The name of the group.
        /// </value>
        public String GroupName { get; set; }

        /// <summary>
        /// Gets or sets the add-ons in the group.
        /// </summary>
        /// <value>
        /// The add on view models.
        /// </value>
        public IEnumerable<AddOnItemViewModel> AddOns { get; set; }
    }
}