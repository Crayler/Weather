using MyDll;
using MyDll.model;
using MyDll.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbCity.Items.Add("选择");
            cbCity.Items.Add("北京");
            cbCity.Items.Add("上海");
            cbCity.Items.Add("深圳");
            cbCity.Items.Add("武汉");
            cbCity.Items.Add("天津");
            cbCity.Items.Add("重庆");

            //cbCity.SelectedIndex = 0;

        }

        private void btCon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GZipWebClient client = new GZipWebClient();
                client.Encoding = Encoding.UTF8;
                client.DownloadDataCompleted += Client_DownloadDataCompleted;
                String url = "https://devapi.qweather.com/v7/weather/now?location=101200101&key=" + Properties.Resources.crayler;

                client.DownloadDataAsync(new Uri(url));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public void clientGzip(String url, String u, String city, String key)
        {
            GZipWebClient client = new GZipWebClient();
            client.Encoding = Encoding.GetEncoding("GB2312");
            client.DownloadDataCompleted += Client_DownloadDataCompleted;
            Uri uri = new Uri(url + u + "?location=" + city + "&key=" + Properties.Resources.crayler);
            client.DownloadDataAsync(uri, city);
            txt.Text = "等待服务器响应...";
        }

        public void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                String s = Encoding.UTF8.GetString(e.Result);
                txt.Text = s;
                Rootobject weather = JsonUtil.deserialize<Rootobject>(s);
                if (s.Contains("now"))
                {
                    txt.Text = weather.now.ToString();
                }
                if (s.Contains("daily"))
                {
                    txtf.Text = "\r\n3天天气预报：\r\n" + weather.ToString();
                    //cbCity.IsEnabled = true;
                }
                if (s.Contains("location"))
                {
                   String locationId = weather.getLocationId();
                    if (locationId != null)
                    {
                        clientGzip(url, "now", locationId, Properties.Resources.crayler);
                        clientGzip(url, "3d", locationId, Properties.Resources.crayler);
                        //cbCity.IsEnabled = true;
                    }

                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        String url = "https://devapi.qweather.com/v7/weather/";
       


        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                String city = cbCity.SelectedItem.ToString();
                //switch (city)
                //{
                //    case "北京":
                //       city = 
                //        break;
                //    case "武汉":
                //        city = "101200101";
                //        break;
                //    case "上海":
                //        city = "101020100";
                //        break;
                //    case "深圳":
                //        city = "101280601";
                //        break;
                //    default:
                //        city = "101200101";
                //        break;

                //}
                clientGzip("https://geoapi.qweather.com/v2/city/", "lookup", city, Properties.Resources.crayler);

                //clientGzip(url,"now",city, Properties.Resources.crayler);
                //clientGzip(url,"3d",city, Properties.Resources.crayler);
                //GZipWebClient client = new GZipWebClient();
                //client.Encoding = Encoding.UTF8;
                //client.DownloadDataCompleted += Client_DownloadDataCompleted;
                //String url = "https://devapi.qweather.com/v7/weather/now?location=" + city + "&key=" + Properties.Resources.crayler;
                //client.DownloadDataAsync(new Uri(url));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


       
    }
}
