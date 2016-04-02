#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：ResultHelper
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

namespace RTC.Net
{
    #region 基类定义
    public class BaseResult
    {
        public string error { get; set; }
        public dynamic description { set; get; }
        public Guid uuid { get; set; }
        public string label { get; set; }
        public bool permanent { get; set; }
        public string data { get; set; }
        public DateTime time_created { get; set; }
        public DateTime expire_in { get; set; }

    }

    public class GetBaseResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
    }
    #endregion

    #region 会话相关定义
    public class GetSessionsResult : GetBaseResult
    {
        public List<SessionResult> results { set; get; }
    }

    public class SessionResult : BaseResult
    {
        public string type { get; set; }
        public int live_days { get; set; }

        public ModifySessionParameter ToParamter()
        {
            return new ModifySessionParameter()
            {
                data = data,
                label = label,
                live_days = live_days,
                permanent = permanent,
                session_id = uuid.ToString()
            };
        }
    }
    #endregion

    #region 令牌相关定义
    public class GetTokenResult : GetBaseResult
    {
        public List<SessionResult> results { set; get; }
    }

    public class TokenResult : BaseResult
    {
        public string type { get; set; }
        public int live_days { get; set; }
        public string session_id { get; set; }
        public ModifyTokenParameter ToParamter()
        {
            return new ModifyTokenParameter()
            {
                data = data,
                label = label,
                live_days = live_days,
                permanent = permanent,
                token_id = uuid.ToString()
            };
        }

    }
    #endregion
}
