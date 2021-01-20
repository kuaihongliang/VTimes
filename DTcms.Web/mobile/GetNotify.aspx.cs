using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;

namespace DTcms.Web.mobile
{
    public partial class GetNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NativeNotify nativeNatify = new NativeNotify(this);
            nativeNatify.ProcessNotify();
        }
    }
}