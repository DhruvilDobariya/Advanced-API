using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace FilterLearn.Filters
{
    public class ExceptionFilterLearn : Attribute, IExceptionFilter
    {

        bool IFilter.AllowMultiple => false;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            string path = @"C:\Users\dhruvil.d\Learn\dotnet\Advanced API\code\2.Security\FilterLearn\FilterLearn\Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (StreamWriter streamWriter = File.AppendText(Path.Combine(path, "Log.txt")))
            {
                StackTrace stackTrace = new StackTrace(actionExecutedContext.Exception, true);
                StackFrame frame = stackTrace.GetFrame(0);
                var jsonObject = new JObject();
                jsonObject.Add("File", frame.GetFileName());
                jsonObject.Add("Method", frame.GetMethod().Name);
                jsonObject.Add("LineNumber", frame.GetFileLineNumber());
                jsonObject.Add("DateTime", DateTime.UtcNow);

                streamWriter.WriteLine(jsonObject.ToString());
            }

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent("You can't any number divide by zero"),
                StatusCode = HttpStatusCode.BadRequest
            };

            // if method is asynchronous and if we don't need to use async await in method then, we just return Task.ComplateTask.
            return Task.CompletedTask;
        }
    }
}