using SIS.HTTP.Enums;

namespace SIS.WebServer.Results
{
    using Http.Enums;
    using Http.Headers;
    using Http.Response;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}