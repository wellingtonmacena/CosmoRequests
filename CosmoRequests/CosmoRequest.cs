using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace CosmoRequests
{
    public class CosmoRequest
    {
        private WebRequest WebRequest;

        public FileInfo DOWNLOAD(string url)
        {
            try
            {
                CosmoResponse d = GET(url);
                if (d.IsSuccessful)
                {
                    string contentType = d.ContentType.Split('/')[1];

                    string dw = DateTime.Now.ToString("fffff");
                    string downloadedFilePath = Directory.GetCurrentDirectory() + $"\\downloadedFile{dw}.{contentType}";
                    WebClient client = new WebClient();


                    client.DownloadFile(url, downloadedFilePath);
                    Console.WriteLine();

                    return new FileInfo(downloadedFilePath);
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }




        private void FillWebRequest(string url, string method, WebHeaderCollection headers = null, RequestOptions options = null)
        {
            if (options == null)
                options = new RequestOptions(3000);

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            WebRequest = WebRequest.Create(url);
            WebRequest.Method = method;
            WebRequest.ContentType = options.ContentType;
            WebRequest.UseDefaultCredentials = options.UseDefaultCredentials;
            WebRequest.Timeout = (int)Math.Round(options.Timeout);
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

        public CosmoResponse GET(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "GET", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse GET(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "GET", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse GET(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "GET", new WebHeaderCollection(), options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse GET(string url, object data)
        {
            FillWebRequest(url, "GET", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse GET(string url)
        {
            FillWebRequest(url, "GET", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }



        public CosmoResponse POST(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "POST", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse POST(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "POST", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse POST(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse POST(string url, object data)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse POST(string url)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }



        public CosmoResponse PUT(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PUT", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PUT(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PUT", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PUT(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PUT(string url, object data)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PUT(string url)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }



        public CosmoResponse PATCH(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PATCH", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PATCH(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PATCH", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PATCH(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PATCH(string url, object data)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse PATCH(string url)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }


        public CosmoResponse DELETE(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "DELETE", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse DELETE(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "DELETE", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse DELETE(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse DELETE(string url, object data)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public CosmoResponse DELETE(string url)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }
    }
}