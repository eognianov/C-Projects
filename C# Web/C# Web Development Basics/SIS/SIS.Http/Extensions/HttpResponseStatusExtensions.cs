using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using SIS.HTTP.Enums;

namespace SIS.Http.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
            => $"{(int) statusCode} {statusCode}";
    }
}
