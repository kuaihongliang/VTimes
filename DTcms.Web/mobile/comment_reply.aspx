<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comment_reply.aspx.cs" Inherits="DTcms.Web.mobile.comment_reply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link href="style/style.css" rel="stylesheet" />
    <meta name="format-detection" content="telephone=no">
    <script src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <title>支持</title>
    <style id="__WXWORK_INNER_SCROLLBAR_CSS">
        ::-webkit-scrollbar {
            width: 12px !important;
            height: 12px !important;
        }

        ::-webkit-scrollbar-track:vertical {
        }

        ::-webkit-scrollbar-thumb:vertical {
            background-color: rgba(136, 141, 152, 0.5) !important;
            border-radius: 10px !important;
            background-clip: content-box !important;
            border: 2px solid transparent !important;
        }

        ::-webkit-scrollbar-track:horizontal {
        }

        ::-webkit-scrollbar-thumb:horizontal {
            background-color: rgba(136, 141, 152, 0.5) !important;
            border-radius: 10px !important;
            background-clip: content-box !important;
            border: 2px solid transparent !important;
        }

        ::-webkit-resizer {
            display: none !important;
        }
    </style>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
        <div id="mainDiv" style="width: 100%; position: relative;">
            <div style="margin-top: .1rem; margin-bottom: 1rem;">
                <div style="width: 96%; margin-left: 2%;">
                    <div style="width: 100%">
                        <div style="height: .4rem; line-height: .4rem; font-size: .14rem;">答谢支持者</div>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Style="-webkit-appearance: none; border: 1px solid #EAEAEA; resize: none; height: .7rem; border-radius: 5px; width: 95%; padding: .07rem; font-family: 微软雅黑">谢谢您的支持！</asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div id="bottomDiv" style="height: .5rem; line-height: .5rem; position: fixed; bottom: 0; left: 0; width: 100%; border-top: 1px #EAEAEA solid; display: -webkit-flex; display: flex;">
                <div style="width: 60%; font-size: .14rem; background: #FFF;">
                </div>
                <div style="width: 40%; text-align: center; background: #587ADC;">
                    <asp:LinkButton ID="lbtnReply" runat="server" Style="font-size: .14rem; font-weight: 600; color: #FFF; padding: .1rem .2rem;" OnClick="lbtnReply_Click">回复</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
