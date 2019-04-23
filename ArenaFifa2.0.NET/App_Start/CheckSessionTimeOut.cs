using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaFifa20.NET.App_Start
{
    public class CheckSessionTimeOut
    {
        public class SessionTimeoutAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
                if (Convert.ToBoolean(HttpContext.Current.Session["session.active"]) == false)
                {
                    filterContext.Result = new RedirectResult("~/Account/Signin");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}