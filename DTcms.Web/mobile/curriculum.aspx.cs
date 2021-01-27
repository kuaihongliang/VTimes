using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using WxPayAPI;

namespace DTcms.Web.mobile
{
    public partial class curriculum : System.Web.UI.Page
    {
        protected string code;
        static Dictionary<string, OAuthAccessTokenResult> OAuthCodeCollection = new Dictionary<string, OAuthAccessTokenResult>();
        static object OAuthCodeCollectionLock = new object();
        CommonApiTest ca = new CommonApiTest();

        private DataTable arrCurrentDays;//, arrPreDays, arrNextDays;
        //三个整型数组存放相对月份写有plan的日期
        private int intCurrentMonth, intPreMonth, intNextMonth;
        private int intCurrentYear, intPreYear, intNextYear;
        //List<string> planName;//在日期下面显示有会议安排的标题
        string planTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OAuthAccessTokenResult result = null;
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string openId="";
                    code = Request.QueryString["code"].ToString();
                    try
                    {
                        //通过，用code换取access_token
                        var isSecondRequest = false;
                        lock (OAuthCodeCollectionLock)
                        {
                            isSecondRequest = OAuthCodeCollection.ContainsKey(code);
                        }
                        if (!isSecondRequest)
                        {
                            //第一次请求
                            lock (OAuthCodeCollectionLock)
                            {
                                OAuthCodeCollection[code] = null;
                            }
                        }
                        else
                        {
                            //第二次请求
                            lock (OAuthCodeCollectionLock)
                            {
                                result = OAuthCodeCollection[code];
                            }
                        }
                        try
                        {
                            var accessToken = AccessTokenContainer.GetAccessToken(ca._appId);
                            try
                            {
                                result = result ?? OAuthApi.GetAccessToken(ca._appId, ca._appSecret,code);
                                //txtComeDate.Text = result.errcode.ToString();
                            }
                            catch (Exception ex)
                            {
                                //txtComeDate.Text = ex.ToString();
                                //return Content("OAuth AccessToken错误：" + ex.Message);
                            }
                            if (result != null)
                            {
                                lock (OAuthCodeCollectionLock)
                                {
                                    OAuthCodeCollection[code] = result;
                                }
                                openId = result != null ? result.openid : "";
                                hdfOpenID.Value = openId;
                            }
                        }
                        catch (Senparc.Weixin.Exceptions.ErrorJsonResultException ex)
                        {
                            if (ex.JsonResult.errcode == ReturnCode.不合法的oauth_code)
                            {
                                //code已经被使用过
                                lock (OAuthCodeCollectionLock)
                                {
                                    result = OAuthCodeCollection[code];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //return Content("授权过程发生错误：" + ex.Message);
                    }
                }
                else
                {
                    
                    string _str = "http://" + Request.Url.Host + "/mobile/curriculum.aspx" ;
                    string url = OAuthApi.GetAuthorizeUrl(WxPayConfig.GetConfig().GetAppID(), _str, "state", Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                    Response.Redirect(url);
                }
            }
        }
        protected void CalPlan_DayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = ((DayRenderEventArgs)e).Day;
            TableCell c = ((DayRenderEventArgs)e).Cell;

            if (intPreMonth == 0)
            {
                //日历控件初始化时取得的是第一个月并不是当前月，而是前一个月的月份 
                if (d.Date.Month != DateTime.Now.Month)
                {
                    intPreMonth = d.Date.Month;
                    //if (intPreMonth == 12)
                    intPreYear = d.Date.Year;
                }
                else
                {
                    intPreMonth = DateTime.Now.Month;
                    intPreYear = DateTime.Now.Year;
                }
                intCurrentMonth = intPreMonth + 1;
                intCurrentYear = d.Date.Year;
                if (intCurrentMonth > 12)
                {
                    intCurrentMonth = 1;
                    intCurrentYear = intPreYear + 1;
                }
                intNextMonth = intCurrentMonth + 1;
                intNextYear = intCurrentYear;
                if (intNextMonth > 12)
                {
                    intNextMonth = 1;
                    intNextYear = intCurrentYear + 1;
                }
                //得到前一个月有plan的日期数组 
                //arrPreDays = getArrayDay(d.Date.Year, intPreMonth);
                //得到当月有plan的日期数组
                BLL.C_Curriculum bll = new C_Curriculum();
                arrCurrentDays = bll.GetList(intCurrentYear, intCurrentMonth,hdfOpenID.Value);
                //得到下个月有plan的日期数组
                //arrNextDays = getArrayDay(d.Date.Year, intNextMonth);
            }

            string strDate = d.Date.Year + "-" + d.Date.Month + "-" + d.Date.Day;

            string title = d.Date.Month.ToString() + "月" + d.Date.Day.ToString() + "日";//鼠标移上时显示相应的月日

            c.Controls.Clear();//绘制前先清除
            //打开新窗口传递参数.
            c.Controls.Add(new LiteralControl("<font  size = '3' > " + d.Date.Day + " <font>"));

            int j = 0;
            int Rownum = 0;
            if (d.Date.Month.Equals(intPreMonth))
            {
                c.Controls.Clear();//让上月日期不可见
            }
            else if (d.Date.Month.Equals(intCurrentMonth))
            {
                title = d.Date.Month.ToString() + "月" + d.Date.Day.ToString() + "日";//鼠标移上时显示相应的月日
                //=====若当月的会议次数为N，当月天数为M 则循环执行M*N次=============================//
                while (j < arrCurrentDays.Rows.Count)
                {
                    if (d.Date.Day.Equals(DateTime.Parse(arrCurrentDays.Rows[j]["CurriculumDate"].ToString()).Day)) //判断当前日期的第几天是否与日期数组中的某一个相等
                    {
                        Rownum++;
                        planTitle = "(" + Rownum.ToString() + ")" + arrCurrentDays.Rows[j]["CurriculumName"] + "<br />";//标题索引与天的索引是一一对应的
                        if(Rownum==1)
                        c.Controls.Clear();
                        //当前月有会议安排的日期并设置相应的字体格式于样式
                        c.BorderWidth = 1;
                        c.BorderColor = System.Drawing.Color.Red;
                        c.BackColor = System.Drawing.Color.Pink;
                        string txt = "课程名称："+ arrCurrentDays.Rows[j]["CurriculumName"].ToString()+ "\r\n";
                        txt += "课程时间："+ arrCurrentDays.Rows[j]["CurriculumDate"].ToString() + "\r\n";
                        txt += "授课教练：" + arrCurrentDays.Rows[j]["Teacher"].ToString() + "\r\n";
                        txt += "备注：" + arrCurrentDays.Rows[j]["CurriculumRemark"].ToString() + "\r\n";
                        if (Rownum == 1)
                            c.Controls.Add(new LiteralControl("<a href='#' onclick=javascript:SetLab('" + arrCurrentDays.Rows[j]["ID"].ToString() + "'" + ") title='" + title + "'><font color='blue' size='3'>" + d.Date.Day + "<font><br/><div style='text-align:center'><font color='blue' size='2'>" + planTitle + "<font></div></a><input type='hidden' id='" + arrCurrentDays.Rows[j]["ID"].ToString() + "' value='"+txt+"' />"));
                        else
                            c.Controls.Add(new LiteralControl("<a href='#' onclick=javascript:SetLab('" + arrCurrentDays.Rows[j]["ID"].ToString() + "'" + ") title='" + title + "'><div style='text-align:center'><font color='blue' size='2'>" + planTitle + "<font></div></a><input type='hidden' id='" + arrCurrentDays.Rows[j]["ID"].ToString() + "' value='" + txt + "' />"));
                    }
                    j++;
                }
                //每次循环后清空变量
                planTitle = string.Empty;
            }
            else if (d.Date.Month.Equals(intNextMonth))
            {
                c.Controls.Clear();//让下月日期不可见
            }
        }
    }
}