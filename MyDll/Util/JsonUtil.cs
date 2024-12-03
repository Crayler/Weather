using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyDll.Util
{
    public class JsonUtil
    {
        public static string serialize<T>(T obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            json.WriteObject(ms, obj);
            string s = Encoding.UTF8.GetString(ms.ToArray());
            return s;
        }

        public static T deserialize<T>(string s)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            byte[] buf = Encoding.UTF8.GetBytes(s);
            MemoryStream ms = new MemoryStream(buf);
            T obj = (T)json.ReadObject(ms);
            return obj;
        }

    }
}
