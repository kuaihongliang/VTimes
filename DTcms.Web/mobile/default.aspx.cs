using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.mobile
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["teamid"]))
                {
                    string sql = "select * from action_team where is_default = 1";
                    DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string teamid = dt.Rows[0]["id"].ToString();
                        Response.Redirect("default.aspx?teamid=" + teamid);
                    }
                }
                else
                {
                    string sql = "select * from action_team where id = " + Request.QueryString["teamid"];
                    DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lblTeamName.Text = dt.Rows[0]["team_name"].ToString() + "-";
                        hfdParentOpenid.Value = dt.Rows[0]["team_captain_openid"].ToString();
                    }
                }
                BindSeedVip();
                GetData();

                BindSeedAll();
                BindSeedIng();
                BindSeedSuccess();
            }
        }

        private void GetData()
        {
            lblJoinCount.Text = DBUtility.DbHelperSQL.Query("select id from action_join_people where is_active = 1").Tables[0].Rows.Count.ToString();
            lblCommentCount.Text = DBUtility.DbHelperSQL.Query("select id from action_support_people where is_pay_successed = 1").Tables[0].Rows.Count.ToString();
        }

        protected void lbtnJoin_Click(object sender, EventArgs e)
        {
            Response.Redirect("baoming.aspx?pid=" + hfdParentOpenid.Value);
        }

        /// <summary>
        /// 绑定报名人员
        /// </summary>
        private void BindSeedVip()
        {
            string teamid = Request.QueryString["teamid"];
            string sql = "select top 10 * from action_join_people where fk_team_id = " + teamid + " order by careate_date desc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                rptSeedVip.DataSource = dt;
                rptSeedVip.DataBind();
            }
        }


        protected void lbtnAllSeed_Click(object sender, EventArgs e)
        {
            Response.Redirect("join_list.aspx?teamid=" + Request.QueryString["teamid"]);
        }

        private void BindSeedAll()
        {
            string teamid = Request.QueryString["teamid"];
            string sql = "select top 10 *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where fk_team_id = " + teamid + " order by support_money desc,careate_date asc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                rptSeedAll.DataSource = dt;
                rptSeedAll.DataBind();

                for (int i = 0; i < rptSeedAll.Items.Count; i++)
                {
                    Repeater rpt = rptSeedAll.Items[i].FindControl("rptChild") as Repeater;
                    HiddenField hfdopenid = rptSeedAll.Items[i].FindControl("hfdopenid") as HiddenField;

                    string _sql = "select * from action_support_people where is_pay_successed=1 and support_to_openid = '" + hfdopenid.Value + "'";
                    DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                    rpt.DataSource = _dt;
                    rpt.DataBind();
                }
            }
            sql = "select *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where fk_team_id = " + teamid + " order by support_money desc,careate_date asc";
            dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            lblAllcount.Text = dt.Rows.Count.ToString();
        }
        private void BindSeedIng()
        {
            string teamid = Request.QueryString["teamid"];
            string sql = "select top 10 *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where is_done = 0 and fk_team_id = " + teamid + " order by support_money desc,careate_date asc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                rptSeedIng.DataSource = dt;
                rptSeedIng.DataBind();

                for (int i = 0; i < rptSeedIng.Items.Count; i++)
                {
                    Repeater rpt = rptSeedIng.Items[i].FindControl("rptChild") as Repeater;
                    HiddenField hfdopenid = rptSeedIng.Items[i].FindControl("hfdopenid") as HiddenField;

                    string _sql = "select * from action_support_people where is_pay_successed=1 and support_to_openid = '" + hfdopenid.Value + "'";
                    DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                    rpt.DataSource = _dt;
                    rpt.DataBind();
                }
            }
            sql = "select *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where is_done = 0 and fk_team_id = " + teamid + " order by support_money desc,careate_date asc";
            dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            lblIngcount.Text = dt.Rows.Count.ToString();
        }
        private void BindSeedSuccess()
        {
            string teamid = Request.QueryString["teamid"];
            string sql = "select top 10 *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where is_done = 1 and fk_team_id = " + teamid + " order by done_date asc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                rptSeedSuccess.DataSource = dt;
                rptSeedSuccess.DataBind();

                for (int i = 0; i < rptSeedSuccess.Items.Count; i++)
                {
                    Repeater rpt = rptSeedSuccess.Items[i].FindControl("rptChild") as Repeater;
                    HiddenField hfdopenid = rptSeedSuccess.Items[i].FindControl("hfdopenid") as HiddenField;

                    string _sql = "select * from action_support_people where is_pay_successed=1 and support_to_openid = '" + hfdopenid.Value + "'";
                    DataTable _dt = DBUtility.DbHelperSQL.Query(_sql).Tables[0];
                    rpt.DataSource = _dt;
                    rpt.DataBind();
                }
            }
            sql = "select *,(select COUNT(*) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_count,(select SUM(support_money) from action_support_people where is_pay_successed=1 and support_to_openid = people_openid) as support_money from action_join_people where is_done = 1 and fk_team_id = " + teamid + " order by done_date asc";
            dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            lblSuccesscount.Text = dt.Rows.Count.ToString();
        }
    }
}
