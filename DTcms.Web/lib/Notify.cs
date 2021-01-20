using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DTcms.Web;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace WxPayAPI
{
    /// <summary>
    /// 回调处理基类
    /// 主要负责接收微信支付后台发送过来的数据，对数据进行签名验证
    /// 子类在此类基础上进行派生并重写自己的回调处理过程
    /// </summary>
    public class Notify
    {
        public Page page { get; set; }
        public Notify(Page page)
        {
            this.page = page;
        }

        CommonApiTest ca = new CommonApiTest();
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData GetNotifyData()
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = page.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            Log.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());

                string sql = "select support_to_openid,support_money,support_by_nickname,is_send_to_sopport,is_send_to_join,is_pay_successed,support_by_openid from action_support_people where inner_order_num = '" + data.GetValue("out_trade_no").ToString() + "'";
                DataTable dt = DTcms.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                string support_money = "0.00", support_name = "", support_to_name = "";
                string join_id = "-1";
                string joiner_openid = "", support_openid = "";

                bool is_send_to_sopport = false, is_send_to_join = false, is_pay_successed = false;
                if (dt != null && dt.Rows.Count > 0)
                {
                    joiner_openid = dt.Rows[0][0].ToString();
                    support_money = dt.Rows[0][1].ToString();
                    support_name = dt.Rows[0][2].ToString();
                    if (dt.Rows[0][3].ToString() == "1")
                    {
                        is_send_to_sopport = true;
                    }
                    if (dt.Rows[0][4].ToString() == "1")
                    {
                        is_send_to_join = true;
                    }
                    if (dt.Rows[0][5].ToString() == "1")
                    {
                        is_pay_successed = true;
                    }
                    support_openid = dt.Rows[0][6].ToString();
                }
                if (!is_pay_successed)
                {
                    sql = "update action_support_people set is_pay_successed = 1 where inner_order_num = '" + data.GetValue("out_trade_no").ToString() + "' and is_pay_successed=0";
                    DTcms.DBUtility.DbHelperSQL.ExecuteSql(sql);

                    sql = "select sum(support_money) from action_support_people where support_to_openid = '" + joiner_openid + "' and is_pay_successed=1";
                    dt = DTcms.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) && Convert.ToDecimal(dt.Rows[0][0].ToString()) >= globalField.target_money)
                    {
                        sql = "update action_join_people set is_done = 1,done_date = getdate() where people_openid = '" + joiner_openid + "'";
                        DTcms.DBUtility.DbHelperSQL.ExecuteSql(sql);
                    }
                    sql = "select people_name,id from action_join_people where people_openid =  '" + joiner_openid + "'";
                    dt = DTcms.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        support_to_name = dt.Rows[0][0].ToString();
                        join_id = dt.Rows[0][1].ToString();
                    }

                    var accessToken = AccessTokenContainer.GetAccessToken("wx9511a139072c5d5e");
                    //发送给支持者
                    if (!is_send_to_sopport)
                    {
                        var testData = new //TestTemplateData()
                        {
                            first = new TemplateDataItem("感谢您的支持！"),
                            keyword1 = new TemplateDataItem(data.GetValue("out_trade_no").ToString()),
                            keyword2 = new TemplateDataItem("“觉醒之路”首届商界精英茶马古道挑战赛"),
                            keyword3 = new TemplateDataItem("被支持人：" + support_to_name),
                            keyword4 = new TemplateDataItem(support_money + "元"),
                            keyword5 = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd")),
                            remark = new TemplateDataItem("感谢您的支持！")
                        };
                        string templateid = "K2WtNl3zArzx3KsKGT2e3Ph7Fud64oIhMHC4XvUFoVA";
                        string redirect_url = "http://" + "www.suzhoulvtu.cn" + "/mobile/index.aspx?id=" + join_id;
                        var result = TemplateApi.SendTemplateMessage(accessToken, support_openid, templateid, "#FF0000", redirect_url, testData);
                        sql = "update action_support_people set is_send_to_sopport = 1 where inner_order_num = '" + data.GetValue("out_trade_no").ToString() + "'";
                        DTcms.DBUtility.DbHelperSQL.ExecuteSql(sql);
                    }
                    //发送给被支持人
                    if (!is_send_to_join)
                    {
                        var testData = new //TestTemplateData()
                        {
                            first = new TemplateDataItem("您收到了他人的支持！"),
                            keyword1 = new TemplateDataItem(data.GetValue("out_trade_no").ToString()),
                            keyword2 = new TemplateDataItem("“觉醒之路”首届商界精英茶马古道挑战赛"),
                            keyword3 = new TemplateDataItem("支持人：" + support_name),
                            keyword4 = new TemplateDataItem(support_money + "元"),
                            keyword5 = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd")),
                            remark = new TemplateDataItem("感谢您的支持！")
                        };
                        string templateid = "K2WtNl3zArzx3KsKGT2e3Ph7Fud64oIhMHC4XvUFoVA";
                        string redirect_url = "http://" + "www.suzhoulvtu.cn" + "/mobile/index.aspx?id=" + join_id;
                        var result = TemplateApi.SendTemplateMessage(accessToken, joiner_openid, templateid, "#FF0000", redirect_url, testData);
                        sql = "update action_support_people set is_send_to_join = 1 where inner_order_num = '" + data.GetValue("out_trade_no").ToString() + "'";
                        DTcms.DBUtility.DbHelperSQL.ExecuteSql(sql);
                    }
                }

            }
            catch (Exception ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                Log.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            Log.Info(this.GetType().ToString(), "Check sign success");
            return data;
        }

        //派生类需要重写这个方法，进行不同的回调处理
        public virtual void ProcessNotify()
        {

        }
    }
}