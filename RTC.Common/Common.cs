#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Common
* Copyright(c) wisetoro
* CLR 版本: 4.0.30319.17929
* 创 建 人：orman
* 电子邮箱：104913543@qq.com
* 创建日期：2016/4/3 01:40:49
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System.Collections.Generic;
using System.Reflection;
using unirest_net.http;
using unirest_net.request;

namespace RTC.Net
{
    public class Rtc
    {
        // Should add overload that takes URL object
        public static HttpRequest Get(string url, long timeout = 30)
        {
            return Unirest.get(Config.ServerUrl + url, timeout).AddRTCHead();
        }

        public static HttpRequest Post(string url, long timeout = 30)
        {
            return Unirest.post(Config.ServerUrl + url, timeout).AddRTCHead();
        }

        public static HttpRequest Delete(string url, long timeout = 30)
        {
            return Unirest.delete(Config.ServerUrl + url, timeout).AddRTCHead();
        }

        public static HttpRequest Patch(string url, long timeout = 30)
        {
            return Unirest.patch(Config.ServerUrl + url, timeout).AddRTCHead();
        }

        public static HttpRequest Put(string url, long timeout = 30)
        {
            return Unirest.put(Config.ServerUrl + url, timeout).AddRTCHead();
        }
    }

    public static class ExtFunc
    {
        public static HttpRequest AddRTCHead(this HttpRequest t)
        {
            return t.header(Config.ApiKeyName, Config.ApiKey)
                .header(Config.ApiSecretName, Config.ApiSecret);
        }

        /// <summary>
        /// 对象转换成字典数据以便于发起POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToParameter<T>(this T t)
            where T : class, new()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            PropertyInfo[] pi = t.GetType().GetProperties();
            foreach (var o in pi)
            {
                object ov = o.GetValue(t, null);
                string ovs = ov.ToString();
                if (ov.GetType().IsEnum|| ov.GetType() == typeof(bool))
                    ovs = ovs.ToLower();
                ret.Add(o.Name, ovs);
            }
            return ret;
        }

        public static HttpRequest AddRangeField(this HttpRequest request, Dictionary<string, object> value)
        {
            foreach (var o in value)
            {
                if (o.Value != null)
                    request.field(o.Key, o.Value.ToString());
            }
            return request;
        }
    }

    public enum SessionType
    {
        P2P = 1,
        REL = 2
    }

    public enum TokenType
    {
        /// <summary>
        /// 发布者
        /// </summary>
        PUB = 1,
        /// <summary>
        /// 接收者
        /// </summary>
        SUB = 2
    }

    public enum VideoType
    {
        MP4,
        WEBM
    }
    public enum RecordAction
    {
        START,
        STOP
    }
    public enum RecordStatus
    {
        RECORDING,
        DONE
    }
}
