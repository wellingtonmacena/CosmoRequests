using CosmoRequests.Models;
using System;

namespace teste_netCore3._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //CosmoRequest cosmoRequest = new CosmoRequest();
            ////var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");

            ////var d =  cosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");

            //var d = cosmoRequest.GET("http://colormind.io/list/");

            //Console.WriteLine(d.GetCompleteResponse());

            CosmoRequest cosmoRequest = new CosmoRequest();

            var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/1");
            //DownloadResponse downloadResponse = cosmoRequest.DOWNLOAD("https://orimi.com/pdf-test.pdf", @"C:\Users\wellm\Desktop\");
            Console.WriteLine(d);

            Console.ReadKey();
        }
    }
}
