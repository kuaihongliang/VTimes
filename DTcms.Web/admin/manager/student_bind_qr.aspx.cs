using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.manager
{
    public partial class student_bind_qr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    imgUrlQR.ImageUrl = "get_qr_code.ashx?id=" + Request.QueryString["id"];
                }
            }
        }
    }
}