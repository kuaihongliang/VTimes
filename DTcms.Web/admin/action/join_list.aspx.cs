using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using WxPayAPI;

namespace DTcms.Web.admin.action
{
    public partial class join_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                BindData();
            }
        }

        private void BindData()
        {
            string sql = @"select join_list.*,action_team.team_name 
                        ,(select people_name from action_join_people as temp where temp.people_openid = join_list.parent_openid) as parent_name
                        ,(select SUM(support_money) from action_support_people as support_t where support_t.support_to_openid = join_list.people_openid and is_pay_successed=1) as support_mney
                        from action_join_people as join_list
                        left join action_team on action_team.id = join_list.fk_team_id 
                        where 1=1";
            string where = "";
            if (txtName.Text.Trim() != "")
            {
                where += " and people_name like '%" + txtName.Text.Trim() + "%'";
            }
            if (txtNickName.Text.Trim() != "")
            {
                where += " and people_nickname like '%" + txtNickName.Text.Trim() + "%'";
            }
            if (txtTel.Text.Trim() != "")
            {
                where += " and mobile_phonenum = '" + txtTel.Text.Trim() + "'";
            }
            if (ddlTeam.SelectedValue != "-1")
            {
                where += " and fk_team_id=" + ddlTeam.SelectedValue;
            }
            sql += where;
            sql += " order by careate_date desc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList.DataSource = pds;
            rptList.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }


        private void BindDDL()
        {
            Model.manager model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
            string sql = "";
            if (model.role_type != 1)
            {
                sql = "select * from action_team where id = " + model.fk_team_id.ToString();
            }
            else
            {
                sql = "select * from action_team order by is_default desc";
            }

            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            ddlTeam.DataSource = dt;
            ddlTeam.DataValueField = "id";
            ddlTeam.DataTextField = "team_name";
            ddlTeam.DataBind();
            if (model.role_type == 1)
            {
                ddlTeam.Items.Insert(0, new ListItem("请选择", "-1"));
            }

        }

        protected void lbtnRefund_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument.ToString();
            string sql = "select * from action_join_people where id=" + id;
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            int re_count = 0;
            decimal total_money = 0;
            if (dt.Rows.Count > 0)
            {
                string people_openid = dt.Rows[0]["people_openid"].ToString();
                sql = "select * from action_support_people where support_to_openid = '" + people_openid + "' and is_pay_successed=1";
                dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string trade_num = dt.Rows[i]["inner_order_num"].ToString();
                        decimal money = Convert.ToDecimal(dt.Rows[i]["support_money"]);
                        total_money += money;
                        string support_id = dt.Rows[i]["id"].ToString();
                        int fee = Convert.ToInt32(money * 100);
                        try
                        {
                            string result = Refund.Run("", trade_num, fee.ToString(), fee.ToString());
                            System.Threading.Thread.Sleep(10);
                            sql = "update action_support_people set is_pay_successed=-1 where id=" + support_id;
                            int index = DBUtility.DbHelperSQL.ExecuteSql(sql);
                            re_count++;
                            //Response.Write("<span style='color:#00CD00;font-size:20px'>" + result + "</span>");
                        }
                        catch (WxPayException ex)
                        {
                            lblInfo.Text = ex.ToString();
                            //Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
                        }
                        catch (Exception ex)
                        {
                            lblInfo.Text = ex.ToString();
                            //Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
                        }
                    }
                    DBUtility.DbHelperSQL.ExecuteSql("update action_join_people set is_done=0,done_date=null where id=" + id);
                }
            }
            BindData();
            JscriptMsg("共退款" + re_count + "笔，总计" + total_money + "元", "");

        }
    }
}