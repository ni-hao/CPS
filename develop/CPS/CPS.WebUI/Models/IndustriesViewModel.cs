using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class IndustriesViewModel
    {
        /// <summary>
        /// Gets or sets the industry id.
        /// </summary>
        /// <value>
        /// The industry id.
        /// </value>
        public int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the industry code.
        /// </summary>
        /// <value>
        /// The industry code.
        /// </value>
        public String IndustryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the industry.
        /// </summary>
        /// <value>
        /// The name of the industry.
        /// </value>
        public String IndustryName { get; set; }
    }
}