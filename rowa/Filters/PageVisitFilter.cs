using rowa.repository.Entities;
using rowa.repository.Interfaces;
using System;
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
                    VisitCount = 1,
                    LastVisitedDate = DateTime.Now
                };

                _pageVisitRepository.Add(newPage);
            }
            else
            {
                page.VisitCount++;
                page.LastVisitedDate = DateTime.Now;

                _pageVisitRepository.Update(page);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}