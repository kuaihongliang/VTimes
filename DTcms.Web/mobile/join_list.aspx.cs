using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.mobile
{
    public partial class join_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            string teamid = Request.QueryString["teamid"];
            string sql = "select * from action_join_people where fk_team_id = " + teamid + " order by careate_date asc";
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();

        }
    }
}