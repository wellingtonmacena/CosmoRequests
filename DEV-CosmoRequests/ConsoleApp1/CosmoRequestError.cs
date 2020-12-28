using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CosmoRequestError: Exception
    {
        public override string Message { get; }
        public HttpStatusCode StatusCode { get; }
        public WebResponse Request { get; }

        public CosmoRequestError(string message, WebResponse request, HttpStatusCode statusCode=HttpStatusCode.BadRequest)
        {
            this.Message = message;
            this.StatusCode = statusCode;
            this.Request = request;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Message: {this.Message};");
            sb.AppendLine($"StatusCode: {this.StatusCode};");
            sb.AppendLine($"Request: {this.Request};");

            return sb.ToString();
        }
    }
}
