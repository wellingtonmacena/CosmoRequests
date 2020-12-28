using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Helper<T>
    {
        static public string GetString(HttpWebResponse response)
        {
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);
            return stream.ReadToEnd();
        }

        static public T GetJSON(HttpWebResponse response)
        {
            string serializedObject = GetString(response);
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }
    }
}
