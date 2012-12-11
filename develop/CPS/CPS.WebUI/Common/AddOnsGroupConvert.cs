using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPS.WebUI.Models;

namespace CPS.WebUI.Common
{
    public static class AddOnsGroupConvert
    {
        public static List<AddOnItemViewModel> ToAddOns(this AddOnGroupViewModel AddOnGroup)
        {
            List<AddOnItemViewModel> addOns = new List<AddOnItemViewModel>();
            foreach (var addOn in AddOnGroup.AddOns)
            {
                AddOnItemViewModel newAddOn = addOn.Clone();
                newAddOn.GroupName = addOn.GroupName;
                addOns.Add(newAddOn);
            }
            return addOns;
        }
    }
}