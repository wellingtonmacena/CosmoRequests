using CosmoRequests.Models;
using System;

namespace teste_4._5._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           // CosmoRequest cosmoRequest = new CosmoRequest();
            var d = CosmoRequest.GET("https://rickandmortyapi.com/api/character/12");

            //var d =  cosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");

            //var d = CosmoRequest.DOWNLOAD("https://orimi.com/pdf-test.pdf");
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
