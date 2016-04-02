#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：ParameterHelper
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

namespace RTC.Net
{
    public class BaseParameter
    {
        /// <summary>
        /// 标签,长度为255,默认为空
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 持久化,默认为false,设为true时会话永不过期
        /// </summary>
        public bool permanent { get; set; }

        /// <summary>
        /// 自定义数据,长度为1024
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// 存活时间,单位为天,超过时间则会话过期,默认为30天，对于令牌默认为15天
        /// </summary>
        public int live_days { get; set; }

        public virtual Dictionary<string, object> ToParameter()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            ret.Add("label", label);
            ret.Add("permanent", permanent.ToString().ToLower());
            ret.Add("data", data);
            ret.Add("live_days", live_days);
            return ret;
        }
    }

    /// <summary>
    /// 创建会话参数
    /// </summary>
    public class CreateSessionParameter : BaseParameter
    {
        /// <summary>
        /// 类型,仅可以为p2p或rel
        /// </summary>
        public string type { get; set; }

        public override Dictionary<string, object> ToParameter()
        {
            Dictionary<string, object> ret = base.ToParameter();
            ret.Add("type", type.ToLower());
            return ret;
        }
    }

    /// <summary>
    /// 修改会话参数
    /// </summary>
    public class ModifySessionParameter : BaseParameter
    {
        /// <summary>
        /// 会话Id
        /// </summary>
        public string session_id { get; set; }

        public override Dictionary<string, object> ToParameter()
        {
            Dictionary<string, object> ret = base.ToParameter();
            ret.Add("session_id", session_id);
            return ret;
        }
    }

    public class CreateTokenParameter : BaseParameter
    {
        /// <summary>
        /// 会话Id
        /// </summary>
        public string session_id { get; set; }
        /// <summary>
        /// 类型,仅可以为pub(发布者)或sub(接收者)
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 个数，一次可创建多个令牌，最多为10，留空则创建一个
        /// </summary>
        public string number { set; get; }
        public override Dictionary<string, object> ToParameter()
        {
            Dictionary<string, object> ret = base.ToParameter();
            ret.Add("session_id", session_id);
            ret.Add("type", type.ToLower());
            ret.Add("number", number);
            return ret;
        }
    }

    public class ModifyTokenParameter : BaseParameter
    {
        public string token_id { get; set; }
        public override Dictionary<string, object> ToParameter()
        {
            Dictionary<string, object> ret = base.ToParameter();
            ret.Add("token_id", token_id);
            return ret;
        }
    }
}
