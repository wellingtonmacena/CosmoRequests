using CosmoRequests;
using System;

namespace teste_netCore3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CosmoRequest cosmoRequest = new CosmoRequest();
            //var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");

            //var d =  cosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");

            var d = cosmoRequest.GET("http://colormind.io/list/");

            Console.WriteLine(d.GetCompleteResponse());
            Console.ReadKey();
        }
    }
}
