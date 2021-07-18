using System;
using System.Collections.Generic;
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
            var d = cosmoRequest.GET("https://rickandmortyapi.com/api/character/13ede");
          
            Console.WriteLine(d.GetCompleteResponse());
            Console.ReadKey();
        }
    }
}
