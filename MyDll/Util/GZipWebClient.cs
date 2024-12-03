using MyDll.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.Util
{
    public class GZipWebClient :WebClient 
     {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest webrequest =(HttpWebRequest)WebRequest.Create(address);
            webrequest.AutomaticDecompression = DecompressionMethods.GZip|DecompressionMethods.Deflate;
            return webrequest;
        }
    }

}
