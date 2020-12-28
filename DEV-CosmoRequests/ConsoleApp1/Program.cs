using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GET
            CosmoRequests cosmoRequests = new CosmoRequests();
            var response = cosmoRequests.GET("http://localhost:4001/players");
            //List<Player> players = CosmoConverter<Player>.GetJSON(response);

            // foreach(var item in players)
            //    Console.WriteLine(item.age);


            //POST

            WebHeaderCollection headers = new WebHeaderCollection();
            headers.Add("City", "SAO PAULO");

            response = cosmoRequests.POST("http://localhost:4001/players", new Player("bete", 40, "Belinense"), headers);
            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
