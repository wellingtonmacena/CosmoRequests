using System.Text;

namespace CosmoRequests
{
    public class RequestOptions
    {

        /// <summary>
        /// Returns the sum of the specified numbers.
        /// </summary>
        /// <param name="Timeout">The first non-negative integer to be used in the sum.</param>
        /// <param name="ContentType">The second non-negative integer to be used in the sum.</param>
        /// <returns>A 32-bit positive integer, representing the sum of the two specified numbers.</returns>

        public double Timeout { get; set; }
        public string ContentType { get; set; }
        public bool UseDefaultCredentials { get; set; }

        ///<summary>
        ///Value of Timeout must be set in milliseconds. e.g 3000.
        ///</summary>
        public RequestOptions(double timeout, string contentType, bool useDefaultCredentials)
        {
            Timeout = timeout;
            ContentType = contentType;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public RequestOptions()
        {
            
            Timeout = 3000;
            ContentType = "application/json";
            UseDefaultCredentials = true;
        }

        ///<summary>
        ///Value of Timeout must be set in milliseconds. e.g 3000.
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
