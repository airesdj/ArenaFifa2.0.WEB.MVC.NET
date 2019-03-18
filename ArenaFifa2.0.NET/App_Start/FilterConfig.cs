using System.Web;
using System.Web.Mvc;

namespace ArenaFifa2._0.NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
