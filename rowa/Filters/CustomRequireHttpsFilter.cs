using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rowa.Filters
{
    public class CustomRequireHttpsFilter : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationContext filterContext)
        {
            // If the request does not have a GET or HEAD verb then we throw it away.
            if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(filterContext.HttpContext.Request.HttpMethod, "HEAD", StringComparison.OrdinalIgnoreCase))
            {
                base.HandleNonHttpsRequest(filterContext);
            }

            // Update the URL to use https instead of http
            var url = "https://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;

            // If it's localhost we are using IIS Express which has two different ports.
            // update the url with the IIS Express port for redirect on local machine.
            if (string.Equals(filterContext.HttpContext.Request.Url.Host, "localhost", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + filterContext.HttpContext.Request.Url.Host + ":44363" + filterContext.HttpContext.Request.RawUrl;
            }

            // Build the httpContext Response
            // Setting a status of 301 and then telling the browser what the correct route is.
            filterContext.HttpContext.Response.StatusCode = 301;
            filterContext.HttpContext.Response.AppendHeader("Location", url);
            filterContext.HttpContext.Response.End();
        }
    }
}