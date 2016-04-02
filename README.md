# RTC.Net SDK V1.0
用于操作实时猫（RealTimeCat）服务端API，官方网站：https://shishimao.com/
基于.Net 4.0环境开发

#SDK开发示例
1.0版 主要操作会话和令牌

##简单配置
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
            var res5 = RTCSession.GetSession("c8a8559d-5552-4fbd-b8d5-ddce83ab0f76");
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
            var res8 = RTCToken.GetTokens("80588ca1-b81f-4182-ad0d-6d7b7543101f");
            var res9 = RTCToken.GetSessionsNoPermanent("80588ca1-b81f-4182-ad0d-6d7b7543101f");
            var res10 = RTCToken.GetSessionsPermanent("80588ca1-b81f-4182-ad0d-6d7b7543101f");
            var res12 = RTCToken.CreateToken(new CreateTokenParameter()
            {
                label = "Token23",
                live_days = 1,
                session_id = "80588ca1-b81f-4182-ad0d-6d7b7543101f",
                type = "Pub"
            });
```
