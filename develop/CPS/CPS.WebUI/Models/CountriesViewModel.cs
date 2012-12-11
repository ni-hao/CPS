using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class CountriesViewModel
    {
        /// <summary>
        /// Gets or sets the country id.
        /// </summary>
        /// <value>
        /// The country id.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public String CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public String CountryName { get; set; }

    }
}