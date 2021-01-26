using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.admin.users
{
    public partial class user_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.users().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.U_User_Info bll = new BLL.U_User_Info();
            Model.U_User_Info model = bll.GetModel(_id);

            txtName.Text = model.user_name;
            txtCardnum.Text = model.user_cardnum;
            txtTelphone.Text = model.user_telphone;
            txtRemark.Text = model.user_remark;
            rblSex.SelectedValue = model.user_sex;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.U_User_Info model = new Model.U_User_Info();
            BLL.U_User_Info bll = new BLL.U_User_Info();

            model.account_amount = 0;
            model.user_name = txtName.Text;
            model.user_cardnum = txtCardnum.Text;
            model.user_sex = rblSex.SelectedValue;
            model.user_telphone = txtTelphone.Text;
            model.user_status = 1;
            model.user_remark = txtRemark.Text;
            model.create_time = DateTime.Now;
            model.last_pay_time = null;
            model.last_rechage_time = null;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加会员:" + model.user_name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.U_User_Info bll = new BLL.U_User_Info();
            Model.U_User_Info model = bll.GetModel(_id);

            model.user_name = txtName.Text;
            model.user_cardnum = txtCardnum.Text;
            model.user_sex = rblSex.SelectedValue;
            model.user_telphone = txtTelphone.Text;
            model.user_remark = txtRemark.Text;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改会员信息:" + model.user_name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("user_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改会员成功！", "user_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("user_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加会员成功！", "user_list.aspx");
            }
        }
    }
}