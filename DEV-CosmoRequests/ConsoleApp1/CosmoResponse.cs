using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CosmoResponse
    {
        public string Body { get;  }
        public string ContentEncoding { get; }
        public string ContentType { get; }
        public long ContentLength { get; }
        public CookieCollection Cookies { get; }
        public bool IsError { get; }
        public string ErrorMessage { get; }
        public WebHeaderCollection Headers { get; }
        public DateTime LastModified { get; }
        public CosmoHTTPMethods Method { get; }
        public Version ProtocolVersion { get; }
        public HttpStatusCode StatusCode { get; }
        public string StatusDescription { get; }
        public string Server { get; }
        public bool SupportsHeaders { get; }

        public CosmoResponse(HttpWebResponse httpWebResponse)
        {
            this.Body = CosmoConverter<int>.GetString(httpWebResponse);
            this.StatusCode = httpWebResponse.StatusCode;
            this.Headers = httpWebResponse.Headers;
            this.ContentEncoding = httpWebResponse.ContentEncoding;
            this.ContentType = httpWebResponse.ContentType;
            this.ContentLength = httpWebResponse.ContentLength;
            this.Cookies = httpWebResponse.Cookies;
            this.LastModified = httpWebResponse.LastModified;
            this.ProtocolVersion = httpWebResponse.ProtocolVersion;
            this.Server = httpWebResponse.Server;
            this.StatusDescription = httpWebResponse.StatusDescription;
            this.SupportsHeaders = httpWebResponse.SupportsHeaders;

            switch (httpWebResponse.Method)
            {
                case "GET": this.Method = CosmoHTTPMethods.GET;
                    break;
                case "POST":
                    this.Method = CosmoHTTPMethods.POST;
                    break;
                case "PUT":
                    this.Method = CosmoHTTPMethods.PUT;
                    break;
                case "DELETE":
                    this.Method = CosmoHTTPMethods.DELETE;
                    break;
                case "PATCH":
                    this.Method = CosmoHTTPMethods.PATCH;
                    break;
                default:
                    throw new Exception("Method not supported by this version of CosmoRequests");
            }
        }

        public CosmoResponse(string message) {
            this.IsError = true;
            this.ErrorMessage = message;
            this.StatusDescription = message.Split(':')[1].Substring(2, 3);

            this.StatusCode = (HttpStatusCode) Enum.Parse(typeof(HttpStatusCode), this.StatusDescription);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Body: {this.Body};");
            sb.AppendLine($"ContentEncoding: {this.ContentEncoding};");
            sb.AppendLine($"ContentType: {this.ContentType};");
            sb.AppendLine($"ContentLength: {this.ContentLength};");
            sb.AppendLine($"Cookies: {this.Cookies};");
            sb.AppendLine($"Headers: {this.Headers};");
            sb.AppendLine($"IsError: {this.IsError};");
            sb.AppendLine($"ErrorMessage: {this.ErrorMessage};");
            sb.AppendLine($"LastModified: {this.LastModified};");
            sb.AppendLine($"Method: {this.Method};");
            sb.AppendLine($"ProtocolVersion: {this.ProtocolVersion};");
            sb.AppendLine($"StatusCode: {this.StatusCode};");
            sb.AppendLine($"StatusDescription: {this.StatusDescription};");
            sb.AppendLine($"Server: {this.Server};");
            sb.AppendLine($"SupportsHeaders: {this.SupportsHeaders};");

            return sb.ToString();
        }
    }
}
