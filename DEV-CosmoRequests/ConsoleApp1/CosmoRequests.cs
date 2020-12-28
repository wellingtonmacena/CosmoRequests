using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CosmoRequests
    {
        WebRequest webRequest;

        public CosmoResponse GET(string url, WebHeaderCollection headers = null)
        {
            this.webRequest = WebRequest.Create(url);
            this.webRequest.Method = "GET";
            this.webRequest.Headers = headers == null ? new WebHeaderCollection(): headers;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            return new CosmoResponse(response);
        }

        public CosmoResponse POST(string url, object data = null, WebHeaderCollection headers = null, string contentType = null)
        {
            this.webRequest = WebRequest.Create(url);
            this.webRequest.Method = "POST";
            this.webRequest.Headers = headers == null ? new WebHeaderCollection() : headers;
            this.webRequest.ContentType = contentType == null ? "application/json": contentType;

            if(data != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(this.webRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data);
                    streamWriter.Write(json);
                }
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                return new CosmoResponse(response);
            }
            catch(Exception e)
            {
                return new CosmoResponse(e.Message);
            }
              
        }
    }
}
