using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Threading;
using System.Web.Security;
using WxPayAPI;

namespace DTcms.Web.mobile
{
    public partial class JsApiPayPage : System.Web.UI.Page
    {
        public static string wxJsApiParam { get; set; } //H5调起JS API参数
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
            if (!IsPostBack)
            {
                try
                {
                    string openid = Request.QueryString["openid"];
                    string total_fee = Request.QueryString["total_fee"];
                    string inner_order = Request.QueryString["order"];
                    //检测是否给当前页面传递了相关参数
                    if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
                    {
                        Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面传参出错,请返回重试" + "</span>");
                        Log.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                        submit.Visible = false;
                        return;
                    }

                    //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                    JsApiPay jsApiPay = new JsApiPay(this);
                    jsApiPay.openid = openid;
                    decimal money = Convert.ToDecimal(total_fee) * 100;
                    jsApiPay.total_fee = Convert.ToInt32(money);

                    //JSAPI支付预处理
                    WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(inner_order);
                    wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数                    
                    Log.Debug(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                    //在页面上显示订单信息
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>支付金额：" + total_fee + "元</span><br/>");
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>");

                    lblInfo.Text = "支付金额：" + total_fee + "元";

                }
                catch (Exception ex)
                {
                    Log.Error(this.GetType().ToString(), "---" + ex.StackTrace.ToString() + "---" + ex.ToString());
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "下单失败，请返回重试" + "</span>");
                    //Response.Write("<span style='color:#FF0000;font-size:20px'>" + mm.ToString() + "</span>");
                    submit.Visible = false;
                }
            }
        }
    }
}