using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    /// <summary>
    /// The View Model of Package
    /// </summary>
    public class PlanViewModel
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        /// <value>
        /// The package id.
        /// </value>
        public int PlanId { get; set; }

        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        public String PlanName { get; set; }

        /// <summary>
        /// Gets or sets the allowed data transfer in MBytes.
        /// </summary>
        /// <value>
        /// The bandwidth.
        /// </value>
        public int Bandwidth { get; set; }

        /// <summary>
        /// Gets or sets the package category.
        /// </summary>
        /// <value>
        /// The type of the category.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the account monthly price.
        /// </summary>
        /// <value>
        /// The standard fee.
        /// </value>
        public Decimal StandardFee { get; set; }

        /// <summary>
        /// Gets or sets the size of excess data transfer unit in MBytes .
        /// </summary>
        /// <value>
        /// The data transfer unit.
        /// </value>
        public int DataTransferUnit { get; set; }

        /// <summary>
        /// Gets or sets the price for one excess usage unit.
        /// </summary>
        /// <value>
        /// The data transfer fee.
        /// </value>
        public Decimal DataTransferFee { get; set; }

        /// <summary>
        /// Gets or sets the data pages unit.
        /// </summary>
        /// <value>
        /// The data pages unit.
        /// </value>
        public int DataPagesUnit { get; set; }

        /// <summary>
        /// Gets or sets the data pages fee of one excess unit.
        /// </summary>
        /// <value>
        /// The data pages fee.
        /// </value>
        public Decimal DataPagesFee { get; set; }

        /// <summary>
        /// Gets or sets the emails unit.
        /// </summary>
        /// <value>
        /// The emails unit.
        /// </value>
        public int EmailsUnit { get; set; }

        /// <summary>
        /// Gets or sets the emails fee of one excess unit.
        /// </summary>
        /// <value>
        /// The emails fee.
        /// </value>
        public Decimal EmailsFee { get; set; }

        /// <summary>
        /// Gets or sets the storage unit.
        /// </summary>
        /// <value>
        /// The storage unit.
        /// </value>
        public int StorageUnit { get; set; }

        /// <summary>
        /// Gets or sets the storage fee of one excess unit.
        /// </summary>
        /// <value>
        /// The storage fee.
        /// </value>
        public Decimal StorageFee { get; set; }
    }
}