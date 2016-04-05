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
        public int page { get; set; }
        public int page_size { get; set; }
    }
    #endregion

    #region 录像相关定义
    public class GetRecordsResult : GetBaseResult
    {
        public List<RecordResult> results { set; get; }
    }

    public class RecordResult : BaseResult
    {
        public DateTime video_start { get; set; }
        public DateTime video_stop { get; set; }
        public int video_length { get; set; }
        public VideoType video_type { get; set; }
        public DateTime time_start { get; set; }
        public string project { get; set; }
        public string session { get; set; }
        public string token { get; set; }
        public string channel { get; set; }
        public RecordAction action { set; get; }
        public RecordStatus status { set; get; }
        public string url { get; set; }
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

        public UpdateSessionParameter ToParamter()
        {
            return new UpdateSessionParameter()
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
        public List<TokenResult> results { set; get; }
    }

    public class TokenResult : BaseResult
    {
        public TokenType type { get; set; }
        public int live_days { get; set; }
        public string session_id { get; set; }

        public UpdateTokenParameter ToParamter()
        {
            return new UpdateTokenParameter()
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
