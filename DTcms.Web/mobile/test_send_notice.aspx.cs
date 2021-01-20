using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.mobile
{
    public class TestTemplateData
    {
        public TemplateDataItem first { get; set; }
        public TemplateDataItem time { get; set; }
        public TemplateDataItem ip_list { get; set; }
        public TemplateDataItem sec_type { get; set; }
        public TemplateDataItem remark { get; set; }
    }

    public partial class test_send_notice : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string openId = "ou1fM1O00kUsfw8j2qyIoXXn1G8M";//换成已经关注用户的openId
        string templateId = "K2WtNl3zArzx3KsKGT2e3Ph7Fud64oIhMHC4XvUFoVA";//换成已经在微信后台添加的模板Id

        CommonApiTest ca = new CommonApiTest();
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string json = @"{
	           //                 {
		          //                  'value':'支持成功',
            //                        'color':'#173177'
            //                    }
            //                }
            //                订单号： {
	           //                 {
		          //                  'value':'order2020',
            //                        'color':'#173177'
	           //                 }
            //                }
            //                订单类型： {
	           //                 {
		          //                 'value':'活动',
            //                        'color':'#173177'
	           //                 }
            //                }
            //                商品名称： {
	           //                 {
		          //                  'value':'支持队员',
            //                        'color':'#173177'
	           //                 }
            //                }
            //                消费金额： {
	           //                 {
		          //                  'value':'100.00元',
            //                        'color':'#173177'
	           //                 }
            //                }
            //                消费时间： {
	           //                 {
		          //                  'value':'2020-1-30',
            //                        'color':'#173177'
	           //                 }
            //                } {
	           //                 {
		          //                  'value':'感谢您的支持！',
            //                        'color':'#173177'
	           //                 }
            //                }";
            var accessToken = AccessTokenContainer.GetAccessToken("wx9511a139072c5d5e");

            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem("支持成功！"),
                keyword1 = new TemplateDataItem("order2020"),
                keyword2 = new TemplateDataItem("活动"),
                keyword3 = new TemplateDataItem("支持队员"),
                keyword4 = new TemplateDataItem("100.00元"),
                keyword5 = new TemplateDataItem("2020-1-30"),
                remark = new TemplateDataItem("感谢您的支持！")
            };
            var result = TemplateApi.SendTemplateMessage(accessToken, "ou1fM1O00kUsfw8j2qyIoXXn1G8M", "K2WtNl3zArzx3KsKGT2e3Ph7Fud64oIhMHC4XvUFoVA", "#FF0000", "", testData);
            Response.Write(result.errcode);
        }
    }
}