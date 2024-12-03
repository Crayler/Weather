using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{
    public class WeatherItem
    {
        public string description { get; set; }
        public double highTemp { get; set; }
        public double lowTemp { get; set; }
        public override string ToString()
        {
            return description + "," + lowTemp.ToString() + "," + highTemp.ToString();
        }
    }
}
