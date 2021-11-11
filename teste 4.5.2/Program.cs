using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmoRequests;

namespace teste_4._5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            CosmoRequest cosmoRequest = new CosmoRequest();
            //var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");
          
           //var d =  cosmoRequest.DOWNLOAD("https://chromedriver.storage.googleapis.com/92.0.4515.43/chromedriver_win32.zip");
        
            var d = cosmoRequest.DOWNLOAD("http://localhost:8080/pag2.xlsx");


            Console.ReadKey();
        }
    }
}
