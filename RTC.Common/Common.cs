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
using unirest_net.http;
using unirest_net.request;

namespace RTC.Net
{
    public class Rtc
    {
        // Should add overload that takes URL object
        public static HttpRequest Get(string url)
        {
            return Unirest.get(Config.ServerUrl + url).AddRTCHead();
        }

        public static HttpRequest Post(string url)
        {
            return Unirest.post(Config.ServerUrl + url).AddRTCHead();
        }

        public static HttpRequest Delete(string url)
        {
            return Unirest.delete(Config.ServerUrl + url).AddRTCHead();
        }

        public static HttpRequest Patch(string url)
        {
            return Unirest.patch(Config.ServerUrl + url).AddRTCHead();
        }

        public static HttpRequest Put(string url)
        {
            return Unirest.put(Config.ServerUrl + url).AddRTCHead();
        }
    }

    public static class ExtFunc
    {
        public static HttpRequest AddRTCHead(this HttpRequest t)
        {
            return t.header(Config.ApiKeyName, Config.ApiKey)
                .header(Config.ApiSecretName, Config.ApiSecret);
        }
    }

}
