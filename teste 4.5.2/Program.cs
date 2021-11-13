using CosmoRequests.Models;
using System;

namespace teste_4._5._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           // CosmoRequest cosmoRequest = new CosmoRequest();
            //var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");

            //var d =  cosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");

            CosmoRequest cosmoRequest = new CosmoRequest();
            var d = cosmoRequest.DOWNLOAD("https://orimi.com/pdf-test.pdf");

            Console.ReadKey();
        }
    }
}
