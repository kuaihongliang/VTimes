﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_cost.aspx.cs" Inherits="DTcms.Web.admin.users.user_cost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>会员消费</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //图片延迟加载
            $(".pic img").lazyload({ effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
        function ok() {
            var api = frameElement.api, W = api.opener;
            //W.bind();
            api.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div-content">
            <dl>
                <dt>会员姓名</dt>
                <dd>
                    <asp:Label ID="lblName" runat="server" Text="会员姓名"></asp:Label>
                    <asp:HiddenField ID="hfdId" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>当前账户余额</dt>
                <dd>
                    <asp:Label ID="lblAmount" runat="server" Text="当前账户余额"></asp:Label>
                </dd>
            </dl>

            <dl>
                <dt>选择消费项</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_cost_item" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_cost_item_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>消费金额</dt>
                <dd>
                    <asp:Label ID="lblCostMoney" runat="server" Text="消费金额"></asp:Label>
                </dd>
            </dl>
            <dl style="margin-top: 20px; margin-top: 50px;">
                <dt></dt>
                <dd>
                    <asp:Button ID="btnOK" runat="server" Text="确认消费" CssClass="btn yellow" OnClick="btnOK_Click" />
                </dd>
            </dl>
        </div>
    </form>
</body>
</html>
