using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.curriculum
{
    public partial class CurriculumEdit : DTcms.Web.UI.ManagePage
    {
        private DTcms.Model.manager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PlanDate"] = Request["PlanDate"];
                manager = Session[DTKeys.SESSION_ADMIN_INFO] as DTcms.Model.manager;
                ShowInfo();
            }
        }
        private void ShowInfo()
        {
           this.labDate.Text = Convert.ToDateTime(ViewState["PlanDate"].ToString()).ToShortDateString();
           this.hdfTeacherID.Value = manager.id.ToString();
           this.txtTeacher.Text = manager.real_name;
        }
    }
}