using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{
    public class Weather
    {
        public string city { get; set; }
        public string date { get; set; }
        public WeatherItem weather { get; set; }
        public override string ToString()
        {
            return city + "," + date + "," + weather.ToString();
        }

    }
}
