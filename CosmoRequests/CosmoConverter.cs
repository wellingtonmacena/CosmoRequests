using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmoRequests
{
    public class CosmoConverter<T>
    {
        static public List<T> GetJSON(CosmoResponse response)
        {
            return JsonConvert.DeserializeObject<List<T>>(response.Body);
        }
    }
}
