using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CosmoRequests.Models
{
    public class DownloadResponse
    {

        public FileInfo FileInfo { get; set; }
        public bool IsDownloadSucessful { get; set; }

        ///<summary>
        ///An object with a FileInfo of downloaded file if it was completed sucessfully.
        ///</summary>
        public DownloadResponse(FileInfo fileInfo, bool isDownloadSucessful)
        {
            FileInfo = fileInfo;
            IsDownloadSucessful = isDownloadSucessful;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{{FileInfo: {this.FileInfo}, ");
            sb.AppendLine($"IsDownloadSucessful: {this.IsDownloadSucessful}}}");

            return sb.ToString();
        }
    }
}
