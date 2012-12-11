using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPS.WebUI.Models
{
    public class UpgradeInfoViewModel
    {
        public ContactInfoViewModel ContactInfoViewModel { get; set; }

        public BillingInfoViewModel BillingInfoViewModel { get; set; }
    }
}