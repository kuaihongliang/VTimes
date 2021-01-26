using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.users
{
    public partial class user_recharge : Web.UI.ManagePage
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
                Model.U_User_Info model = new BLL.U_User_Info().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    lblName.Text = model.user_name;
                    lblAmount.Text = model.account_amount.ToString();
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Model.manager manager = GetAdminInfo();
            Model.U_User_Info model = new BLL.U_User_Info().GetModel(int.Parse(Request.QueryString["id"]));
            if (txtAmount.Text != "")
            {
                model.account_amount += Convert.ToDecimal(txtAmount.Text);
                new BLL.U_User_Info().Update(model);

                Model.U_User_Recharge record = new Model.U_User_Recharge();
                record.FK_user_id = model.user_id;
                record.recharge_user_name = model.user_name;
                record.recharge_type = 1;
                record.payment_type = ddl_payment_type.SelectedValue;
                record.recharge_amount = Convert.ToDecimal(txtAmount.Text);
                record.balance = model.account_amount;
                record.real_amount = Convert.ToDecimal(txtRealMoney.Text);
                record.rechage_time = DateTime.Now;
                record.create_by = manager.id;
                record.create_name = manager.real_name;
                record.recharge_remark = txtRemark.Text;
                new BLL.U_User_Recharge().Add(record);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('充值完成！');ok();", true);
            }
        }
    }
}