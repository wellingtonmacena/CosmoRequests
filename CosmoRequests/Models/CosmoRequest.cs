
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace CosmoRequests.Models
{
    public static class CosmoRequest
    {
        private static WebRequest webRequest;

        public static DownloadResponse DOWNLOAD(string url)
        {
            try
            {
                CosmoResponse response = GET(url);
                if (response.IsSuccessful)
                {
                    string contentType = response.ContentType.Split('/')[1];

                    string dateTime = DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss-fff");
                    string downloadedFilePath = Directory.GetCurrentDirectory() + $"\\File-{dateTime}.{contentType}";
                    WebClient client = new WebClient();

                    client.DownloadFile(url, downloadedFilePath);
                    Console.WriteLine();

                    return new DownloadResponse(new FileInfo(downloadedFilePath), true);
                }

                return new DownloadResponse(null, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}\nSource: {ex.Source}");
                return new DownloadResponse(null, false);
            }
        }

        public static DownloadResponse DOWNLOAD(string url, string folderDestination)
        {
            try
            {
                CosmoResponse response = GET(url);
                if (response.IsSuccessful)
                {
                    string contentType = response.ContentType.Split('/')[1];
                    string dateTime = DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss-fff");
                    string downloadedFilePath;

                    if (Directory.Exists(folderDestination))
                        downloadedFilePath = folderDestination + $"\\File-{dateTime}.{contentType}";
                    else
                        downloadedFilePath = Directory.GetCurrentDirectory() + $"\\downloadedFile{dateTime}.{contentType}";

                    WebClient client = new WebClient();

                    client.DownloadFile(url, downloadedFilePath);

                    return new DownloadResponse(new FileInfo(downloadedFilePath), true);
                }

                return new DownloadResponse(null, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}\nSource: {ex.Source}");
                return new DownloadResponse(null, false);
            }
        }

        private static void FillWebRequest(string url, string method, WebHeaderCollection headers = null, RequestOptions options = null)
        {
            if (options == null)
                options = new RequestOptions(3000);

            if (headers == null)
                headers = new WebHeaderCollection();

            if (!headers.AllKeys.ToList().Contains("ContentType"))
                headers.Add("ContentType", options.ContentType);

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}\nSource: {ex.Source}");
            }

            webRequest = WebRequest.Create(url);
            webRequest.Method = method;
            webRequest.ContentType = options.ContentType;
            webRequest.UseDefaultCredentials = options.UseDefaultCredentials;
            webRequest.Timeout = (int)Math.Round(options.Timeout);
            webRequest.Headers = headers;
            webRequest.Proxy = options.WebProxy;
        }

        private static CosmoResponse SendWebRequest()
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

        private static void SerializeData(object data)
        {
            if (data != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    streamWriter.Write(json);
                }
            }
        }

        public static CosmoResponse GET(string url, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "GET", headers, options);

            return SendWebRequest();
        }

        public static CosmoResponse GET(string url, WebHeaderCollection headers)
        {
            FillWebRequest(url, "GET", headers, new RequestOptions());

            return SendWebRequest();
        }

        public static CosmoResponse GET(string url, RequestOptions options)
        {
            FillWebRequest(url, "GET", new WebHeaderCollection(), options);

            return SendWebRequest();
        }

        public static CosmoResponse GET(string url)
        {
            FillWebRequest(url, "GET", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }


        public static CosmoResponse POST(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "POST", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse POST(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "POST", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse POST(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), options);
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse POST(string url, object data)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse POST(string url)
        {
            FillWebRequest(url, "POST", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }



        public static CosmoResponse PUT(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PUT", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PUT(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PUT", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PUT(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PUT(string url, object data)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PUT(string url)
        {
            FillWebRequest(url, "PUT", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }

        public static CosmoResponse PATCH(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PATCH", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PATCH(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "PATCH", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PATCH(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PATCH(string url, object data)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse PATCH(string url)
        {
            FillWebRequest(url, "PATCH", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }

        public static CosmoResponse DELETE(string url, object data, RequestOptions options, WebHeaderCollection headers)
        {
            FillWebRequest(url, "DELETE", headers, options);
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse DELETE(string url, object data, WebHeaderCollection headers)
        {
            FillWebRequest(url, "DELETE", headers, new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse DELETE(string url, object data, RequestOptions options)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse DELETE(string url, object data)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());
            SerializeData(data);

            return SendWebRequest();
        }

        public static CosmoResponse DELETE(string url)
        {
            FillWebRequest(url, "DELETE", new WebHeaderCollection(), new RequestOptions());

            return SendWebRequest();
        }
    }
}