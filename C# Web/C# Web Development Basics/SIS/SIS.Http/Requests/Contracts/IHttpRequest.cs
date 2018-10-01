using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SIS.Http.Enums;
using SIS.Http.Headers.Contracts;

namespace SIS.Http.Requests.Contracts
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpHeadersCollection HeadersCollection { get; }

    }
}
