using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{
    public class Now
    {
        public string obsTime { get; set; }
        public string temp { get; set; }
        public string feelsLike { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public string wind360 { get; set; }
        public string windDir { get; set; }
        public string windScale { get; set; }
        public string windSpeed { get; set; }
        public string humidity { get; set; }
        public string precip { get; set; }
        public string pressure { get; set; }
        public string vis { get; set; }
        public string cloud { get; set; }
        public string dew { get; set; }


        public override string ToString()
        {
            return "现在天气："+ text+"\t\n"+"温度"+temp+ "\t\n" + "体感温度" + feelsLike + "\t\n"+"相对湿度" + humidity ;
        }
    }



}
