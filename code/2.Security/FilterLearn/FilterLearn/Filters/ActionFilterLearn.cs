using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterLearn.Filters
{
    //public class ActionFilterLearn : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(HttpActionContext actionContext)
    //    {
    //        base.OnActionExecuting(actionContext);
    //        actionContext.Request.Headers.Add("X-Id", "1");
    //    }
    //    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        base.OnActionExecuted(actionExecutedContext);
    //        actionExecutedContext.Response.Headers.Add("X-Name", "Dhruvil Dobariya");
    //    }

    //    // Asynchronous filter
    //    public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    //    {
    //        actionContext.Request.Headers.Add("X-Id", "1");
    //        await base.OnActionExecutingAsync(actionContext, cancellationToken);
    //    }
    //    public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
    //    {
    //        actionExecutedContext.Response.Headers.Add("X-Name", "Dhruvil Dobariya");
    //        await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
    //    }
    //}
    public class ActionFilterLearn : Attribute, IActionFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            actionContext.Request.Headers.Add("X-Id", "1");
            var response = await continuation();
            response.Headers.Add("X-Name", "Dhruvil A. Dobariya");
            return response;
        }
    }
}