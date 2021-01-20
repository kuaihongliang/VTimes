using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.action
{
    public partial class dialog_change_team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        private void BindDDL()
        {
            string sql = "select * from action_team order by is_default desc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            ddlTeam.DataSource = dt;
            ddlTeam.DataValueField = "id";
            ddlTeam.DataTextField = "team_name";
            ddlTeam.DataBind();

            ddlTeam.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];
                if (ddlTeam.SelectedValue != "-1")
                {
                    string sql = "update action_join_people set fk_team_id = " + ddlTeam.SelectedValue + " where id=" + id;
                    DBUtility.DbHelperSQL.ExecuteSql(sql);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "ok()", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请选择队伍！')", true);
                    return;
                }
            }
        }
    }
}