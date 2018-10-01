using System;
using System.Collections.Generic;
using System.Text;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.HTTP.Enums;

namespace SIS.Http.Response.Contracts
{
    public interface IHttpResponse
    {
         HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeadersCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}
