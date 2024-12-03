using MyDll;
using MyDll.model;
using MyDll.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server
{
    /// <summary>
    /// Server 的摘要说明
    /// </summary>
    public class Server : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Weather weather = new Weather
            {
                city = "武汉",
                date = "2024-09-08",
                weather = new WeatherItem
                {
                    description = "多云<晴天>",
                    lowTemp = 26.3,
                    highTemp = 38.2
                }
            };
            string s = JsonUtil.serialize<Weather>(weather);
            context.Response.Write(s);
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}