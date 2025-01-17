﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyDll.model
{
    public class Daily
    {
        public string fxDate { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moonPhase { get; set; }
        public string moonPhaseIcon { get; set; }
        public string tempMax { get; set; }
        public string tempMin { get; set; }
        public string tmp1 { get; set; }
        public string iconDay { get; set; }
        public string textDay { get; set; }
        public string iconNight { get; set; }
        public string textNight { get; set; }
        public string wind360Day { get; set; }
        public string windDirDay { get; set; }
        public string windScaleDay { get; set; }
        public string windSpeedDay { get; set; }
        public string wind360Night { get; set; }
        public string windDirNight { get; set; }
        public string windScaleNight { get; set; }
        public string windSpeedNight { get; set; }
        public string humidity { get; set; }
        public string precip { get; set; }
        public string pressure { get; set; }
        public string vis { get; set; }
        public string cloud { get; set; }
        public string uvIndex { get; set; }

        public override string ToString()
        {
            return "\r\n日期：" + fxDate + "\n" + "白天：" + textDay + "\n" + "晚上：" + textNight + "\n" + "最高气温" + tempMax + "\n" + "最低气温" + tempMin + "\n";
        }
    }

}


