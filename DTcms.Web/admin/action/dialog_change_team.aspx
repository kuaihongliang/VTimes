<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_change_team.aspx.cs" Inherits="DTcms.Web.admin.action.dialog_change_team" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>变更队伍</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function ok() {
            var api = frameElement.api, W = api.opener;
            W.bind();
            api.close();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="div-content" style="min-height: 280px;">
            <dl>
                <dt>选择队伍</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlTeam" runat="server">
                        </asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <div>
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn yellow" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>
