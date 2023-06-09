using CosmoRequests.Models;
using System;

namespace teste_netCore3._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////var d = CosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");

            var d =  CosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");

            //var d = CosmoRequest.GET("http://colormind.io/list/");

            //Console.WriteLine(d.GetCompleteResponse());


            var d3 = CosmoRequest.GET("https://rickandmortyapi.com/api/character/1");
            //DownloadResponse downloadResponse = cosmoRequest.DOWNLOAD("https://orimi.com/pdf-test.pdf", @"C:\Users\wellm\Desktop\");
            Console.WriteLine(d);

            Console.ReadKey();
        }
    }
}
