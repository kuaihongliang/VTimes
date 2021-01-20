<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay_test.aspx.cs" Inherits="DTcms.Web.mobile.pay_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Style="color: #00CD00;"><b>商品一：价格为<span style="color:#f00;font-size:50px">1分</span>钱</b></asp:Label><br />
            <br />
        </div>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="立即购买" Style="width: 210px; height: 50px; border-radius: 15px; background-color: #00CD00; border: 0px #FE6714 solid; cursor: pointer; color: white; font-size: 16px;" OnClick="Button1_Click" />
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Style="color: #00CD00;"><b>商品二：价格为<span style="color:#f00;font-size:50px">2分</span>钱</b></asp:Label><br />
            <br />
        </div>
        <div align="center">
            <asp:Button ID="Button2" runat="server" Text="立即购买" Style="width: 210px; height: 50px; border-radius: 15px; background-color: #00CD00; border: 0px #FE6714 solid; cursor: pointer; color: white; font-size: 16px;" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
