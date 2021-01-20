using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WxPayAPI;

namespace DTcms.Web.mobile
{
    public partial class baoming : System.Web.UI.Page
    {
        protected string openid;
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
                    //检验是否openid已报名
                    string sql = "select * from action_join_people where people_openid = '" + result.openid + "'";
                    DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        btnBaoming.Text = "已报名";
                        btnBaoming.Enabled = false;
                    }
                }
                else
                {
                    string pid = Request.QueryString["pid"].ToString();
                    string _str = "http://" + Request.Url.Host + "/mobile/baoming.aspx?pid=" + pid;
                    string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), _str, "state", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                    Response.Redirect(url);
                }
            }
        }

        protected void btnBaoming_Click(object sender, EventArgs e)
        {
            //验证验证码
            string sql = "select * from action_code where phone_num = '" + txtPhoneNum.Text.Trim() + "' and code = '" + txtCode.Text + "' and getdate()<=effective_date";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('验证码输入错误!')", true);
                return;
            }
            //验证姓名和手机号码重复
            sql = "select * from action_join_people where people_name = '" + txtName.Text.Trim() + "' and mobile_phonenum = '" + txtPhoneNum.Text + "'";
            dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('您已报名，请勿重复报名!')", true);
                return;
            }
            if (ViewState["openid"] != null)
            {
                //验证openid重复
                sql = "select * from action_join_people where people_openid = '" + ViewState["openid"].ToString() + "'";
                dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('您已报名，请勿重复报名!')", true);
                    return;
                }
                string openid = "";
                openid = ViewState["openid"].ToString();
                string parent_openid = "";
                string team_id = "-1";
                if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                {
                    parent_openid = Request.QueryString["pid"];
                    string _sql = "select * from action_join_people where people_openid = '" + parent_openid + "'";
                    DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                    if (_dt != null && _dt.Rows.Count > 0 && !string.IsNullOrEmpty(_dt.Rows[0]["fk_team_id"].ToString()))
                    {
                        team_id = _dt.Rows[0]["fk_team_id"].ToString();
                    }
                    else
                    {
                        team_id = DBUtility.DbHelperSQL.Query("select id from action_team where is_default = 1").Tables[0].Rows[0][0].ToString();
                    }
                }
                sql = "insert into action_join_people values('" + txtName.Text.Trim() + "','" + txtPhoneNum.Text + "',getdate(),'" + openid + "','" + ViewState["faceurl"].ToString() + "','" + ViewState["nickname"].ToString() + "',1,0,NULL," + team_id + ",'" + parent_openid + "') SELECT @@IDENTITY";
                string _id = DBUtility.DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('报名成功！');window.location.href='index.aspx?id=" + _id + "'", true);
            }
        }
    }
}