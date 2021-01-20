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
    public partial class index : System.Web.UI.Page
    {
        string appId;
        string timestamp;
        string nonceStr;
        string Signature;
        CommonApiTest ca = new CommonApiTest();

        //protected string openid;
        //protected string code;
        //static Dictionary<string, OAuthAccessTokenResult> OAuthCodeCollection = new Dictionary<string, OAuthAccessTokenResult>();
        //static object OAuthCodeCollectionLock = new object();

        protected void Page_Load(object sender, EventArgs e)
        {
            //weixin js
            hfdappid.Value = appId = ca._appId;
            timestamp = JSSDKHelper.GetTimestamp();
            hfdtimestamp.Value = timestamp.ToString();
            hfdnonceStr.Value = nonceStr = JSSDKHelper.GetNoncestr();
            JsApiTicketResult Js_result = CommonApi.GetTicket(ca._appId, ca._appSecret);
            hfdSignature.Value = Signature = JSSDKHelper.GetSignature(Js_result.ticket, nonceStr, timestamp, Request.Url.ToString().Split('#')[0]);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    hfdId.Value = Request.QueryString["id"].ToString();
                    GetSeedInfo();
                    BindSeedVip();
                }
                GetZhichiRankList();
                GetShousuRankList();
                GetYinxiangRankList();
                GetData();

            }
        }

        private void GetData()
        {
            lblJoinCount.Text = DBUtility.DbHelperSQL.Query("select id from action_join_people where is_active = 1").Tables[0].Rows.Count.ToString();
            lblCommentCount.Text = DBUtility.DbHelperSQL.Query("select id from action_support_people where is_pay_successed = 1").Tables[0].Rows.Count.ToString();
            lblTeamCount.Text = DBUtility.DbHelperSQL.Query("select id from action_team where 1=1").Tables[0].Rows.Count.ToString();

            lblTargetMoney.Text = Convert.ToInt16(globalField.target_money).ToString();
        }

        /// <summary>
        /// 报名人信息
        /// </summary>
        private void GetSeedInfo()
        {
            DateTime taget_date = globalField.target_date;
            TimeSpan ts = taget_date - DateTime.Now;
            lbl_rest_day.Text = ts.Days >= 0 ? ts.Days.ToString() : "0";
            string sql = "select * from action_join_people left join action_team on action_team.id = action_join_people.fk_team_id where action_join_people.id=" + Request.QueryString["id"].ToString();
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                this.Title = dt.Rows[0]["people_name"].ToString() + "-“觉醒之路”首届商界精英茶马古道挑战赛";
                lblSeedName.Text = dt.Rows[0]["people_name"].ToString();
                img_face.ImageUrl = dt.Rows[0]["people_face"].ToString();
                lbl_join_date.Text = dt.Rows[0]["careate_date"].ToString();
                lblTeamName.Text = dt.Rows[0]["team_name"].ToString() + "-";
                hfdParentOpenid.Value = dt.Rows[0]["people_openid"].ToString();

                string _sql = "select id from action_support_people where support_to_openid = '" + dt.Rows[0]["people_openid"].ToString() + "' and is_pay_successed = 1";
                lbl_comment_count2.Text = lbl_comment_count.Text = DBUtility.DbHelperSQL.Query(_sql).Tables[0].Rows.Count.ToString();

                _sql = "select sum(support_money) from action_support_people where support_to_openid = '" + dt.Rows[0]["people_openid"].ToString() + "' and is_pay_successed = 1";
                DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0 && !string.IsNullOrEmpty(_dt.Rows[0][0].ToString()))
                {
                    decimal rest_money = globalField.target_money - Convert.ToDecimal(_dt.Rows[0][0].ToString());
                    if (rest_money >= 0)
                    {
                        lbl_rest_money.Text = Math.Round(rest_money, 2).ToString();
                    }
                    else
                    {
                        lbl_rest_money.Text = "0";
                    }
                    decimal done_per = Convert.ToDecimal(_dt.Rows[0][0].ToString()) / globalField.target_money * 100;
                    if (done_per >= 100)
                    {
                        done_per = 100;
                    }
                    lbl_done_per.Text = Math.Round(done_per, 1).ToString() + "%";

                    processBar.Style["width"] = Math.Round(done_per, 1).ToString() + "%";
                    if (done_per >= 70)
                    {
                        highlightPercent.Style["left"] = Math.Round(done_per - 10, 1).ToString() + "%";
                    }
                    else
                    {
                        highlightPercent.Style["left"] = Math.Round(done_per, 1).ToString() + "%";
                    }
                    //processBar.Style["width"] ="80%";
                }
                else
                {
                    lbl_rest_money.Text = Math.Round(globalField.target_money, 2).ToString();
                    lbl_done_per.Text = "0%";
                    processBar.Style["width"] = "1%";
                    highlightPercent.Style["left"] = "0%";
                }

                _sql = "select  distinct top 5 support_by_openid,support_by_faceurl from action_support_people where support_to_openid = '" + dt.Rows[0]["people_openid"].ToString() + "' and is_pay_successed = 1";
                _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                rptComment.DataSource = _dt;
                rptComment.DataBind();

                if (dt.Rows[0]["is_done"].ToString() == "1")
                {
                    lbtnSupport.Text = "已完成";
                    lbtnSupport.Enabled = false;
                }
            }
        }

        private void GetShousuRankList()
        {
            //手速榜
            string sql = "select top 10 *,(select COUNT(*) from action_support_people where support_to_openid = people_openid) as comment_count from action_join_people left join action_team on action_team.id=action_join_people.fk_team_id where is_done=1 and done_date is not null order by is_done desc,done_date";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            dt.Columns.Add("cost_time");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime start = Convert.ToDateTime(dt.Rows[i]["careate_date"]);
                DateTime end = Convert.ToDateTime(dt.Rows[i]["done_date"]);

                TimeSpan ts = end - start;
                if (ts.Days > 0)
                {
                    dt.Rows[i]["cost_time"] = ts.Days.ToString() + "天完成";
                }
                else if (ts.Hours > 0)
                {
                    dt.Rows[i]["cost_time"] = ts.Hours.ToString() + "小时完成";
                }
                else
                {
                    dt.Rows[i]["cost_time"] = ts.Minutes.ToString() + "分钟完成";
                }
            }
            rptShousu.DataSource = dt;
            rptShousu.DataBind();
        }

        private void GetZhichiRankList()
        {
            //支持榜
            string sql = "select top 10 *,(select COUNT(*) from action_support_people where is_pay_successed = 1 and support_to_openid = people_openid) as comment_count,(select SUM(support_money) from action_support_people where is_pay_successed = 1 and support_to_openid = people_openid) as comment_money from action_join_people left join action_team on action_team.id=action_join_people.fk_team_id where 1 = 1 order by comment_money desc, comment_count desc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            rptZhichi.DataSource = dt;
            rptZhichi.DataBind();
        }

        private void GetYinxiangRankList()
        {
            //影响力
            string sql = "select top 10 *,(select COUNT(*) from action_join_people t1 where t1.parent_openid = t2.people_openid) as y_count from action_join_people t2 where 1 = 1 order by y_count desc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            rptYinxiang.DataSource = dt;
            rptYinxiang.DataBind();
        }

        protected void lbtnSupport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"].ToString();
                string _str = "http://" + Request.Url.Host + "/mobile/support.aspx?id=" + id;
                string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), _str, "state", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                Response.Redirect(url);
            }
        }

        protected void lbtnJoin_Click(object sender, EventArgs e)
        {
            Response.Redirect("baoming.aspx?pid=" + hfdParentOpenid.Value);
        }

        protected void lbtn_comment_list_Click(object sender, EventArgs e)
        {
            //string openid = hfdOpenid.Value;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("comment_list.aspx?id=" + Request.QueryString["id"].ToString());

                //string join_id = Request.QueryString["id"].ToString();
                //string sql = "select people_openid from action_join_people where id = " + join_id;
                //DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                //if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == openid)
                //{
                //    Response.Redirect("comment_list.aspx?id=" + Request.QueryString["id"].ToString() + "&openid=" + openid);
                //}
                //else
                //{
                //    Response.Redirect("comment_list.aspx?id=" + Request.QueryString["id"].ToString());
                //}
            }
        }

        /// <summary>
        /// 查看所有本队伍报名人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAllSeed_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfdId.Value))
            {
                string sql = "select * from action_join_people where id=" + hfdId.Value;
                DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string teamid = dt.Rows[0]["fk_team_id"].ToString();
                    Response.Redirect("join_list.aspx?teamid=" + teamid);
                }
            }
        }

        /// <summary>
        /// 绑定报名人员
        /// </summary>
        private void BindSeedVip()
        {
            if (!string.IsNullOrEmpty(hfdId.Value))
            {
                string sql = "select * from action_join_people where id=" + hfdId.Value;
                DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string teamid = dt.Rows[0]["fk_team_id"].ToString();
                    sql = "select top 10 * from action_join_people where fk_team_id = " + teamid + " order by careate_date desc";
                    dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        rptSeedVip.DataSource = dt;
                        rptSeedVip.DataBind();
                    }
                }
            }


        }

    }
}