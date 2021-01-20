using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.mobile
{
    public partial class comment_reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnReply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (txtMsg.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请输入回复内容！');", true);
                }
                else
                {
                    string support_id = Request.QueryString["id"];
                    string joinid = Request.QueryString["joinid"];
                    string sql = "update action_support_people set reply_info = '" + txtMsg.Text + "' where id = " + support_id;
                    DBUtility.DbHelperSQL.ExecuteSql(sql);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('回复成功！');window.location.href='comment_list.aspx?id=" + joinid + "';", true);
                }
            }
        }
    }
}