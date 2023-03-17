using System.Web;
using System.Web.Mvc;

namespace PRUEBA_BRAHAN_ACOSTA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
