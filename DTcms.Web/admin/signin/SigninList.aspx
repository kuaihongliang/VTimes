<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SigninList.aspx.cs" Inherits="DTcms.Web.admin.signin.SigninList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/global.css" type="text/css" rel="stylesheet"/>
    <link href="../../css/table.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        function Open(url) {
            window.open(url, 'newwindow', 'height=700,width=650,top=1,left=120,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=auto,status=no')
        }

        function Open2(url) {
            window.open(url, 'newwindow', 'height=500,width=350,top=60,left=120,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no')
        }

        function OpenWin(url, h, w, top, left) {
            window.open(url, "newwindow", "height=" + h + ", width=" + w + ", top=" + top + ", left=" + left + ", toolbar=no, menubar=no, scrollbars=yes, location=no, status=no");
        }
        
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
  <div style="height:600px;padding:20px">
    <asp:Calendar ID="CalPlan" runat="server"  BorderColor="#3366CC"
            CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="20px"
            ForeColor="#708090" Height="100%" Width="90%" OnDayRender="CalPlan_DayRender" BorderWidth="1px" Font-Bold="True" NextMonthText="下月" PrevMonthText="上月" ShowGridLines="True" Title="会议日程">
            <SelectedDayStyle BackColor="White" Font-Bold="True" ForeColor="#CCFF99" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <SelectorStyle BackColor="#66AA77" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#FFA07A" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="12pt" ForeColor="#0000FF" />
            <DayHeaderStyle BackColor="#FFF5EE" Font-Bold="True" ForeColor="#336666" Height="50px" Font-Size="Large" />
            <TitleStyle BackColor="#FFF5EE" BorderColor="White" Font-Bold="True" BorderWidth="1px" Font-Size="Larger" ForeColor="#696969" Height="30px" />
        </asp:Calendar>
    </div>
    </form>
</body>
</html>

