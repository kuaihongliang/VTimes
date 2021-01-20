<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsApiPayPage.aspx.cs" Inherits="DTcms.Web.mobile.JsApiPayPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>确认支付</title>
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
    <link href="style/style.css" rel="stylesheet" />
</head>

<script type="text/javascript">
    //调用微信JS api 支付
    function jsApiCall()
    {
        WeixinJSBridge.invoke(
        'getBrandWCPayRequest',
        <%=DTcms.Web.mobile.JsApiPayPage.wxJsApiParam%>,//josn串
                    function (res)
                    {
                        alert("支付完成");
                        window.location.href='default.aspx';
                        //WeixinJSBridge.log(res.err_msg);
                        //alert(res.err_code + res.err_desc + res.err_msg);
                    }
                    );
    }

    function callpay()
    {
        if (typeof WeixinJSBridge == "undefined")
        {
            if (document.addEventListener)
            {
                document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
            }
            else if (document.attachEvent)
            {
                document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
            }
        }
        else
        {
            jsApiCall();
        }
    }      
</script>

<body>
    <form runat="server">
        <div style="text-align: center; font-size: .15rem; height: .45rem; line-height: .45rem; background: #FFF;">
            确认支付订单
        </div>
        <div style="margin-top: .5rem;">
            <div style="width: 100%;">
                <div style="text-align: center;">
                    <span style="font-size: 20px;">
                        <asp:Label ID="lblInfo" runat="server" Text="订单金额："></asp:Label></span>
                </div>
            </div>
            <div id="bind" style="width: 86%; margin-left: 7%; background: #587adc; border-radius: 4px; height: .4rem; line-height: .4rem; margin-top: .1rem; text-align: center; font-size: .16rem; color: #FFF; font-family: 微软雅黑; cursor: pointer;">
                <asp:Button ID="submit" runat="server" Text="立即支付" OnClientClick="callpay()" Style="background: none; border: none; color: white; width: 100%; height: 100%; cursor: pointer;" />
                <%--<asp:Button ID="submit" runat="server" Text="立即支付" OnClientClick="callpay()" Style="background: none; border: none; color: white; width: 100%; height: 100%; cursor: pointer;" />--%>
            </div>
        </div>
        <div>

            <div style="margin-top: .3rem; width: 100%;">
                <div style="text-align: center;">
                    <span>请扫描下方二维码，关注我们的公众号</span>
                </div>
                <div style="text-align: center;">
                    <img src="image/qrcode_for_gh_6cc5dbf54e3f_344.jpg" width="80%" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
