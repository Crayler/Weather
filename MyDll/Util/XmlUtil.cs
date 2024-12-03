using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyDll
{
    public class XmlUtil
    {
        /*
         * xml序列化方法
         * */
        public static String serialize<T>(T obj)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));//创建一-个 XmlSerializer 对象
            MemoryStream ms = new MemoryStream();//创建一个内存流
            xml.Serialize(ms, obj);//通过 XmlSerializer 的 Serialize 方法把对象序列化到内存流中
            string s = Encoding.UTF8.GetString(ms.ToArray()); //把内存流转为 XML 字符串
            return s;//返回字符串
        }

        /*
         * xml反序列化方法
         * */
        public static T deserialize<T>(string s)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));//创建一-个 XmlSerializer 对象
            byte[] buf = Encoding.UTF8.GetBytes(s); //根据XML字符串s转化为byte数组
            MemoryStream ms = new MemoryStream(buf);//根据byte数组创建一个内存流
            T w = (T)xml.Deserialize(ms);// XML 字符串反序列化后又回到对象
            return w;//返回对象
        }

    }
}
