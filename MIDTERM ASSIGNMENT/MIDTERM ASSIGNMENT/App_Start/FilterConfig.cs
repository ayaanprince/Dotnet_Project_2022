using System.Web;
using System.Web.Mvc;

namespace MIDTERM_ASSIGNMENT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
