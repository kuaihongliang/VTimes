using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.action
{
    public partial class team_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string sql = "select * from action_team where 1=1";
            string where = "";
            if (txtKeywords.Text.Trim() != "")
            {
                where += " and team_name like '%" + txtKeywords.Text.Trim() + "%'";
            }
            sql += where;
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0;
            int errorCount = 0;
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (DBUtility.DbHelperSQL.ExecuteSql("delete action_team where id = " + id.ToString()) > 0)
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            BindData();
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "");

        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}