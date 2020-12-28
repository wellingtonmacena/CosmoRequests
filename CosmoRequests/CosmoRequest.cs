using System;
using System.Collections.Generic;
using System.Linq;
using Helper;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CosmoRequests
{
    public class CosmoRequest
    {
        WebRequest webRequest;

        public Response GET(string url)
        {
            this.webRequest = WebRequest.Create(url);
            this.webRequest.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            Response response1 = new Response(response, Helper<int>.GetString(response));

            return response1;
        }
    }
}


