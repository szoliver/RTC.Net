#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RtcRecord
* Copyright(c) wisetoro
* CLR 版本: 4.0.30319.17929
* 创 建 人：orman
* 电子邮箱：104913543@qq.com
* 创建日期：2016/10/21 10:04:24
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

namespace RTC.Net
{
    class RtcProject
    {
        /// <summary>
        /// 获取此项目信息
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<ProjectItem> GetProjectDetail(long timeout = 30)
        {
            return Rtc.Get("/project/detail", timeout).asJson<ProjectItem>();
        }

        /// <summary>
        /// 更新此项目
        /// </summary>
        /// <param name="para"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<ProjectItem> UpdateProject(ProjectParameter para, long timeout = 30)
        {
            return Rtc.Patch("/project/update", timeout)
                .AddRangeField(para.ToParameter())
                .asJson<ProjectItem>();
        }

        /// <summary>
        /// 删除此项目信息
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<string> DeleteProject(long timeout = 30)
        {
            return Rtc.Delete("/project/delete", timeout)
                .asString();
        }

        /// <summary>
        /// 重置此项目API Secret
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<ProjectItem> ResetProject(long timeout = 30)
        {
            return Rtc.Delete("/project/reset", timeout)
                .asJson<ProjectItem>();
        }

    }
}
