#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RtcToken
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unirest_net.http;
using unirest_net.request;

namespace RTC.Net
{
    public class RTCToken
    {
        /// <summary>
        /// 获取session_id下令牌列表
        /// </summary>
        /// <param name="session_id"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetTokens(string session_id, int page = 1, int page_size = 25, long timeout = 30)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens?page=" + page + "&page_size=" + page_size, timeout).asJson<GetTokenResult>();
        }

        /// <summary>
        /// 创建一个令牌
        /// </summary>
        /// <param name="param"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> CreateToken(CreateTokenParameter param, long timeout = 30)
        {
            return Rtc.Post("/sessions/" + param.session_id + "/tokens", timeout)
                .AddRangeField(param.ToParameter())
                .asJson<TokenResult>();
        }

        /// <summary>
        /// 获取session_id下永久令牌列表
        /// </summary>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetTokensPermanent(string session_id, int page = 1, int page_size = 25, long timeout = 30)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens/permanent?page=" + page + "&page_size=" + page_size, timeout).asJson<GetTokenResult>();
        }

        /// <summary>
        /// 获取session_id下临时令牌列表
        /// </summary>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetTokensNoPermanent(string session_id, int page = 1, int page_size = 25, long timeout = 30)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens/nonpermanent?page=" + page + "&page_size=" + page_size, timeout).asJson<GetTokenResult>();
        }

        /// <summary>
        /// 获取一个令牌
        /// </summary>
        /// <param name="token_id"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> GetToken(string token_id, long timeout = 30)
        {
            return Rtc.Get("/tokens/" + token_id, timeout).asJson<TokenResult>();
        }

        /// <summary>
        /// 修改一个令牌
        /// </summary>
        /// <param name="param"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> UpdateToken(UpdateTokenParameter param, long timeout = 30)
        {
            return Rtc.Patch("/tokens/" + param.token_id, timeout)
                .AddRangeField(param.ToParameter())
                .asJson<TokenResult>();
        }

        /// <summary>
        /// 删除一个令牌
        /// </summary>
        /// <param name="token_id"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<string> DeleteToken(string token_id, long timeout = 30)
        {
            return Rtc.Delete("/tokens/" + token_id, timeout).asString();
        }
    }
}
