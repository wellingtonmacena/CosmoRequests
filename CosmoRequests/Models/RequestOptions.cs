using System.Text;

namespace CosmoRequests.Models
{
    public class RequestOptions
    {
        public double Timeout { get; set; }
        public string ContentType { get; set; }
        public bool UseDefaultCredentials { get; set; }

        ///<summary>
        ///Value of timeout must be set in milliseconds. e.g 3000.
        ///</summary>
        public RequestOptions(double timeout, string contentType, bool useDefaultCredentials)
        {
            Timeout = timeout;
            ContentType = contentType;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public RequestOptions(string contentType)
        {
            ContentType = contentType;
        }

        public RequestOptions()
        {           
            Timeout = 3000;
            ContentType = "application/json";
            UseDefaultCredentials = true;
        }

        ///<summary>
        ///Value of timeout must be set in milliseconds. e.g 3000.
        ///</summary>
        public RequestOptions(double timeout)
        {
            Timeout = timeout;
            ContentType = "application/json";
            UseDefaultCredentials = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{{ Timeout: {Timeout}, ");
            sb.AppendLine($"ContentType: {ContentType}, ");
            sb.AppendLine($"UseDefaultCredentials: {UseDefaultCredentials}}} ");
            return base.ToString();
        }
    }
}
