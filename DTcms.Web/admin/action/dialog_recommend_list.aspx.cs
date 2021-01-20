using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.action
{
    public partial class dialog_recommend_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    BindData();
                }
            }
        }

        private void BindData()
        {
            string sql = "select * from action_join_people where parent_openid in (select people_openid from action_join_people where id = " + Request.QueryString["id"] + ")";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }
}