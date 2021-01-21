using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;

namespace DTcms.Web.admin.curriculum
{
    public partial class CurriculumList : DTcms.Web.UI.ManagePage
    {
        private List<int> arrCurrentDays;//, arrPreDays, arrNextDays;

        //三个整型数组存放相对月份写有plan的日期
        private int intCurrentMonth, intPreMonth, intNextMonth;
        private int intCurrentYear, intPreYear, intNextYear;
        //string[] planName = new string[999];//在日期下面显示有会议安排的标题
        List<string> planName;//在日期下面显示有会议安排的标题
        string planTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

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

                //intPreMonth = d.Date.Month;
                //if (d.Date.Month != DateTime.Now.Month)
                //    intCurrentMonth = intPreMonth + 1;
                //else
                //    intCurrentMonth = DateTime.Now.Month;
                //if (intCurrentMonth > 12)
                //{
                //    intCurrentMonth = 1;
                //}
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
                arrCurrentDays =bll.GetList(intCurrentYear, intCurrentMonth, out planName);
                //得到下个月有plan的日期数组
                //arrNextDays = getArrayDay(d.Date.Year, intNextMonth);
            }

            string strDate = d.Date.Year + "-" + d.Date.Month + "-" + d.Date.Day;

            string title = d.Date.Month.ToString() + "月" + d.Date.Day.ToString() + "日";//鼠标移上时显示相应的月日

            c.Controls.Clear();//绘制前先清除
            //打开新窗口传递参数.
            c.Controls.Add(new LiteralControl("<a href='#' onclick=javascript:OpenWin('CurriculumEdit.aspx?PlanDate=" + strDate + "'" + ",650,750,50,200) title='" + title + "'>" + d.Date.Day + "</a>"));

            int j = 0;
            int Rownum = 0;
            if (d.Date.Month.Equals(intPreMonth))
            {
                c.Controls.Clear();//让上月日期不可见
                //while (!arrPreDays[j].Equals(0))
                //{
                //    if (d.Date.Day.Equals(arrPreDays[j]))
                //    {
                //        //放置逻辑处理 
                //    }
                //    j++;
                //}
            }
            else
                if (d.Date.Month.Equals(intCurrentMonth))
            {
                title = d.Date.Month.ToString() + "月" + d.Date.Day.ToString() + "日";//鼠标移上时显示相应的月日
                                                                                    //IEnumerable<int> Days = from day in arrCurrentDays
                                                                                    //                        where day != 0 && d.Date.Day == day
                                                                                    //                        select day;

                //
                //foreach (int dd in Days)
                //{
                //    Rownum++;
                //    planTitle += "(" + Rownum.ToString() + ")" + planName[x] + "<br />";//如果能取到索引值可以使用下LINQ语句 像上面那样
                //    c.Controls.Clear();
                //    c.BorderWidth = 1;
                //    c.BorderColor = System.Drawing.Color.Red;
                //    c.BackColor = System.Drawing.Color.Pink;
                //    c.Controls.Add(new LiteralControl("<a href='#' onclick=javascript:OpenWin('ViewPlan.aspx?PlanDate=" + strDate + "'" + ",650,750,50,200) title='" + title + "'><font color='blue' size='3'>" + d.Date.Day + "<font><br/><div style='text-align:left'><font color='blue' size='2'>" + planTitle + "<font></div></a>"));
                //}
                //=====若当月的会议次数为N，当月天数为M 则循环执行M*N次=============================//
                while (!arrCurrentDays[j].Equals(0)) //没有会议对应的值即为整型数组的默认值0
                {
                    if (d.Date.Day.Equals(arrCurrentDays[j])) //判断当前日期的第几天是否与日期数组中的某一个相等
                    {
                        Rownum++;
                        planTitle += "(" + Rownum.ToString() + ")" + planName[j] + "<br />";//标题索引与天的索引是一一对应的
                        c.Controls.Clear();
                        //当前月有会议安排的日期并设置相应的字体格式于样式
                        c.BorderWidth = 1;
                        c.BorderColor = System.Drawing.Color.Red;
                        c.BackColor = System.Drawing.Color.Pink;
                        c.Controls.Add(new LiteralControl("<a href='#' onclick=javascript:OpenWin('CurriculumEdit.aspx?PlanDate=" + strDate + "'" + ",650,750,50,200) title='" + title + "'><font color='blue' size='3'>" + d.Date.Day + "<font><br/><div style='text-align:center'><font color='blue' size='2'>" + planTitle + "<font></div></a>"));
                    }
                    j++;
                }

                //每次循环后清空变量
                planTitle = string.Empty;
            }
            else if (d.Date.Month.Equals(intNextMonth))
            {
                c.Controls.Clear();//让下月日期不可见
                                   //while (!arrNextDays[j].Equals(0))
                                   //{
                                   //    if (d.Date.Day.Equals(arrNextDays[j]))
                                   //    {
                                   //放置逻辑处理  
                                   //    }
                                   //    j++;
                                   //}

            }

        }

        
    }
}