using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.manager
{
    public partial class student_edit : Web.UI.ManagePage
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
            string sql = "select * from dt_manager where is_lock=0";

            Model.manager model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
            if (model.role_type != 1)
            {
                sql += " and id=" + model.id;
            }
            DataTable dt = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            ddl_teacher.DataSource = dt;
            ddl_teacher.DataTextField = "real_name";
            ddl_teacher.DataValueField = "id";
            ddl_teacher.DataBind();
        }

        private void GetData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Model.S_Student_Info model = new BLL.S_Student_Info().GetModel(int.Parse(Request.QueryString["id"]));
                if (model != null)
                {
                    txt_name.Text = model.st_name;
                    txt_tel.Text = model.st_telphone;
                    ddl_education.SelectedValue = model.st_education;
                    ddl_sex.SelectedValue = model.st_sex;
                    txt_nation.Text = model.st_nation;
                    txt_native.Text = model.st_native;
                    txt_age.Text = model.st_age;
                    txt_long.Text = model.st_long;
                    txt_weight.Text = model.st_weight;
                    txt_class.Text = model.st_class;
                    ddl_disease.SelectedValue = model.st_disease;
                    txt_school.Text = model.st_school;
                    txt_idcard.Text = model.st_idcard;
                    txt_ballage.Text = model.st_ballage;
                    txt_introducer.Text = model.st_introducer;
                    txt_remark.Text = model.st_remark;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Trim() == "")
            {
                JscriptMsg("请填写学员姓名！", "");
                return;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
            {
                Model.S_Student_Info model = new BLL.S_Student_Info().GetModel(int.Parse(Request.QueryString["id"]));

                model.st_name = txt_name.Text;
                model.st_telphone = txt_tel.Text;
                model.st_education = ddl_education.SelectedValue;
                model.st_sex = ddl_sex.SelectedValue;
                model.st_nation = txt_nation.Text;
                model.st_native = txt_native.Text;
                model.st_age = txt_age.Text;
                model.st_long = txt_long.Text;
                model.st_weight = txt_weight.Text;
                model.st_class = txt_class.Text;
                model.st_disease = ddl_disease.SelectedValue;
                model.st_school = txt_school.Text;
                model.st_idcard = txt_idcard.Text;
                model.st_ballage = txt_ballage.Text;
                model.st_introducer = txt_introducer.Text;
                model.st_remark = txt_remark.Text;

                if (new BLL.S_Student_Info().Update(model))
                {
                    JscriptMsg("修改学员信息成功！", "student_list.aspx");
                }
            }
            else//新增
            {
                Model.S_Student_Info model = new Model.S_Student_Info();
                model.st_name = txt_name.Text;
                model.st_telphone = txt_tel.Text;
                model.st_education = ddl_education.SelectedValue;
                model.st_sex = ddl_sex.SelectedValue;
                model.st_nation = txt_nation.Text;
                model.st_native = txt_native.Text;
                model.st_age = txt_age.Text;
                model.st_long = txt_long.Text;
                model.st_weight = txt_weight.Text;
                model.st_class = txt_class.Text;
                model.st_disease = ddl_disease.SelectedValue;
                model.st_school = txt_school.Text;
                model.st_idcard = txt_idcard.Text;
                model.st_ballage = txt_ballage.Text;
                model.st_introducer = txt_introducer.Text;
                model.st_remark = txt_remark.Text;
                model.FK_belong_teacher = int.Parse(ddl_teacher.SelectedValue);
                model.FK_class_level = null;
                model.st_status = 1;
                model.create_time = DateTime.Now;
                model.account_amount = 0;
                model.student_openid = null;
                if (new BLL.S_Student_Info().Add(model) > 0)
                {
                    JscriptMsg("添加学员信息成功！", "student_list.aspx");
                }

            }
        }
    }
}