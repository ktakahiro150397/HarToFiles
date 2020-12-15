using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace HarToFiles.cls
{

    class DataDownloader
    {
        public static void DownloadFile(string url,string destFolder,string fileName)
        {
            using (var wc = new WebClient())
            {
                wc.DownloadFile(new Uri(url), Path.Combine(destFolder, fileName));
            }
        }
    }
}
