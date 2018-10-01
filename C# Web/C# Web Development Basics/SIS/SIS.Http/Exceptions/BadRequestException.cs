using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SIS.Http.Exceptions
{
    public class BadRequestException:Exception
    {
        private const string errorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public BadRequestException():base(errorMessage)
        {
            
        }
    }
}
