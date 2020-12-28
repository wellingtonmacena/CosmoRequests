using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CosmoRequests
{
    public class Response
    {
        private HttpWebResponse HttpWebResponse;
        private object BodyResponse;

        public Response(HttpWebResponse httpWebResponse, object bodyResponse)
        {
            this.BodyResponse = bodyResponse;
            this.HttpWebResponse = httpWebResponse;
        }
    }
}
