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
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessions()
        {
            return Rtc.Get("/sessions").asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 获取永久会话列表
        /// </summary>
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessionsPermanent()
        {
            return Rtc.Get("/sessions/permanent").asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="param">CreateSessionParameter对象</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> CreateSession(CreateSessionParameter param)
        {
            return CreateSession(param.ToParameter());
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="param">Dictionary键值对</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> CreateSession(Dictionary<string, object> param)
        {
            HttpRequest request = Rtc.Post("/sessions");
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
        /// <returns></returns>
        public static HttpResponse<GetSessionsResult> GetSessionsNoPermanent()
        {
            return Rtc.Get("/sessions/nonpermanent").asJson<GetSessionsResult>();
        }

        /// <summary>
        /// 获取一个会话
        /// </summary>
        /// <param name="session_id">会话Id</param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> GetSession(string session_id)
        {
            return Rtc.Get("/sessions/" + session_id).asJson<SessionResult>();
        }

        /// <summary>
        /// 修改一个会话
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static HttpResponse<SessionResult> ModifySession(ModifySessionParameter param)
        {
            HttpRequest request = Rtc.Patch("/sessions/" + param.session_id);
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
        /// <returns></returns>
        public static HttpResponse<string> DeleteSession(string session_id)
        {
            return Rtc.Delete("/sessions/" + session_id).asString();
        }
    }
}
