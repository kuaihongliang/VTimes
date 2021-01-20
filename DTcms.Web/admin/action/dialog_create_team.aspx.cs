using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.action
{
    public partial class dialog_create_team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"].ToString();
                string sql = "select * from action_join_people where id = " + id;
                DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sql = "insert into action_team values('" + txtName.Text.Trim() + "','" + dt.Rows[0]["people_openid"] + "','" + dt.Rows[0]["people_nickname"] + "',0) SELECT @@IDENTITY";
                    string team_id = DBUtility.DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString();
                    sql = "update action_join_people set fk_team_id = " + team_id + " where id=" + id;
                    DBUtility.DbHelperSQL.ExecuteSql(sql);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "ok()", true);
                }
            }
        }
    }
}