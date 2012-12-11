using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CPS.WebUI.Common;

namespace CPS.WebUI.Models
{
    public class PackageViewModel
    {
        /// <summary>
        /// Gets or sets the plans.
        /// </summary>
        /// <value>
        /// The plans.
        /// </value>
        public IEnumerable<PlanViewModel> Plans { get; set; }

        /// <summary>
        /// Gets or sets the current package.
        /// </summary>
        /// <value>
        /// The current package.
        /// </value>
        public CurrentPackage CurrentPackage { get; set; }

        /// <summary>
        /// Gets or sets the add on groups.
        /// </summary>
        /// <value>
        /// The add on groups.
        /// </value>
        public IEnumerable<AddOnGroupViewModel> AddOnGroups { get; set; }

        /// <summary>
        /// Gets or sets the other add-ons.
        /// </summary>
        /// <value>
        /// The other add ons.
        /// </value>
        public IEnumerable<AddOnItemViewModel> OtherAddOns { get; set; }

        /// <summary>
        /// Gets or sets the contact information.
        /// </summary>
        /// <value>
        /// The contact info.
        /// </value>
        public ContactInfoViewModel ContactInfo { get; set; }

    }
}