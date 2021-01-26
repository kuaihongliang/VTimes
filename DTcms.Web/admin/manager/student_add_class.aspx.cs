using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.manager
{
    public partial class student_add_class : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Model.S_Student_Info model = new BLL.S_Student_Info().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    lblName.Text = model.st_name;
                    lblAmount.Text = model.account_amount.ToString();
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtClassCount.Text != "")
            {
                try
                {
                    int temp = Convert.ToInt32(txtClassCount.Text);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请填写正确的课时数！');", true);
                    return;
                }
                Model.S_Student_Info model = new BLL.S_Student_Info().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    model.account_amount += int.Parse(txtClassCount.Text);
                    new BLL.S_Student_Info().Update(model);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('添加课时完成！');ok();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请填写正确的课时数！');", true);
                return;
            }
        }
    }
}