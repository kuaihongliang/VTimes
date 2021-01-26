using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.users
{
    public partial class user_cost : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                GetData();
            }
        }

        private void BindDDL()
        {
            DataTable dt = new BLL.P_Cost_Item().GetAllList().Tables[0];
            ddl_cost_item.DataSource = dt;
            ddl_cost_item.DataTextField = "item_name";
            ddl_cost_item.DataValueField = "item_id";
            ddl_cost_item.DataBind();
            ddl_cost_item.Items.Insert(0, new ListItem("请选择", ""));
        }

        private void GetData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Model.U_User_Info model = new BLL.U_User_Info().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    lblName.Text = model.user_name;
                    lblAmount.Text = model.account_amount.ToString();
                }
            }
        }

        protected void ddl_cost_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_cost_item.SelectedValue != "")
            {
                Model.P_Cost_Item item = new BLL.P_Cost_Item().GetModel(int.Parse(ddl_cost_item.SelectedValue));
                if (item != null)
                {
                    lblCostMoney.Text = item.item_amount.ToString();
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ddl_cost_item.SelectedValue != "")
            {
                Model.manager manager = GetAdminInfo();
                Model.U_User_Info model = new BLL.U_User_Info().GetModel(int.Parse(Request.QueryString["id"]));
                Model.P_Cost_Item item = new BLL.P_Cost_Item().GetModel(int.Parse(ddl_cost_item.SelectedValue));
                if (model.account_amount >= item.item_amount)
                {
                    model.account_amount -= item.item_amount;
                    new BLL.U_User_Info().Update(model);

                    Model.U_User_Recharge record = new Model.U_User_Recharge();
                    record.FK_user_id = model.user_id;
                    record.recharge_user_name = model.user_name;
                    record.recharge_type = 1;
                    record.payment_type = null;
                    record.recharge_amount = item.item_amount;
                    record.balance = model.account_amount;
                    record.real_amount = null;
                    record.rechage_time = DateTime.Now;
                    record.create_by = manager.id;
                    record.create_name = manager.real_name;
                    record.recharge_remark = null;
                    new BLL.U_User_Recharge().Add(record);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('消费完成！');ok();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('余额不够，请确认！');", true);
                }
            }
        }
    }
}