using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace CosmoRequests
{
    public class CosmoRequest
    {
        WebRequest webRequest;

        private void FillWebRequest(string url, string method, WebHeaderCollection headers = null, string contentType = null)
        {
            this.webRequest = WebRequest.Create(url);
            this.webRequest.Method = method;
            this.webRequest.Headers = headers == null ? new WebHeaderCollection() : headers;
            this.webRequest.ContentType = contentType == null ? "application/json" : contentType;
        }

        private CosmoResponse HandleResponseRequest()
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                return new CosmoResponse(response);
            }
            catch (WebException webE)
            {
                return new CosmoResponse(webE.Message, webE);
            }
            catch (Exception e)
            {
                return new CosmoResponse(e);
            }
        }

        private void SeriliazeData(object data)
        {
            if (data != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(this.webRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data);
                    streamWriter.Write(json);
                }
            }
        }

        public CosmoResponse GET(string url, WebHeaderCollection headers = null, string contentType = null)
        {
            this.FillWebRequest(url, "GET", headers, contentType);

            return this.HandleResponseRequest();
        }

        public CosmoResponse POST(string url, object data = null, WebHeaderCollection headers = null, string contentType = null)
        {
            this.FillWebRequest(url, "POST", headers, contentType);
            this.SeriliazeData(data);

            return this.HandleResponseRequest();
        }

        public CosmoResponse PUT(string url, object data = null, WebHeaderCollection headers = null, string contentType = null)
        {
            this.FillWebRequest(url, "PUT", headers, contentType);
            this.SeriliazeData(data);

            return this.HandleResponseRequest();
        }

        public CosmoResponse PATCH(string url, object data = null, WebHeaderCollection headers = null, string contentType = null)
        {
            this.FillWebRequest(url, "PATCH", headers, contentType);
            this.SeriliazeData(data);

            return this.HandleResponseRequest();
        }

        public CosmoResponse DELETE(string url, WebHeaderCollection headers = null, string contentType = null)
        {
            this.FillWebRequest(url, "DELETE", headers, contentType);

            return this.HandleResponseRequest();
        }
    }
}