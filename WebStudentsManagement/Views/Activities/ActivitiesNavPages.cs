using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebStudentsManagement.Views.Activities
{
    public static class ActivitiesNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Activities => "StudentActivities";

        //public static string Activity => "Activity";

        public static string ListActivities(ViewContext viewContext) => PageNavClass(viewContext, Activities);

        //public static string ListActivity(ViewContext viewContext) => PageNavClass(viewContext, Activity);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
