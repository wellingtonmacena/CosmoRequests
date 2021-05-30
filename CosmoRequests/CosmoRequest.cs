using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace CosmoRequests
{
    public class CosmoRequest
    {
        private WebRequest WebRequest;

        public void DownloadCurrent(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.Timeout = 3000;
            webRequest.BeginGetResponse(new AsyncCallback(PlayResponseAsync), webRequest);
        }

        private static void PlayResponseAsync(IAsyncResult asyncResult)
        {
            long total = 0;
            long received = 0;
            HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
                {
                    byte[] buffer = new byte[1024];

                    FileStream fileStream = File.OpenWrite("t.pdf");
                    using (Stream input = webResponse.GetResponseStream())
                    {
                        total = input.Length;

                        int size = input.Read(buffer, 0, buffer.Length);
                        while (size > 0)
                        {
                            fileStream.Write(buffer, 0, size);
                            received += size;

                            size = input.Read(buffer, 0, buffer.Length);
                        }
                    }

                    fileStream.Flush();
                    fileStream.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
        private void FillWebRequest(string url, string method, WebHeaderCollection headers = null, RequestOptions options = null)
        {
            if (options == null)
                options = new RequestOptions(3000);

            WebRequest = WebRequest.Create(url);
            WebRequest.Method = method;
            WebRequest.Timeout = options.Timeout;
            WebRequest.ContentType = options.ContentType;
            WebRequest.UseDefaultCredentials = options.UseDefaultCredentials;
            WebRequest.Timeout = options.Timeout;
            WebRequest.Headers = headers ?? new WebHeaderCollection();

        }

        private CosmoResponse SendWebRequest()
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)WebRequest.GetResponse();
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

        private void SerializeData(object data)
        {
            if (data != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(WebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data);
                    streamWriter.Write(json);
                }
            }
        }

        public CosmoResponse GET(string url, object data = null, RequestOptions options = null, WebHeaderCollection headers = null)
        {
            FillWebRequest(url, "GET", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse POST(string url, object data = null, RequestOptions options = null, WebHeaderCollection headers = null)
        {
            FillWebRequest(url, "POST", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PUT(string url, object data = null, RequestOptions options = null, WebHeaderCollection headers = null)
        {
            FillWebRequest(url, "PUT", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PATCH(string url, object data = null, RequestOptions options = null, WebHeaderCollection headers = null)
        {
            FillWebRequest(url, "PATCH", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse DELETE(string url, RequestOptions options = null, WebHeaderCollection headers = null)
        {
            FillWebRequest(url, "DELETE", headers, options);

            return SendWebRequest();
        }
    }
}