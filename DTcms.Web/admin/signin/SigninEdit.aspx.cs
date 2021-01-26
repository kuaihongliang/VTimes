using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.Web.admin.signin
{
    public partial class SigninEdit : DTcms.Web.UI.ManagePage
    {
        private DTcms.Model.manager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = "";
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    id = Request.QueryString["id"];
                if(id!="")
                {
                    this.hdfCurriculumID.Value = id;
                    ShowInfo(id);
                }
                manager = Session[DTKeys.SESSION_ADMIN_INFO] as DTcms.Model.manager;
                
            }
        }
        BLL.C_Curriculum bll = new BLL.C_Curriculum();
        BLL.S_Student_Info bllst = new BLL.S_Student_Info();
        private void ShowInfo(string id)
        {
            Model.C_Curriculum model = bll.GetModel(int.Parse(id));
            hdfCurriculumID.Value = model.ID.ToString();
            labCurriculumDate.Text = model.CurriculumDate.ToString();
            labCurriculumName.Text = model.CurriculumName;
            hdfTeacherID.Value = model.TeacherID.ToString();
            labTeacher.Text = model.Teacher;
            BindList(hdfTeacherID.Value);
        }
        private void BindList(string TeacherID)
        {
            DataTable dt = bllst.GetList("FK_belong_teacher='" + TeacherID + "' and account_amount>0 and st_id not in(select FK_Stid from C_Curriculum_Signin where FK_CurriculumID='" + hdfCurriculumID.Value + "')").Tables[0];
            this.listAllStudent.DataSource = dt;
            this.listAllStudent.DataTextField = "st_name";
            this.listAllStudent.DataValueField = "st_id";
            this.listAllStudent.DataBind();

            string sql = "select * from C_Curriculum_Signin where FK_CurriculumID='" + hdfCurriculumID.Value + "'";
            DataTable dt1= DbHelperSQL.Query(sql).Tables[0];
            this.listSignin.DataSource = dt1;
            this.listSignin.DataTextField = "st_name";
            this.listSignin.DataValueField = "FK_Stid";
            this.listSignin.DataBind();
        }

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            int count = this.listAllStudent.Items.Count;
            for (int i =0; i < this.listAllStudent.Items.Count ; i++)
            {
                if(this.listAllStudent.Items[i].Selected)
                {
                    ListItem newitem= new ListItem(listAllStudent.Items[i].Text, listAllStudent.Items[i].Value);
                    this.listSignin.Items.Add(newitem);
                }
            }
            for (int i = count - 1; i >= 0; i--)
            {
                if (this.listAllStudent.Items[i].Selected)
                {
                    this.listAllStudent.Items.Remove(this.listAllStudent.Items[i]);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            int count = this.listSignin.Items.Count;
            for (int i = 0; i< count; i++)
            {
                if (this.listSignin.Items[i].Selected)
                {
                    ListItem newitem = new ListItem(listSignin.Items[i].Text, listSignin.Items[i].Value);
                    this.listAllStudent.Items.Add(newitem);
                }
            }
            for (int i = count-1; i >=0 ; i--)
            {
                if (this.listSignin.Items[i].Selected)
                {
                    this.listSignin.Items.Remove(this.listSignin.Items[i]);
                }
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listAllStudent.Items.Count; i++)
            {
                ListItem newitem = new ListItem(listAllStudent.Items[i].Text, listAllStudent.Items[i].Value);
                this.listSignin.Items.Add(newitem);
            }
            this.listAllStudent.Items.Clear();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listSignin.Items.Count; i++)
            {
                string sql = "select * from C_Curriculum_Signin where FK_CurriculumID='"+ hdfCurriculumID.Value + "' and FK_Stid='"+ this.listSignin.Items[i].Value + "'";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    string insertupdate = "insert into C_Curriculum_Signin (FK_CurriculumID,FK_Stid,st_name) values ('" + hdfCurriculumID.Value + "','" + this.listSignin.Items[i].Value + "','" + this.listSignin.Items[i].Text + "');update S_Student_Info set account_amount=account_amount-1 where st_id='" + this.listSignin.Items[i].Value + "'";
                    DbHelperSQL.ExecuteSql(insertupdate);
                }
            }
            //JscriptMsg("签到成功", "SigninEdit.aspx");
            MessageBox.Show(this, "签到成功！");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script>window.close();window.opener.location.reload();</script>");
        }
    }
}