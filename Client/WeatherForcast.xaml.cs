using MyDll.model;
using MyDll.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    /// <summary>
    /// WeatherForcast.xaml 的交互逻辑
    /// </summary>
    public partial class WeatherForcast : Window
    {
        Zone zone;
        Dictionary dy = new Dictionary();
        public WeatherForcast()
        {
            InitializeComponent();
            zone = new Zone
            {
                provinces = new List<Province>
                {
                    new Province{province = "直辖市", cities = new List<String>{"北京","上海","天津","重庆"}},
                    new Province{province = "广东", cities = new List<String>{"广州","深圳","珠海","惠州"}},
                    new Province{province = "湖北", cities = new List<String>{"武汉","宜昌","黄石","荆州","荆门","十堰"}},
                    new Province{province = "四川", cities = new List<String>{"成都","稻城","汶川","雅安","色达"}},
                }
            };
            try
            {
                dy.getIcon();
                cbProvince.ItemsSource = zone.provinces.Select(x => x.province);
            }
            catch(Exception exp)
            {
                tbZone.Text = exp.Message;
            }
        }


        

        private void cbProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProvince.SelectedIndex >= 0)
            {
                lsCities.ItemsSource = null;
                lsCities.ItemsSource = zone.provinces[cbProvince.SelectedIndex].cities;
            }
        }

        private void lsCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //选择城市
            if (lsCities.SelectedIndex >= 0)
            {
                try
                {
                    String city = lsCities.SelectedItem.ToString();
                    clientGzip("https://geoapi.qweather.com/v2/city/", "lookup", city, Properties.Resources.crayler);
                }
                catch(Exception exp)
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
            Uri uri = new Uri(url + u + "?location=" + city + "&key=" + Properties.Resources.crayler);
            client.DownloadDataAsync(uri, city);
            tbZone.Text = "等待服务器响应...";
        }

        public void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                String s = Encoding.UTF8.GetString(e.Result);
                Rootobject weather = JsonUtil.deserialize<Rootobject>(s);
                dy.getWeatherItem(weather);
                if (s.Contains("now"))
                {
                    //绑定now数据实时天气
                    firstWeather.DataContext = weather.now;
                }
                if (s.Contains("daily"))
                {
                    secondWeather.DataContext = weather.daily[0];
                    thirdWeather.DataContext = weather.daily[1];
                    fourthWeather.DataContext = weather.daily[2];
                }
                if (s.Contains("location"))
                {
                    String locationId = weather.getLocationId();
                    if (locationId != null)
                    {
                        String url = "https://devapi.qweather.com/v7/weather/";
                        clientGzip(url, "now", locationId, Properties.Resources.crayler);
                        clientGzip(url, "3d", locationId, Properties.Resources.crayler);
                        //cbCity.IsEnabled = true;
                    }

                }
                tbZone.Text = "foreast";

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        String url = "https://devapi.qweather.com/v7/weather/";
    }
}
