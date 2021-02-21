using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentProcessor.API.Helpers
{
        public class CustomHttpResponse
        {
            public bool IsSuccess { get { return Code == HttpStatusCode.OK; } }
            public HttpStatusCode Code { get; set; }
            public string Message { get; set; }
        }

        public class ResponseObject
        {
            public ResponseCodes Code { get; set; }
            public string Message { get; set; }
        }


        public enum ResponseCodes
        {
            Ok = 200,
            InvalidRequest = 400,
            InternalServerError = 500
        }
}
