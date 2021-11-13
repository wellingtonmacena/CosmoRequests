using CosmoRequests.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmoRequests.Helpers
{
    public class CosmoConverter<T>
    {
        static public List<T> GetJSON(CosmoResponse response)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(response.Body);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                return null;
            }         
        }
    }
}
