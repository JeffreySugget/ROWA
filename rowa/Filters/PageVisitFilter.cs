using rowa.repository.Entites;
using rowa.repository.Interfaces;
using System.Web.Mvc;

namespace rowa.Filters
{
    public class PageVisitFilter : ActionFilterAttribute
    {
        private readonly IPageVisitRepository _pageVisitRepository;

        public PageVisitFilter(IPageVisitRepository pageVisitRepository)
        {
            _pageVisitRepository = pageVisitRepository;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url.ToString();
            var page = _pageVisitRepository.GetPage(url).Result;

            if (page == null)
            {
                var newPage = new PageVisit
                {
                    Url = url,
                    VisitCount = 1
                };

                _pageVisitRepository.AddPageVisit(newPage);
            }
            else
            {
                page.VisitCount++;

                _pageVisitRepository.Update(page);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}