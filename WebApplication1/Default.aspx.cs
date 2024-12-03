using MyDll.model;
using MyDll.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        MyDll.model.Zone zone;
        Dictionary dy;
        public void Page_Load(object sender,EventArgs s)
        {
            
            //zone = new MyDll.model.Zone
            //{
            //    provinces = new List<Province>
            //    {
            //        new Province{province = "直辖市", cities = new List<String>{"北京","上海","天津","重庆"}},
            //        new Province{province = "广东", cities = new List<String>{"广州","深圳","珠海","惠州"}},
            //        new Province{province = "湖北", cities = new List<String>{"武汉","宜昌","黄石","荆州","荆门","十堰"}},
            //        new Province{province = "四川", cities = new List<String>{"成都","稻城","汶川","雅安","色达"}},
            //    }
            //};
            dy = new Dictionary();
            try
            {
                dy.getIcon();
                /*cbProvince.DataSource = new List<string> { "直辖市", "广东", "湖北", "四川" };
                cbProvince.DataBind();*/
            }
            catch (Exception exp)
            {
                tbZone.Text = exp.Message;
            }
        }




        protected void cbProvince_SelectionChanged(object sender, EventArgs e)
        {
            string selectedValue =cbProvince.SelectedValue;
            List<string> countries;
            switch (selectedValue) {
                case "直辖市":
                    countries = new List<string> { "请选择", "北京", "上海", "天津", "重庆" };
                    break;
                case "广东":
                    countries = new List<string> { "请选择", "广州", "深圳", "珠海", "惠州" };
                    break;
                case "湖北":
                    countries = new List<string> { "请选择","武汉", "宜昌", "黄石", "荆州", "荆门", "十堰" };
                    break;
                case "四川":
                    countries = new List<string> { "请选择", "成都", "稻城", "汶川", "雅安", "色达" };
                    break;
                default:
                    countries = new List<string> {  };
                    break;

            }
            lsCities.DataSource = countries;
            lsCities.DataBind();
        }
        protected void lsCities_SelectionChanged(object sender, EventArgs e)
        {
            //选择城市
            if (lsCities.SelectedIndex >= 0)
            {
                try
                {
                    String city = lsCities.SelectedItem.ToString();
                    clientGzip("https://geoapi.qweather.com/v2/city/", "lookup", city, Properties.Resource.crayler);
                }
                catch (Exception exp)
                {
                    tbZone.Text = exp.Message;
                }
            }
        }
        public void clientGzip(String url, String u, String city, String key)
        {
            GZipWebClient client = new GZipWebClient();
            client.Encoding = Encoding.GetEncoding("GB2312");
            client.DownloadDataCompleted += Client_DownloadDataCompleted;
            Uri uri = new Uri(url + u + "?location=" + city + "&key=" + Properties.Resource.crayler);
            client.DownloadDataAsync(uri, city);
            tbZone.Text = "等待服务器响应...";
        }
        public void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    String s = Encoding.UTF8.GetString(e.Result);
                    Rootobject rootobject = JsonUtil.deserialize<Rootobject>(s);
                    dy.getWeatherItem(rootobject);
                    if (s.Contains("now"))
                    {
                        //绑定now数据实时天气
                        nowText.Text = rootobject.now.text;
                        nowTemp.Text = rootobject.now.temp;
                        nowIcon.ImageUrl = rootobject.now.icon;  
                    }
                    if (s.Contains("daily"))
                    {
                        for (int i = 0; i < rootobject.daily.Length; i++) {
                            if (i == 0)
                            {
                                firstDate.Text = rootobject.daily[i].fxDate;
                                firstDayText.Text = rootobject.daily[i].textDay;
                                firstDayTemp.Text = rootobject.daily[i].tmp1;
                                firstDayIcon.ImageUrl = rootobject.daily[i].iconDay;
                            }
                            else if (i == 1)
                            {
                                secondDate.Text = rootobject.daily[i].fxDate;
                                secondDayText.Text = rootobject.daily[i].textDay;
                                secondDayTemp.Text = rootobject.daily[i].tmp1;
                                secondDayIcon.ImageUrl = rootobject.daily[i].iconDay;
                            }
                            else if (i == 2) {
                                thirdDate.Text = rootobject.daily[i].fxDate;
                                thirdDayText.Text = rootobject.daily[i].textDay;
                                thirdDayTemp.Text = rootobject.daily[i].tmp1;
                                thirdDayIcon.ImageUrl = rootobject.daily[i].iconDay;
                            }
                        }
                    }
                    if (s.Contains("location"))
                    {
                        String cityId = rootobject.getLocationId();
                        if (cityId != null)
                        {
                            String url = "https://devapi.qweather.com/v7/weather/";
                            clientGzip(url, "now", cityId, Properties.Resource.crayler);
                            clientGzip(url, "3d", cityId, Properties.Resource.crayler);
                            //cbCity.IsEnabled = true;
                        }

                    }
                    cbProvince.Enabled = true;
                    lsCities.Enabled = true;
                    tbZone.Text = "foreast";
                }
                else
                {
                    tbZone.Text=e.Error.Message;
                }
            }
            catch (Exception exp)
            {
              tbZone.Text=exp.Message;
            }
        }
        String url = "https://devapi.qweather.com/v7/weather/";
    }
}
