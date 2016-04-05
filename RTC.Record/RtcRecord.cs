#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RtcRecord
* Copyright(c) wisetoro
* CLR 版本: 4.0.30319.17929
* 创 建 人：orman
* 电子邮箱：104913543@qq.com
* 创建日期：2016/4/4 22:04:24
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
    class RTCRecord
    {
        /// <summary>
        /// 获取录制记录列表
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<GetRecordsResult> GetRecords(int page = 1, int page_size = 25, long timeout = 30)
        {
            return Rtc.Get("/records?page=" + page + "&page_size=" + page_size, timeout).asJson<GetRecordsResult>();
        }

        /// <summary>
        /// 开始/停止录像
        /// </summary>
        /// <returns></returns>
        public HttpResponse<RecordResult> ProcessRecord(ProcessRecordParam param, long timeout = 30)
        {
            return Rtc.Post("/records", timeout)
                .AddRangeField(param.ToParameter())
                .asJson<RecordResult>();
        }

        /// <summary>
        /// 获取一个录像记录
        /// </summary>
        /// <param name="record_id"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<RecordResult> GerRecord(string record_id, long timeout = 30)
        {
            return Rtc.Get("/records/" + record_id, timeout).asJson<RecordResult>();
        }

        /// <summary>
        /// 更新一个录像记录
        /// </summary>
        /// <param name="record_id"></param>
        /// <param name="label"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public HttpResponse<RecordResult> UpdateRecord(string record_id, string label, long timeout = 30)
        {
            return Rtc.Patch("/records/" + record_id, timeout).field("label", label).asJson<RecordResult>();
        }
    }
}
