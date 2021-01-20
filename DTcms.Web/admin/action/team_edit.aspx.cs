using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.action
{
    public partial class team_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetData();
                }
            }
        }

        private void GetData()
        {
            string sql = "select * from action_team where id = " + Request.QueryString["id"].ToString();
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTitle.Text = dt.Rows[0]["team_name"].ToString();
                txtNickName.Text = dt.Rows[0]["team_captain_nickname"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string sql = "update action_team set team_name = '" + txtTitle.Text + "' where id = " + Request.QueryString["id"];
            }
        }
    }
}