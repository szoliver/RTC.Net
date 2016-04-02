#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：OperateStatus
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
namespace RTC.Net
{
    public class Config
    {
        /// <summary>
        /// RTC版本号
        /// </summary>
        public static string Version = "0.3";
        /// <summary>
        /// 服务器API调用根地址
        /// </summary>
        public static string ServerUrl = "https://api.realtimecat.com/v" + Config.Version;
        //public static string ServerUrl = "http://localhost:52774/home/api";
        /// <summary>
        /// 身份验证:ApiKey
        /// </summary>
        public static string ApiKeyName = "X-RTCAT-APIKEY";
        /// <summary>
        /// 身份验证:ApiSecret
        /// </summary>
        public static string ApiSecretName = "X-RTCAT-SECRET";

        public static string ApiKey { get; set; }
        public static string ApiSecret { get; set; }

    }
}
