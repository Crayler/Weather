using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{

    public class Rootobject
    {
        public string code { get; set; }
        public string updateTime { get; set; }
        public string fxLink { get; set; }
        public Now now { get; set; }
        public Daily[] daily { get; set; }

        public Refer refer { get; set; }
        public Location[] location { get; set; }


        public override string ToString()
        {
            string str = "";
            foreach (var d in daily)
            {
                str += d.ToString();
            }
            return str;
        }
        public string getLocationId()
        {
            return location[0].ToString();
        }
    }

}
