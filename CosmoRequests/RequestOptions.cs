using System.Text;

namespace CosmoRequests
{
    public class RequestOptions
    {
        public int Timeout { get; set; }
        public string ContentType { get; set; }
        public bool UseDefaultCredentials { get; set; }

        public RequestOptions(int timeout, string contentType, bool useDefaultCredentials)
        {
            Timeout = timeout;
            ContentType = contentType;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public RequestOptions(int timeout)
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
