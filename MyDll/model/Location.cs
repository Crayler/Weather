using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{

   

   
    public class Location
    {
        public string name { get; set; }
        public string id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string adm2 { get; set; }
        public string adm1 { get; set; }
        public string country { get; set; }
        public string tz { get; set; }
        public string utcOffset { get; set; }
        public string isDst { get; set; }
        public string type { get; set; }
        public string rank { get; set; }
        public string fxLink { get; set; }

        public override string ToString()
        {
            return id;
        }
    }

}
