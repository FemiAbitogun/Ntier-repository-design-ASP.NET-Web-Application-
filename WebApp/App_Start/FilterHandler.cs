using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class FilterHandler
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection  filter)
        {

            HandleErrorAttribute errorFilter = new HandleErrorAttribute();
            errorFilter.View = "ErrorView";
            filter.Add(errorFilter);

        }
    }
}