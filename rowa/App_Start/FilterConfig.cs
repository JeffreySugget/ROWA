using rowa.Filters;
using rowa.repository.Entities;
using rowa.repository.Interfaces;
using rowa.repository.Repositories;
using System.Web;
using System.Web.Mvc;

namespace rowa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PageVisitFilter(new PageVisitRepository()));
            filters.Add(new PerformanceFilter(new PerformanceLogRepository()));
        }
    }
}
