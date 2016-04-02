# RTC.Net SDK V1.0
用于操作实时猫（RealTimeCat）服务端API，官方网站：https://shishimao.com/
<hr \>
专注于WebRTC技术的实时音视频云服务平台<br \>
实时猫提供 以视频通讯功能为核心的系统开发解决方案，简化和增强WebRTC开发的公有云平台，以及行业领先的WebRTC私有云服务<br \>
实时猫是专注于WebRTC技术的实时云视频技术服务商，致力于为企业提供专业的实时通讯技术云和端服务，使语音视频开发更加稳定、快速、简易、可定制。<br \>
专业、高水平、执行力强的技术团队为客户的业务快速发展可靠的核心技术产品,实时猫的愿景是让实时音视频通讯开发触手可得<br \>
此SDK基于.Net 4.0环境开发

#SDK开发示例
1.0版 主要操作会话和令牌

##简单配置
请使用Nuget或其他工具安装Microsoft.Net.Http和Newtonsoft.Json包及引用<br \>
```c#
using RTC.Net;
Config.ApiKey = "d1383590-7f1b-4242-86ee-*******";
Config.ApiSecret = "579d679f-84b8-4125-bc34-********";
```
##会话操作
```C#
            获取会话列表
            var res1 = RTCSession.GetSessions();
            建立一个会话
            var res2 = RTCSession.CreateSession(new CreateSessionParameter()
            {
                label = "testtestes111",
                data = "",
                live_days = 4,
                permanent = false,
                type = "P2P"
            });
            获取永久会话
            var res3 = RTCSession.GetSessionsPermanent();
            获取临时会话
            var res4 = RTCSession.GetSessionsNoPermanent();
            获取一个会话
            var res5 = RTCSession.GetSession("c8a8559d-5552-4fbd-****-ddce83ab0f76");
            修改一个会话
            SessionResult sr = res5.Body;
            sr.label = "a123458T";
            sr.live_days = 2;
            var res6 = RTCSession.ModifySession(sr.ToParamter());
            删除一个会话
            var res7 = RTCSession.DeleteSession(sr.uuid.ToString());
```
##令牌操作
```c#
            var res8 = RTCToken.GetTokens("80588ca1-b81f-****-ad0d-6d7b7543101f");
            var res9 = RTCToken.GetSessionsNoPermanent("80588ca1-b81f-****-ad0d-6d7b7543101f");
            var res10 = RTCToken.GetSessionsPermanent("80588ca1-b81f-****-ad0d-6d7b7543101f");
            var res12 = RTCToken.CreateToken(new CreateTokenParameter()
            {
                label = "Token23",
                live_days = 1,
                session_id = "80588ca1-b81f-****-ad0d-6d7b7543101f",
                type = "Pub"
            });
```
