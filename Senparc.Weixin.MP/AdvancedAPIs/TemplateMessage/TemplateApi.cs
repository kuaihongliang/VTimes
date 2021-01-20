/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：TemplateAPI.cs
    文件功能描述：模板消息接口
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
 
    修改标识：Senparc - 20150312
    修改描述：开放代理请求超时时间
----------------------------------------------------------------*/

/*
    API：http://mp.weixin.qq.com/wiki/17/304c1885ea66dbedf7dc170d84999a9d.html
 */

using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.CommonAPIs;

namespace Senparc.Weixin.MP.AdvancedAPIs
{
    /// <summary>
    /// 模板消息接口
    /// </summary>
    public static class TemplateApi
    {
        /// <summary>
        /// 模板消息接口
        /// </summary>
        /// <param name="accessTokenOrAppId"></param>
        /// <param name="openId"></param>
        /// <param name="templateId"></param>
        /// <param name="topcolor"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static SendTemplateMessageResult SendTemplateMessage(string accessTokenOrAppId, string openId, string templateId, string topcolor, string url, object data, int timeOut = Config.TIME_OUT)
        {
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                const string urlFormat = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
                var msgData = new TempleteModel()
                {
                    touser = openId,
                    template_id = templateId,
                    topcolor = topcolor,
                    url = url,
                    data = data
                };
                return CommonJsonSend.Send<SendTemplateMessageResult>(accessToken, urlFormat, msgData, timeOut: timeOut);

            }, accessTokenOrAppId);
        }


        /// <summary>
        /// 模板消息接口
        /// </summary>
        /// <param name="accessTokenOrAppId">AccessToken或AppId（推荐使用AppId，需要先注册）</param>
        /// <param name="openId">填接收消息的用户openid</param>
        /// <param name="templateId">订阅消息模板ID</param>
        /// <param name="url">（非必须）点击消息跳转的链接，需要有ICP备案</param>
        /// <param name="data">消息正文，value为消息内容文本（200字以内），没有固定格式，可用\n换行，color为整段消息内容的字体颜色（目前仅支持整段消息为一种颜色）</param>
        /// <param name="miniProgram">（非必须）跳小程序所需数据，不需跳小程序可不用传该数据</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        //[ApiBind(NeuChar.PlatformType.WeChat_OfficialAccount, "TemplateApi.SendTemplateMessage", true)]
        public static SendTemplateMessageResult SendTemplateMessage2(string accessTokenOrAppId, string openId, string templateId, string url, object data, int timeOut = Config.TIME_OUT)
        {
            //文档：https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1500374289_66bvB

            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                //string urlFormat = Config.ApiMpHost + "/cgi-bin/message/template/send?access_token={0}";
                string urlFormat = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
                var msgData = new TempleteModel()
                {
                    touser = openId,
                    template_id = templateId,
                    // topcolor = topcolor,
                    url = url,
                    //miniprogram = miniProgram,
                    data = data,
                };
                return CommonJsonSend.Send<SendTemplateMessageResult>(accessToken, urlFormat, msgData, timeOut: timeOut);

            }, accessTokenOrAppId);
        }
    }
}