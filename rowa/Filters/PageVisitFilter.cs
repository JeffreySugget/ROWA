using rowa.repository.Entites;
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
            //var page = _pageVisitRepository.GetPage(url).Result;
            var page = new PageVisit();

            if (RequestIsFromSameSession(filterContext, page, url))
            {
                return;
            }

            if (page == null)
            {
                var newPage = new PageVisit
                {
                    Url = url,
                    VisitCount = 1,
                    LastVisitedDate = DateTime.UtcNow
                };

                _pageVisitRepository.Add(newPage);
            }
            else
            {
                page.VisitCount++;
                page.LastVisitedDate = DateTime.UtcNow;

                //_pageVisitRepository.Update(page);
            }

            base.OnActionExecuted(filterContext);
        }

        private bool RequestIsFromSameSession(ActionExecutedContext filterContext, PageVisit page, string url)
        {
            // Need to check if the request for the same page is being made in the same session
            // If so no need to log it again, will prevent spamming of refresh button and fudging visit numbers
            // Prob want a better way than storing in a session varible though ?

            if (page == null)
            {
                return false;
            }

            if (filterContext.HttpContext.Session["SessionId"] == null)
            {
                filterContext.HttpContext.Session["SessionId"] = filterContext.HttpContext.Session.SessionID;
                return false;
            }

            if (filterContext.HttpContext.Session["SessionId"].ToString() == filterContext.HttpContext.Session.SessionID && 
                page.LastVisitedDate > DateTime.UtcNow.AddHours(-1) &&
                string.Equals(url, page.Url))
            {
                return true;
            }

            return false;
        }
    }
}