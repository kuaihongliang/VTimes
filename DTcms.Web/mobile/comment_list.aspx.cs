using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Senparc.Weixin.MP.AdvancedAPIs;
using WxPayAPI;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin;

namespace DTcms.Web.mobile
{
    public partial class comment_list : System.Web.UI.Page
    {
        protected string code;
        static Dictionary<string, OAuthAccessTokenResult> OAuthCodeCollection = new Dictionary<string, OAuthAccessTokenResult>();
        static object OAuthCodeCollectionLock = new object();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                            Log.Info(this.GetType().ToString(), "第一次微信OAuth到达，code：" + code);
                            lock (OAuthCodeCollectionLock)
                            {
                                OAuthCodeCollection[code] = null;
                            }
                        }
                        else
                        {
                            //第二次请求
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
                    ViewState["accesstoken"] = result.access_token;
                    OAuthUserInfo user = OAuthApi.GetUserInfo(result.access_token, result.openid);
                    ViewState["faceurl"] = user.headimgurl.ToString();
                    ViewState["nickname"] = user.nickname.ToString();

                    Log.Info(this.GetType().ToString(), result.openid);
                    //使用result继续操作
                    //hfdOpenid.Value = result.openid;
                    hfdCurrentOpenid.Value = result.openid;
                    BindData();
                }
                else
                {
                    string id = Request.QueryString["id"].ToString();
                    string _str = "http://" + Request.Url.Host + "/mobile/comment_list.aspx?id=" + id;
                    string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), _str, "state", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                    Response.Redirect(url);
                }

            }
        }

        private void BindData()
        {
            hfdJoinid.Value = Request.QueryString["id"].ToString();
            string _sql = "select people_openid from action_join_people where id=" + Request.QueryString["id"];
            DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
            if (_dt != null && _dt.Rows.Count > 0)
            {
                string record_openid = _dt.Rows[0][0].ToString();
                hfdRecordOpenid.Value = record_openid;
                string sql = "select action_support_people.*,people_name from action_support_people left join action_join_people on action_join_people.people_openid=action_support_people.support_to_openid where support_to_openid = '" + record_openid + "'  and is_pay_successed = 1 order by support_date desc";
                DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                rptList.DataSource = dt;
                rptList.DataBind();

            }

        }
    }
}