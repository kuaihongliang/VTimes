<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baoming.aspx.cs" Inherits="DTcms.Web.mobile.baoming" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>报名</title>
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
    <script src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script language="javascript" type="text/javascript">
        var wait = 60;
        function time(btn) {
            if (wait == 60) {
                var partten = /^\d{10,13}$/;
                var phone = document.getElementById("txtPhoneNum").value
                if (!partten.test(phone)) {
                    alert('请输入正确的手机号码');
                    return;
                }
                $.ajax({
                    url: "sendSMS.ashx",
                    type: "get",
                    data: "phone=" + phone,
                })
                alert("验证码发送成功！");
                btn.setAttribute("disabled", true);
                btn.value = wait + "秒后重新获取验证码";
                wait--;
                setTimeout(function () {
                    time(btn);
                }, 1000)
            }
            else {
                if (wait == 0) {
                    btn.removeAttribute("disabled");
                    btn.value = "发送验证码";
                    wait = 60;
                } else {
                    btn.setAttribute("disabled", true);
                    btn.value = wait + "秒后重新获取验证码";
                    wait--;
                    setTimeout(function () {
                        time(btn);
                    }, 1000)
                }
            }
        }
        function check_txt() {
            if ($("#txtName").val() == "") {
                alert('请输入姓名！'); return false;
            }
            else if ($("#txtPhoneNum").val() == "") {
                alert('请输入手机号码！'); return false;
            }
            else if ($("#txtCode").val() == "") {
                alert('请输入验证码！'); return false;
            }
            else if ($("#txtCode").val().length != 6) {
                alert('验证码输入错误！'); return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body style="background: #FFF;">
    <form id="form1" runat="server">
        <div style="text-align: center; font-size: .15rem; height: .45rem; line-height: .45rem; background: #FFF;">
            绑定手机报名
        </div>
        <div style="background: #EAEAEA; height: .1rem;">
        </div>
        <div style="width: 86%; margin-left: 7%;">
            <div style="height: .45rem; border-bottom: 1px solid #EAEAEA;">
                <!-- 真实姓名 -->
                <asp:TextBox ID="txtName" runat="server" Style="margin-top: .05rem; border-radius: 0px; padding-left: 5px; background: transparent; height: .35rem; line-height: .35rem; width: 100%; border: 0; font-family: 微软雅黑; font-size: .14rem;" placeholder="请输入真实姓名"></asp:TextBox>
            </div>
            <div style="height: .45rem; border-bottom: 1px solid #EAEAEA; display: flex;">
                <div style="width: 20%; text-align: center; cursor: pointer;" id="chooseCodePre">
                    <p style="font-size: .14rem; height: .3rem; line-height: .3rem; cursor: pointer;">+<span id="codePreSpan">86</span></p>
                    <p style="font-size: .08rem; height: .1rem; line-height: .1rem; color: #CCC; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;" id="codePreNameSpan">中国</p>
                </div>
                <div style="width: 80%;">
                    <!-- 手机号码 -->
                    <asp:TextBox ID="txtPhoneNum" runat="server" type="tel" Style="margin-top: .05rem; border-radius: 0px; padding-left: 5px; background: transparent; height: .35rem; line-height: .35rem; width: 90%; border: 0; font-family: 微软雅黑; font-size: .14rem;" placeholder="请输入手机号"></asp:TextBox>
                </div>
            </div>
            <div style="height: .45rem; border-bottom: 1px solid #EAEAEA; position: relative;">
                <!-- 验证码 -->
                <asp:TextBox ID="txtCode" runat="server" Style="margin-top: .05rem; border-radius: 0px; padding-left: 5px; background: transparent; height: .35rem; line-height: .35rem; width: 50%; border: 0; font-family: 微软雅黑; font-size: .14rem;" placeholder="填写验证码"></asp:TextBox>
                <div style="position: absolute; right: 0; bottom: .07rem; display: inline-block; background: #587adc; height: .3rem; text-align: center; line-height: .3rem; width: 40%; border-radius: 4px;">
                    <input id="btnSend" type="button" value="发送验证码" onclick="time(this)" style="background: none; border: none; color: white; width: 100%; height: 100%; cursor: pointer;" />
                    <%--<a href="javascript:void(0);" id="sendYzm" style="color: #FFF;" onclick="time(this)">发送验证码</a>--%>
                </div>
            </div>
        </div>

        <div style="margin-top: .5rem;">
            <div style="margin-top: .3rem; width: 100%;">
                <div style="text-align: center;">
                    <%--<input type="checkbox" checked="checked" style="border: 1px solid #EAEAEA; position: relative; top: .03rem; border-radius: 5px;" />--%>
                    <span>*报名即表示您已阅读并同意</span>
                    <a href="#" id="" style="font-size: .14rem; margin-left: 5px; font-weight: bold;">《报名协议》</a>
                </div>
            </div>
            <div id="bind" style="width: 86%; margin-left: 7%; background: #587adc; border-radius: 4px; height: .4rem; line-height: .4rem; margin-top: .1rem; text-align: center; font-size: .16rem; color: #FFF; font-family: 微软雅黑; cursor: pointer;">
                <asp:Button ID="btnBaoming" runat="server" Text="绑定手机并报名" OnClientClick="return check_txt()" OnClick="btnBaoming_Click" Style="background: none; border: none; color: white; width: 100%; height: 100%; cursor: pointer;" />
            </div>
        </div>
        <div id="codePreSelector" style="display: none; position: fixed; top: 0; left: 0; right: 0; bottom: 0; overflow-y: scroll; background: #FFF; padding: 3%;">
        </div>
    </form>
</body>
</html>
