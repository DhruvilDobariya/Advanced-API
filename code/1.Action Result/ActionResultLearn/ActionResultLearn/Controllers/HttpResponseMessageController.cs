using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActionResultLearn.Controllers
{
    public class HttpResponseMessageController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Ok()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.OK, // 200
                RequestMessage = new HttpRequestMessage(HttpMethod.Get, "request uri")
            };
        }

        [HttpPost]
        public HttpResponseMessage Created()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.Created, // 201
            };
        }

        [HttpPut]
        public HttpResponseMessage Accepted()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.Accepted, // 203
            };
        }

        [HttpPut]
        public HttpResponseMessage NoContent()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.NoContent, // 204
            };
        }

        [HttpGet]
        public HttpResponseMessage MovedPermanently()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.MovedPermanently, // 301
            };
        }

        [HttpGet]
        public HttpResponseMessage BadRequest()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.BadRequest, // 400
            };
        }

        [HttpGet]
        public HttpResponseMessage Unauthorized()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.Unauthorized, // 401
            };
        }

        [HttpGet]
        public HttpResponseMessage Forbidden()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.Forbidden, // 403
            };
        }

        [HttpGet]
        public HttpResponseMessage NotFound()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.NotFound, // 404
            };
        }

        [HttpGet]
        public HttpResponseMessage MethodNotAllowed()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.MethodNotAllowed, // 405
            };
        }

        [HttpGet]
        public HttpResponseMessage NotAcceptable()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.NotAcceptable, // 406
            };
        }

        [HttpGet]
        public HttpResponseMessage RequestTimeout()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.RequestTimeout, // 408
            };
        }

        [HttpGet]
        public HttpResponseMessage Conflict()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.Conflict, // 409
            };
        }

        [HttpGet]
        public HttpResponseMessage InternalServerError()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.InternalServerError, // 500
            };
        }

        [HttpGet]
        public HttpResponseMessage NotImplemented()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.NotImplemented, // 501
            };
        }
        [HttpGet]
        public HttpResponseMessage BadGateway()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("This is content"),
                StatusCode = HttpStatusCode.BadGateway, // 502
            };
        }
    }
}