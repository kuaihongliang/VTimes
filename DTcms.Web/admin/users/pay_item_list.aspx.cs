using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.users
{
    public partial class pay_item_list : System.Web.UI.Page
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
            DataTable dt = new BLL.P_Cost_Item().GetAllList().Tables[0];
            rptList1.DataSource = dt;
            rptList1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string tid = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                    new DTcms.BLL.P_Cost_Item().Delete(int.Parse(tid));
                }
            }
            BindData();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}