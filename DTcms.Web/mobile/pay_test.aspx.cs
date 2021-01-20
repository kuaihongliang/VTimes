using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Test.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;

namespace DTcms.Web.mobile
{
    public partial class pay_test : System.Web.UI.Page
    {
        protected string openid;
        protected string code;
        static Dictionary<string, OAuthAccessTokenResult> OAuthCodeCollection = new Dictionary<string, OAuthAccessTokenResult>();
        static object OAuthCodeCollectionLock = new object();

        //CommonApiTest ca = new CommonApiTest();

        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string openId;
                    OAuthAccessTokenResult result = null;
                    code = Request.QueryString["code"].ToString();
                    try
                    {
                        //通过，用code换取access_token

                        var isSecondRequest = false;
                        lock (OAuthCodeCollectionLock)
                        {
                            Log.Info(this.GetType().ToString(), "code：" + code.ToString());
                            isSecondRequest = OAuthCodeCollection.ContainsKey(code);
                        }
                        if (!isSecondRequest)
                        {
                            //第一次请求
                            //LogUtility.Weixin.DebugFormat("第一次微信OAuth到达，code：{0}", code);
                            Log.Info(this.GetType().ToString(), "第一次微信OAuth到达，code：" + code);
                            lock (OAuthCodeCollectionLock)
                            {
                                OAuthCodeCollection[code] = null;
                            }
                        }
                        else
                        {
                            //第二次请求
                            //LogUtility.Weixin.DebugFormat("第二次微信OAuth到达，code：{0}", code);
                            Log.Info(this.GetType().ToString(), "第二次微信OAuth到达，code：" + code);
                            lock (OAuthCodeCollectionLock)
                            {
                                result = OAuthCodeCollection[code];
                            }
                        }
                        try
                        {
                            try
                            {
                                result = result ?? OAuthApi.GetAccessToken(WxPayConfig.GetConfig().GetAppID(), WxPayConfig.GetConfig().GetAppSecret(), code);
                            }
                            catch (Exception ex)
                            {
                                //return Content("OAuth AccessToken错误：" + ex.Message);
                                Log.Error(this.GetType().ToString(), ex.StackTrace.ToString() + "OAuth AccessToken错误：" + ex.Message);
                            }

                            if (result != null)
                            {
                                lock (OAuthCodeCollectionLock)
                                {
                                    OAuthCodeCollection[code] = result;
                                }
                            }
                        }
                        catch (ErrorJsonResultException ex)
                        {
                            if (ex.JsonResult.errcode == ReturnCode.不合法的oauth_code)
                            {
                                //code已经被使用过
                                lock (OAuthCodeCollectionLock)
                                {
                                    result = OAuthCodeCollection[code];
                                }
                            }
                        }

                        openId = result != null ? result.openid : null;
                    }
                    catch (Exception ex)
                    {
                        //return Content("授权过程发生错误：" + ex.Message);
                        Log.Error(this.GetType().ToString(), ex.StackTrace.ToString() + "\r\n授权过程发生错误：" + ex.Message);
                    }
                    ViewState["openid"] = result.openid;
                    Log.Info(this.GetType().ToString(), result.openid);
                    //使用result继续操作
                }
                else
                {
                    string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), "http://www.59online.com/mobile/pay_test.aspx", "state", Senparc.Weixin.MP.OAuthScope.snsapi_base);
                    Response.Redirect(url);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string total_fee = "1";
            if (ViewState["openid"] != null)
            {
                string openid = ViewState["openid"].ToString();
                string url = "http://www.59online.com/mobile/JsApiPayPage.aspx?openid=" + openid + "&total_fee=" + total_fee;
                Response.Redirect(url);
            }
            else
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面缺少参数，请返回重试" + "</span>");
                Button1.Visible = false;
                Button2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string total_fee = "100";
            if (ViewState["openid"] != null)
            {
                string openid = ViewState["openid"].ToString();
                string url = "http://www.59online.com/mobile/JsApiPayPage.aspx?openid=" + openid + "&total_fee=" + total_fee;
                Response.Redirect(url);
            }
            else
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面缺少参数，请返回重试" + "</span>");
                Button1.Visible = false;
                Button2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
            }
        }
    }
}