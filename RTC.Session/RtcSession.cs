#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RtcSession
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
    public class RTCSession
    {
        /// <summary>
        /// 获取会话(Session)列表
        /// </summary>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessions(long timeout = 30)
        {
            return Rtc.Get("/sessions", timeout).asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 获取永久会话列表
        /// </summary>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessionsPermanent(long timeout = 30)
        {
            return Rtc.Get("/sessions/permanent", timeout).asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="param">CreateSessionParameter对象</param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> CreateSession(CreateSessionParameter param, long timeout = 30)
        {
            return CreateSession(param.ToParameter());
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="param">Dictionary键值对</param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> CreateSession(Dictionary<string, object> param, long timeout = 30)
        {
            HttpRequest request = Rtc.Post("/sessions", timeout);
            foreach (var o in param)
            {
                if (o.Value != null)
                    request.field(o.Key, o.Value.ToString());
            }
            return request.asJson<SessionResult>();
        }

        /// <summary>
        /// 获取临时会话列表
        /// </summary>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessionsNoPermanent(long timeout = 30)
        {
            return Rtc.Get("/sessions/nonpermanent", timeout).asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 获取一个会话
        /// </summary>
        /// <param name="session_id">会话Id</param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> GetSession(string session_id, long timeout = 30)
        {
            return Rtc.Get("/sessions/" + session_id, timeout).asJson<SessionResult>();
        }

        /// <summary>
        /// 修改一个会话
        /// </summary>
        /// <param name="param"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> ModifySession(ModifySessionParameter param, long timeout = 30)
        {
            HttpRequest request = Rtc.Patch("/sessions/" + param.session_id, timeout);
            foreach (var o in param.ToParameter())
            {
                if (o.Value != null)
                    request.field(o.Key, o.Value.ToString());
            }
            return request.asJson<SessionResult>();
        }

        /// <summary>
        /// 删除一个会话
        /// </summary>
        /// <param name="param"></param>
        /// <param name="timeout">请求超时时间，单位秒</param>
        /// <returns></returns>
        public static HttpResponse<string> DeleteSession(string session_id, long timeout = 30)
        {
            return Rtc.Delete("/sessions/" + session_id, timeout).asString();
        }
    }
}
