using System.Web;
using System.Web.Mvc;

namespace Hotel_Casanova_mvc_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
