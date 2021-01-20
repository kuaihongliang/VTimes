<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="support.aspx.cs" Inherits="DTcms.Web.mobile.support" %>

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
    <script>
        function fill_money(price) {
            $("#txtMoney").val(price);
        }
    </script>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
        <div id="mainDiv" style="width: 100%; position: relative;">
            <div style="margin-top: .1rem; margin-bottom: 1rem;">
                <div style="width: 96%; margin-left: 2%;">
                    <div style="height: .4rem; line-height: .4rem; font-size: .14rem; border-bottom: 1px solid #EAEAEA;">
                        支持金额<span id="maxAmtOnceSpan" style="color: #D24417;"><%--（* 单次最大支持金额￥3000元）--%></span>
                    </div>
                    <div id="supportAmtConfigDiv">
                        <div style="display: -webkit-flex; display: flex; flex-wrap: wrap; justify-content: space-between; height: 1.1rem; line-height: .4rem;">
                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="88" name="chooseSupportAmt" style="padding: 6px 20px;" onclick="fill_money(88)">￥88元</a>
                            </div>

                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="108" name="chooseSupportAmt" style="padding-top: 6px;" onclick="fill_money(108)">￥108元</a>
                            </div>

                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="188" name="chooseSupportAmt" style="padding-top: 6px;" onclick="fill_money(188)">￥188元</a>
                            </div>

                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="520" name="chooseSupportAmt" style="padding-top: 6px;" onclick="fill_money(520)">￥520元</a>
                            </div>

                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="888" name="chooseSupportAmt" style="padding-top: 6px;" onclick="fill_money(888)">￥888元</a>
                            </div>
                            <div name="supprtAmtConfigDiv" style=".4rem; width: 30%; border: 1px solid #EAEAEA; margin-top: .15rem; text-align: center; font-size: .14rem; border-radius: 5px; background: #FFF;">
                                <a href="javascript:void(0);" supportamt="1314" name="chooseSupportAmt" style="padding-top: 6px;" onclick="fill_money(1314)">￥1314元</a>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top: .25rem;">
                        <asp:TextBox ID="txtMoney" runat="server" onkeyup="value=value.replace(/[^\d+(\.\d+)]/g,'')" Style="-webkit-appearance: none; height: .4rem; width: 98%; border: 1px solid #EAEAEA; border-radius: 5px; padding-left: 5px; font-family: 微软雅黑" placeholder="其他金额"></asp:TextBox>
                    </div>
                    <div style="width: 100%">
                        <div style="height: .4rem; line-height: .4rem; font-size: .14rem;">给小伙伴留言</div>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Style="-webkit-appearance: none; border: 1px solid #EAEAEA; resize: none; height: .7rem; border-radius: 5px; width: 95%; padding: .07rem; font-family: 微软雅黑" placeholder="【希望我的一份支持，能成为你坚持下去的一份动力，加油！】"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 100%;">
                        <div style="height: .4rem; line-height: .4rem; font-size: .14rem;">如方便，留下您的联系方式（方便众筹者答谢）</div>
                        <div style="width: 100%;">
                            <asp:TextBox ID="txt_support_phone" runat="server" type="tel" Style="-webkit-appearance: none; height: .4rem; width: 98%; border: 1px solid #EAEAEA; border-radius: 5px; padding-left: 5px; font-family: 微软雅黑" placeholder="您的手机号码"></asp:TextBox>
                        </div>
                        <div style="width: 100%; margin-top: .1rem;">
                            <asp:TextBox ID="txt_support_name" runat="server" type="text" Style="-webkit-appearance: none; height: .4rem; width: 98%; border: 1px solid #EAEAEA; border-radius: 5px; padding-left: 5px; font-family: 微软雅黑" placeholder="您的姓名"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div id="bottomDiv" style="height: .5rem; line-height: .5rem; position: fixed; bottom: 0; left: 0; width: 100%; border-top: 1px #EAEAEA solid; display: -webkit-flex; display: flex;">
                <div style="width: 60%; font-size: .14rem; background: #FFF;">
                    <%-- <span style="margin-left: 5px;">合计金额：</span>
                    <span style="color: #D24417;">￥<span id="supportAmtSpan">0</span>元</span>--%>
                </div>
                <div style="width: 40%; text-align: center; background: #D24417;">
                    <asp:LinkButton ID="lbtnPay" runat="server" Style="font-size: .14rem; font-weight: 600; color: #FFF; padding: .1rem .2rem;" OnClick="lbtnPay_Click">立即付款</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
