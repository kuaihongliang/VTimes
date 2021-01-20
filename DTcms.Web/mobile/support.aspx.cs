using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WxPayAPI;
using System.Data;

namespace DTcms.Web.mobile
{
    public partial class support : System.Web.UI.Page
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
                    ViewState["accesstoken"] = result.access_token;
                    OAuthUserInfo user = OAuthApi.GetUserInfo(result.access_token, result.openid);
                    ViewState["faceurl"] = user.headimgurl.ToString();
                    ViewState["nickname"] = user.nickname.ToString();

                    Log.Info(this.GetType().ToString(), result.openid);
                    //使用result继续操作
                }
            }
        }

        protected void lbtnPay_Click(object sender, EventArgs e)
        {
            if (txtMoney.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请填写金额！')", true);
                return;
            }
            else if (Convert.ToDecimal(txtMoney.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('支持金额不能小于0！')", true);
                return;
            }
            string sql = "select * from action_join_people where id=" + Request.QueryString["id"].ToString();
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];

            decimal suport_money = Convert.ToDecimal(txtMoney.Text.Trim());
            decimal rest_money;
            string _sql = "select sum(support_money) from action_support_people where support_to_openid = '" + dt.Rows[0]["people_openid"].ToString() + "' and is_pay_successed = 1";
            DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
            if (_dt != null && _dt.Rows.Count > 0 && !string.IsNullOrEmpty(_dt.Rows[0][0].ToString()))
            {
                rest_money = globalField.target_money - Convert.ToDecimal(_dt.Rows[0][0].ToString());
            }
            else
            {
                rest_money = globalField.target_money;
            }
            if (suport_money > rest_money)
            {
                suport_money = rest_money;
            }

            if (dt != null && dt.Rows.Count > 0 && ViewState["openid"] != null)
            {
                string total_fee = suport_money.ToString();
                string by_openid = ViewState["openid"].ToString();
                string by_nickname = ViewState["nickname"].ToString();
                string by_name = txt_support_name.Text;
                string by_phone = txt_support_phone.Text;
                string by_faceurl = ViewState["faceurl"].ToString();
                string to_openid = dt.Rows[0]["people_openid"].ToString();
                string inner_order_num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string bless_info = "";
                if (txtMsg.Text.Trim() != "")
                {
                    bless_info = txtMsg.Text.Trim();
                }
                else
                {
                    bless_info = bless_str();
                }
                sql = "insert into action_support_people values('" + by_openid + "','" + by_nickname + "','" + by_name + "','" + by_phone + "','" + by_faceurl + "',getdate()," + total_fee + ",'" + to_openid + "','" + inner_order_num + "',0,'" + bless_info + "',0,0,'')";
                DBUtility.DbHelperSQL.ExecuteSql(sql);

                string openid = ViewState["openid"].ToString();
                string url = "http://" + Request.Url.Host + "/mobile/JsApiPayPage.aspx?openid=" + openid + "&total_fee=" + total_fee + "&order=" + inner_order_num;
                //string url = "http://www.59online.com/mobile/JsApiPayPage.aspx?openid=" + openid + "&total_fee=" + total_fee;
                Response.Redirect(url);

            }
            else
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面缺少参数，请返回重试" + "</span>");
            }
        }

        private string bless_str()
        {
            List<string> lst_bless = new List<string>();
            lst_bless.Add("希望我的一份支持，能成为你坚持下去的一份动力，加油！");
            lst_bless.Add("今天你支持我，明天我支持你，朋友之间就需要相互帮助！");
            lst_bless.Add("有梦想的人永远值得被尊重，我用行动支持你！");
            lst_bless.Add("每一份梦想都值得被尊重，支持你，小伙伴，记得带上我的那一份一起去！");
            lst_bless.Add("支持的不仅仅是金钱，更是对你认可与肯定，加油，去追逐你的梦想！");

            Random rd = new Random();
            int n = rd.Next(0, 4);
            return lst_bless[n];
        }
    }
}