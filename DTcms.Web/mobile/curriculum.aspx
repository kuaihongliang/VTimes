﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="curriculum.aspx.cs" Inherits="DTcms.Web.mobile.curriculum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <link href="../../css/global.css" type="text/css" rel="stylesheet"/>
    <link href="../../css/table.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">
        function SetLab(hid) {
            var aa = document.getElementById(hid).value;
            document.getElementById('labCurriculumName').value = aa;
            autoLab();
        }
        function autoLab() {
            $('textarea').each(function () {
                this.setAttribute('style', 'height:' + (this.scrollHeight) + 'px;overflow-y:hidden;padding:0;border:0;background-color:White;');
            }).on('input', function () {
                this.style.height = 'auto';
                this.style.height = (this.scrollHeight) + 'px';
                this.style.width = '100%';
            });
        }
    </script>
    <title>V时代俱乐部课程</title>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdfOpenID" runat="server" />
  <div style="text-align:center;padding:0;background-color:White;">
    <asp:Calendar ID="CalPlan" runat="server"  BorderColor="#3366CC"
            CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="20px" 
            ForeColor="#708090" Height="100%" Width="100%" OnDayRender="CalPlan_DayRender" BorderWidth="1px" Font-Bold="True" NextMonthText="下月" PrevMonthText="上月" ShowGridLines="True" Title="会议日程">
            <SelectedDayStyle BackColor="White" Font-Bold="True" ForeColor="#CCFF99" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <SelectorStyle BackColor="#66AA77" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#FFA07A" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="12pt" ForeColor="#0000FF" />
            <DayHeaderStyle BackColor="#FFF5EE" Font-Bold="True" ForeColor="#336666" Height="50px" Font-Size="Large" />
            <TitleStyle BackColor="#FFF5EE" BorderColor="White" Font-Bold="True" BorderWidth="1px" Font-Size="Larger" ForeColor="#696969" Height="30px" />
        </asp:Calendar>
      <textarea id="labCurriculumName"  style="overflow:hidden; resize:none;width:100%;border:0;background-color:White; "  readonly="readonly"></textarea>
    </div>
    </form>
</body>

</html>
