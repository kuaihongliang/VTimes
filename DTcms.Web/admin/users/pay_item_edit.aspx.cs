using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.users
{
    public partial class pay_item_edit : Web.UI.ManagePage
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
                Model.P_Cost_Item model = new BLL.P_Cost_Item().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    txtName.Text = model.item_name;
                    txtAmount.Text = model.item_amount.ToString();
                    txtRemark.Text = model.item_remark;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                JscriptMsg("请填写名称！", "");
                return;
            }
            else if (txtAmount.Text.Trim() == "")
            {
                JscriptMsg("请填写金额！", "");
                return;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
            {
                Model.P_Cost_Item model = new BLL.P_Cost_Item().GetModel(int.Parse(Request.QueryString["id"]));
                model.item_name = txtName.Text;
                model.item_amount = Convert.ToDecimal(txtAmount.Text);
                model.item_remark = txtRemark.Text;
                new BLL.P_Cost_Item().Update(model);
                JscriptMsg("修改成功", "pay_item_list.aspx");
            }
            else//新增
            {
                Model.P_Cost_Item model = new Model.P_Cost_Item();
                model.item_name = txtName.Text;
                model.item_amount = Convert.ToDecimal(txtAmount.Text);
                model.item_remark = txtRemark.Text;
                new BLL.P_Cost_Item().Add(model);
                JscriptMsg("添加成功", "pay_item_list.aspx");
            }
        }
    }
}