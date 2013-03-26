﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GdutWeixin.Utils
{
    public static class DateTimeHelper
    {
        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime Timestamp2DateTime(long dateTimeFromXml)
        {
            return BaseTime.AddTicks((dateTimeFromXml + 8 * 60 * 60) * 10000000);
        }
        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime Timestamp2DateTime(string dateTimeFromXml)
        {
            return Timestamp2DateTime(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 获取微信DateTime
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long Timestamp(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000;
        }

        public static long Timestamp()
        {
            return Timestamp(DateTime.UtcNow);
        }
    }
}