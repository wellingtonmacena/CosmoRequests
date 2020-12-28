using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CosmoConverter<T>
    {
        static public string GetString(HttpWebResponse response)
        {
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);
            return stream.ReadToEnd();
        }

        static public List<T> GetJSON(CosmoResponse response)
        {
            return JsonConvert.DeserializeObject<List<T>>(response.Body);
        }
    }
}
