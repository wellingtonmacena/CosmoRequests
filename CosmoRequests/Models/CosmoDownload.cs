using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CosmoRequests.Models
{
    public class CosmoDownload
    {
        private WebClient WebClient { get; set; }

        public void AddHeader(string header, string value)
        {
            WebClient.Headers.Add(header, value);
        }

        public void AddHeaders(List<KeyValuePair<string, string>> webHeaderCollection)
        {
            foreach (var header in webHeaderCollection)
            {
                WebClient.Headers.Add(header.Key, header.Value);
            }
        }

        public void AddHeaders(WebHeaderCollection webHeaderCollection)
        {
            WebClient.Headers = webHeaderCollection;
        }

        public DownloadResponse Execute(string url, string downloadedFilePath)
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(url, downloadedFilePath);

                return new DownloadResponse(new FileInfo(downloadedFilePath), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}\nSource: {ex.Source}");
                return new DownloadResponse( null, false);
            }
        }

        public DownloadResponse Execute(string url, string folderDestination, string fileName)
        {
            try
            {
                string downloadedFilePath;

                if (Directory.Exists(folderDestination))
                    downloadedFilePath = folderDestination + $"\\{fileName}";
                else
                    downloadedFilePath = Directory.GetCurrentDirectory() + $"\\{fileName}";

                WebClient client = new WebClient();
                client.DownloadFile(url, downloadedFilePath);

                return new DownloadResponse(new FileInfo(downloadedFilePath), true);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}\nSource: {ex.Source}");
                return new DownloadResponse( null, false);
            }
        }
    }
}
