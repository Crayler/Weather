using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.model
{
    public class Dictionary
    {
        Dictionary<String, String> icons;
        //天气图标
        public void getIcon()
        {
            icons = new Dictionary<string, string>();
            icons.Add("晴","qing.png");
            icons.Add("多云", "duoyun.png");
            icons.Add("阴", "yin.png");
            icons.Add("雨", "yu.png");
            icons.Add("雷阵雨", "leizhenyu.png");
        }
        public void getWeatherItem(Rootobject weather)
        {
            if (weather.now != null)
            {
                KeyValuePair<String, String> obj = icons.FirstOrDefault(x => x.Key.IndexOf(weather.now.text) >= 0 || weather.now.text.IndexOf(x.Key) >=0 );
                if (!obj.Equals(null))
                {
                    weather.now.icon = "icon\\" + obj.Value;
                }
                else
                {
                    weather.now.icon = null;
                }
                weather.now.text = "天气状况：" + weather.now.text;
                weather.now.temp = "现在温度：" + weather.now.temp;
            }
            if(weather.daily !=null)
            {
                foreach (Daily df in weather.daily)
                {
                    KeyValuePair<String, String> objdf = icons.FirstOrDefault(x => x.Key.IndexOf(df.textDay) >= 0 || df.textDay.IndexOf(x.Key) >= 0);
                    if (!objdf.Equals(null))
                    {
                        df.iconDay = "icon\\" + objdf.Value;
                    }
                    else
                    {
                        df.iconDay = null;
                    }
                    df.textDay = "天气状况：" + df.textDay;
                    df.tmp1 = "温度：" + df.tempMin + "-" + df.tempMax;
                }
            }
        }
    }
}
