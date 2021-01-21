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
        BLL.C_Curriculum bll = new BLL.C_Curriculum();
        private void ShowInfo()
        {
           this.labDate.Text = Convert.ToDateTime(ViewState["PlanDate"].ToString()).ToShortDateString();
           this.hdfTeacherID.Value = manager.id.ToString();
           this.txtTeacher.Text = manager.real_name;
           BindList();
        }
        private void BindList()
        {
            string where = " DateDiff(dd,CurriculumDate,'"+ ViewState["PlanDate"].ToString() + "')=0";
            DataTable dt = bll.GetList(where).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
        private bool IsCheck()
        {
            if (this.txtCurriculumName.Text.Trim() == "")
            {
                JscriptMsg("课程名称不能为空", "CurriculumEdit.aspx");
                //MessageBox.Show(this, "课程名称不能为空！");
                return false;
            }
           
            if (this.txtCurriculumDate.Text.Trim() == "")
            {
                JscriptMsg("课程日期不能为空", "CurriculumEdit.aspx");
                //MessageBox.Show(this, "项目名称不能为空！");
                return false;
            }
            
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.C_Curriculum model = new DTcms.Model.C_Curriculum();
            model.CurriculumName = this.txtCurriculumName.Text.Trim();
            model.CurriculumDate = Convert.ToDateTime(this.labDate.Text+" "+this.txtCurriculumDate.Text.Trim());
            model.CurriculumRemark = this.txtCurriculumRemark.Text.Trim();
            model.Teacher = txtTeacher.Text.Trim();
            model.TeacherID = int.Parse(hdfTeacherID.Value);
            model.State = 0;
            if (hdfID.Value == "")
            {
                bll.Add(model);
                JscriptMsg("添加成功", "CurriculumEdit.aspx");
            }
            else
            {
                model.ID = int.Parse(hdfID.Value);
                bll.Update(model);
                JscriptMsg("修改成功", "CurriculumEdit.aspx");
            }
            BindList();
            this.hdfID.Value = "";
            txtCurriculumName.Text = "";
            txtCurriculumRemark.Text ="";
            txtCurriculumDate.Text = "";
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script>window.close();window.opener.location.reload();</script>");//关闭时强制刷新父页面
        }
        protected void lbtnEditColumn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            Model.C_Curriculum model = bll.GetModel(int.Parse(id));
            this.hdfID.Value = model.ID.ToString();
            txtCurriculumName.Text = model.CurriculumName;
            txtCurriculumRemark.Text = model.CurriculumRemark;
            txtCurriculumDate.Text = Convert.ToDateTime(model.CurriculumDate).ToString("HH:mm");
           
        }

        protected void lbtnDelColumn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            bll.Delete(int.Parse(id));
            BindList();
        }
    }
}