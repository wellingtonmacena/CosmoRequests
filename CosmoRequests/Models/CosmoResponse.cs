using CosmoRequests.Models.Enums;
using System;
using System.IO;
using System.Net;
using System.Text;


namespace CosmoRequests.Models
{
    public class CosmoResponse
    {
        public string Body { get; private set; }
        public string ContentEncoding { get; private set; }
        public string ContentType { get; private set; }
        public long? ContentLength { get; private set; }
        public CookieCollection Cookies { get; private set; }
        public bool IsSuccessful { get; private set; }
        public string ErrorMessage { get; private set; }
        public WebHeaderCollection Headers { get; private set; }
        public DateTime LastModified { get; private set; }
        public CosmoHTTPMethods? Method { get; private set; }
        public Version ProtocolVersion { get; private set; }
        public Uri ResponseUri { get; private set; }
        public int? StatusCode { get; private set; }
        public string StatusDescription { get; private set; }
        public string Server { get; private set; }
        public bool? SupportsHeaders { get; private set; }

        public CosmoResponse(HttpWebResponse httpWebResponse)
        {
            this.Body = this.ConvertToString(httpWebResponse);        
            this.Headers = httpWebResponse.Headers;
            this.ContentEncoding = httpWebResponse.ContentEncoding;
            this.ContentType = httpWebResponse.ContentType;
            this.ContentLength = httpWebResponse.ContentLength;
            this.Cookies = httpWebResponse.Cookies;
            this.IsSuccessful = true;
            this.LastModified = httpWebResponse.LastModified;
            this.ResponseUri = httpWebResponse.ResponseUri;
            this.ProtocolVersion = httpWebResponse.ProtocolVersion;
            this.Server = httpWebResponse.Server;
            this.StatusDescription = httpWebResponse.StatusDescription;
            HttpStatusCode httpStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), this.StatusDescription);
            this.StatusCode = ((int)httpStatusCode);
            this.SupportsHeaders = httpWebResponse.SupportsHeaders;

            switch (httpWebResponse.Method)
            {
                case "GET":
                    this.Method = CosmoHTTPMethods.GET;
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

        public CosmoResponse(string message, WebException webException)
        {

            this.ClearAttributes();
            this.ErrorMessage = message;
            if (webException.Response != null)
            {
                this.ContentLength = webException.Response.ContentLength;
                this.ContentType = webException.Response.ContentType;
                this.Headers = webException.Response.Headers;
                this.IsSuccessful = false;
                this.ResponseUri = webException.Response.ResponseUri;
                this.StatusDescription = message.Split(':')[1].Substring(2, 3);
                HttpStatusCode httpStatusCode = ((HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), this.StatusDescription));
                this.StatusCode = ((int)httpStatusCode);
                this.StatusDescription = Enum.Parse(typeof(HttpStatusCode), this.StatusDescription).ToString();
                this.SupportsHeaders = webException.Response.SupportsHeaders;
            }
        }

        public CosmoResponse(Exception e)
        {
            this.ClearAttributes();

            this.ErrorMessage = e.Message;
            this.IsSuccessful = false;
            try
            {
                this.StatusDescription = e.Message.Split(':')[1].Substring(2, 3);
                HttpStatusCode httpStatusCode = ((HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), this.StatusDescription));
                this.StatusCode = ((int)httpStatusCode);
                this.StatusDescription = Enum.Parse(typeof(HttpStatusCode), this.StatusDescription).ToString();
            }
            catch
            { }
        }

        private void ClearAttributes()
        {
            this.Body = null;
            this.StatusCode = null;
            this.Headers = null;
            this.ContentEncoding = null;
            this.ContentType = null;
            this.ContentLength = null;
            this.Cookies = null;
            this.LastModified = new DateTime();
            this.ResponseUri = null;
            this.Method = null;
            this.ProtocolVersion = null;
            this.Server = null;
            this.StatusDescription = null;
            this.SupportsHeaders = null;
        }

        private string ConvertToString(HttpWebResponse response)
        {
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);
            return stream.ReadToEnd();
        }

        public override string ToString()
        {
            return this.Body;
        }

        public string GetResponse()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Body: {this.Body},");
            sb.AppendLine($"ContentType: {this.ContentType},");
            sb.AppendLine($"ContentLength: {this.ContentLength},");
            sb.AppendLine($"Cookies: {this.Cookies},");
            sb.AppendLine($"Headers: {this.Headers},");
            sb.AppendLine($"IsSuccessful: {this.IsSuccessful},");
            sb.AppendLine($"Method: {this.Method},");
            sb.AppendLine($"ResponseUri: {this.ResponseUri},");
            sb.AppendLine($"StatusCode: {this.StatusCode},");
            sb.AppendLine($"StatusDescription: {this.StatusDescription},");
            sb.AppendLine($"SupportsHeaders: {this.SupportsHeaders},");

            return sb.ToString();
        }

        public string GetCompleteResponse()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Body: {this.Body},");
            sb.AppendLine($"ContentEncoding: {this.ContentEncoding},");
            sb.AppendLine($"ContentType: {this.ContentType},");
            sb.AppendLine($"ContentLength: {this.ContentLength},");
            sb.AppendLine($"Cookies: {this.Cookies},");
            sb.AppendLine($"Headers: {this.Headers},");
            sb.AppendLine($"IsSuccessful: {this.IsSuccessful},");
            sb.AppendLine($"ErrorMessage: {this.ErrorMessage},");
            sb.AppendLine($"LastModified: {this.LastModified},");
            sb.AppendLine($"Method: {this.Method},");
            sb.AppendLine($"ProtocolVersion: {this.ProtocolVersion},");
            sb.AppendLine($"ResponseUri: {this.ResponseUri},");
            sb.AppendLine($"StatusCode: {this.StatusCode},");
            sb.AppendLine($"StatusDescription: {this.StatusDescription},");
            sb.AppendLine($"Server: {this.Server},");
            sb.AppendLine($"SupportsHeaders: {this.SupportsHeaders},");

            return sb.ToString();
        }
    }
}
