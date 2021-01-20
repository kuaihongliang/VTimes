<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comment_list.aspx.cs" Inherits="DTcms.Web.mobile.comment_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link href="style/style.css" rel="stylesheet" />
    <meta name="format-detection" content="telephone=no">
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
    <script type="text/javascript">
        function reply(id) {
            var current_openid = document.getElementById("hfdCurrentOpenid").value;
            var record_openid = document.getElementById("hfdRecordOpenid").value;
            var joinid = document.getElementById("hfdJoinid").value;
            if (current_openid == record_openid) {
                window.location.href = 'comment_reply.aspx?id=' + id + '&joinid=' + joinid;
            }
            else {
                return;
            }
        }
    </script>
    <title>留言评论区</title>
</head>
<body style="background: #F6F6F6;">
    <form id="form1" runat="server">
        <%--<asp:HiddenField ID="hfdIsMine" runat="server" />--%>
        <asp:HiddenField ID="hfdRecordOpenid" runat="server" />
        <asp:HiddenField ID="hfdCurrentOpenid" runat="server" />
        <asp:HiddenField ID="hfdJoinid" runat="server" />
        <div id="mainDiv" style="">
            <div style="position: fixed; top: 0; left: 0; width: 100%; background: #FFF; z-index: 3;">
                <div style="height: .5rem; line-height: .5rem; display: flex; width: 96%; margin-left: 2%;">
                    <div style="width: 50%; text-align: center; font-size: .14rem; font-weight: 600;">
                        <a href="javascript:void(0);" name="commentTab" style="padding: 5px 20px; color: #587ADC;" type="supporter" underlinetrans="0">好友留言</a>
                    </div>
                </div>
                <div>
                    <div id="underLineDiv" style="height: 2px; background: rgb(88, 122, 220); border-radius: 1px; width: 25%; margin-left: 12.5%; transform: translateX(0%); transition: all 0.5s ease;"></div>
                </div>
            </div>
            <div style="width: 100%; margin-top: .5rem;">
                <div class="targetDiv" name="supporterListDiv" style="min-height: 4rem; margin-top: .1rem; padding: 0 2%;">
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <div name="supportBlock" style="padding-top: .3rem;" jrsid="393559" onclick='reply(<%#Eval("id") %>)'>
                                <div style="width: 100%; display: flex; display: -webkit-flex; flex-direction: row; position: relative;">
                                    <div style="width: 20%; text-align: center; position: relative;">
                                        <div style="position: absolute; top: .25rem; transform: translateY(-50%);">
                                            <img src='<%#Eval("support_by_faceurl") %>' style="width: .4rem; height: .4rem; margin-top: .05rem; border-radius: 50%; border: .05rem solid #FFF;">
                                        </div>
                                    </div>
                                    <div style="width: 80%; background: #FFF; border-radius: .05rem; position: relative;" name="supportInfoDidv" onclick="reply()">
                                        <div style="height: .12rem; width: .12rem; background: #FFF; position: absolute; transform: rotate(45deg); top: 12%; left: -.05rem;"></div>
                                        <div style="height: .3rem; line-height: .3rem; display: flex; display: -webkit-flex; flex-direction: row;">
                                            <div style="width: 60%; margin-left: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="font-weight: 600; font-size: .12rem; color: #999;"><%#Eval("support_by_nickname") %></span>
                                            </div>
                                            <div style="width: 40%; text-align: right; margin-right: .1rem;">
                                                支持 <span style="font-size: .14rem; color: #D24417;"><%#Eval("support_money") %>元</span>
                                            </div>
                                        </div>
                                        <div style="display: flex; display: -webkit-flex;">
                                            <div style="width: 100%; text-align: left; padding: 0 .1rem;">
                                                <div style="line-height: .2rem;">
                                                    <span style="color: #333;"><%#Eval("bless_info") %></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="width: 100%; text-align: left; height: .3rem; line-height: .3rem; display: flex;">
                                            <div style="width: 50%;">
                                                <span style="margin-left: .1rem; color: #333; font-size: .1rem;"><%#Eval("support_date") %></span>
                                            </div>
                                            <div style="width: 50%; height: .3rem; position: relative;">
                                            </div>
                                        </div>
                                        <div style='height: .3rem; line-height: .3rem; flex-direction: row; background-color: #eeeeee; <%#Eval("reply_info").ToString()!=""?"display:block;": "display:none;" %>'>
                                            <div style="width: 60%; margin-left: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="font-weight: 600; font-size: .12rem; color: #999;"><%#Eval("people_name") %>：</span>
                                            </div>
                                        </div>
                                        <div style='background-color: #eeeeee; <%#Eval("reply_info").ToString()!=""?"display:block;": "display:none;" %>'>
                                            <div style="width: 100%; text-align: left; padding: 0 .1rem;">
                                                <div style="line-height: .2rem;">
                                                    <span style="color: #333;"><%#Eval("reply_info") %></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
