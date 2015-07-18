using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace MangoDbEnterprise.API.Helper
{
    public static class ControllerExtension
    {
        public static ApiResult<T> CreateResponse<T>(this ApiController controller, T content, string message = null, ServiceStatus statusCode = ServiceStatus.Success)
        {

            return new ApiResult<T>(ConvertStatusCode(statusCode), content, controller, message);
        }

        private static HttpStatusCode ConvertStatusCode(ServiceStatus statusCode)
        {
            switch (statusCode)
            {
                case ServiceStatus.Success:
                    return HttpStatusCode.OK;
                case ServiceStatus.RequestNotValid:
                    return HttpStatusCode.BadRequest;
                case ServiceStatus.Exception:
                    return HttpStatusCode.InternalServerError;
                default:
                    throw new ArgumentOutOfRangeException(ApiConstants.StatusCode);
            }
        }
    }

    public class ApiResult<T> : NegotiatedContentResult<T>
    {
        private readonly string _message;

        public ApiResult(HttpStatusCode statusCode, T content, ApiController controller, string message)
            : base(statusCode, content, controller)
        {
            _message = message;
        }

        public ApiResult(HttpStatusCode statusCode, T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            : base(statusCode, content, contentNegotiator, request, formatters) { }

        public string Message
        {
            get { return _message; }
        }


        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var strt = DateTime.Now;
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);
            var end = DateTime.Now - strt;
            response.ReasonPhrase = Message;
            response.Headers.Add(ApiConstants.ReturnedBy, ApiConstants.AppName);
            response.Headers.Add(ApiConstants.ProcessedIn, end.ToString());

            //var protectedPropertyListKey = HttpContextItem.ProtectedPropertyList.GetEnumDescription();
            //if (HttpContext.Current.Items.Contains(protectedPropertyListKey))
            //{
            //    response.Headers.Add(protectedPropertyListKey, HttpContext.Current.Items[protectedPropertyListKey].ToString());
            //}

            return response;
        }
    }
}