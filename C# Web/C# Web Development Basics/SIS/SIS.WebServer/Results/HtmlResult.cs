namespace SIS.WebServer.Results
{
    using System.Text;
    using HTTP.Enums;
    using Http.Headers;
    using Http.Response;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}