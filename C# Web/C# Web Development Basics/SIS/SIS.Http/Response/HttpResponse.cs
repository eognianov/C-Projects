using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.Http.Common;
using SIS.Http.Extensions;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Response.Contracts;
using SIS.HTTP.Enums;

namespace SIS.Http.Response
{
    public class HttpResponse:IHttpResponse
    {
        public HttpResponse()
        {
            
        }
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeadersCollectio();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeadersCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine(this.Headers.ToString())
                .AppendLine();

            return sb.ToString();
        }
    }
}
