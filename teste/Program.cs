using CosmoRequests;
using System;
using System.Net;
using System.Threading;

namespace teste
{
    class Program
    {
        private const string Url = "https://msedgedriver.azureedge.net/LATEST_STABLE";

        static void Main(string[] args)
        {

            for (var i = 0; i < 1; i++)
            {
                Thread tid1 = new Thread(new ThreadStart(Thread1));
                Thread tid2 = new Thread(new ThreadStart(Thread2));
                Thread tid3 = new Thread(new ThreadStart(Thread3));
                Thread tid4 = new Thread(new ThreadStart(Thread3));
                Thread tid5 = new Thread(new ThreadStart(Thread3));
                Thread tid6 = new Thread(new ThreadStart(Thread3));
                tid1.Start();
              //  tid2.Start();
                //  tid3.Start();
               //  tid4.Start();
               //  tid5.Start();

            }
            Console.Write(string.Format("Done"));
            Console.ReadKey();
        }

        static void Thread1()
        {
            for (int i = 1; i <= 1; i++)
            {
                CosmoRequests.CosmoRequest cosmo = new CosmoRequests.CosmoRequest();
                WebHeaderCollection webHeader = new WebHeaderCollection() { { "auth", "Trind" } };
                var response = cosmo.GET("https://msedgedriver.azureedge.net/LATEST_STABLE", headers: webHeader);
                Console.WriteLine($"{response} - ");
                Thread.Yield();
            }
        }

        static void Thread2()
        {
            for (int i = 1; i <= 10; i++)
            {
                CosmoRequests.CosmoRequest cosmo = new CosmoRequests.CosmoRequest();
                var response = cosmo.GET("http://localhost:3000/teste");
                Console.WriteLine(response.StatusCode);
                Thread.Yield();
            }
        }

        static void Thread3()
        {
            for (int i = 1; i <= 10; i++)
            {
                CosmoRequests.CosmoRequest cosmo = new CosmoRequests.CosmoRequest();
                var response = cosmo.GET("http://localhost:4001/teste");
                Console.WriteLine(response.Body);
                Thread.Yield();
            }
        }
    }
}
