<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DTcms.Web.mobile.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>“觉醒之路”首届商界精英茶马古道挑战赛</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <link href="style/style.css" rel="stylesheet" />
    <script src="../scripts/jquery/jquery-1.11.2.min.js"></script>
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
    <style>
        .swiper-container {
            width: 100%;
            height: 100%;
        }

        .swiper-slide {
            text-align: center;
            font-size: 18px;
            background: #fff;
            /* Center slide text vertically */
            display: -webkit-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
            -webkit-box-pack: center;
            -ms-flex-pack: center;
            -webkit-justify-content: center;
            justify-content: center;
            -webkit-box-align: center;
            -ms-flex-align: center;
            -webkit-align-items: center;
            align-items: center;
        }
    </style>
    <script>
        function show(id) {
            if (id == 1) {
                $("#projectDescDivF").css("display", "block");
                $("#joinReadDivF").css("display", "none");
                $("#projectDeptDivF").css("display", "none");
                $("#teamInfoDivF").css("display", "none");

                $("#pDetailA").css("color", "rgb(88, 122, 188)");
                $("#pDetailB").css("color", "rgb(51, 51, 51)");
                $("#pDetailC").css("color", "rgb(51, 51, 51)");
                $("#pDetailD").css("color", "rgb(51, 51, 51)");
            }
            else if (id == 2) {
                $("#projectDescDivF").css("display", "none");
                $("#joinReadDivF").css("display", "block");
                $("#projectDeptDivF").css("display", "none");
                $("#teamInfoDivF").css("display", "none");

                $("#pDetailA").css("color", "rgb(51, 51, 51)");
                $("#pDetailB").css("color", "rgb(88, 122, 188)");
                $("#pDetailC").css("color", "rgb(51, 51, 51)");
                $("#pDetailD").css("color", "rgb(51, 51, 51)");
            }
            else if (id == 3) {
                $("#projectDescDivF").css("display", "none");
                $("#joinReadDivF").css("display", "none");
                $("#projectDeptDivF").css("display", "block");
                $("#teamInfoDivF").css("display", "none");

                $("#pDetailA").css("color", "rgb(51, 51, 51)");
                $("#pDetailB").css("color", "rgb(51, 51, 51)");
                $("#pDetailC").css("color", "rgb(88, 122, 188)");
                $("#pDetailD").css("color", "rgb(51, 51, 51)");
            }
            else if (id == 4) {
                $("#projectDescDivF").css("display", "none");
                $("#joinReadDivF").css("display", "none");
                $("#projectDeptDivF").css("display", "none");
                $("#teamInfoDivF").css("display", "block");

                $("#pDetailA").css("color", "rgb(51, 51, 51)");
                $("#pDetailB").css("color", "rgb(51, 51, 51)");
                $("#pDetailC").css("color", "rgb(51, 51, 51)");
                $("#pDetailD").css("color", "rgb(88, 122, 188)");
            }
        }

        function list(id) {
            if (id == 1) {
                $("#list1").css("display", "block");
                $("#list2").css("display", "none");
                $("#list3").css("display", "none");
                $("#rankTabUnderLine").css("margin-left", "0%");
            }
            else if (id == 2) {
                $("#list1").css("display", "none");
                $("#list2").css("display", "block");
                $("#list3").css("display", "none");
                $("#rankTabUnderLine").css("margin-left", "33.33%");
            }
            else if (id == 3) {
                $("#list1").css("display", "none");
                $("#list2").css("display", "none");
                $("#list3").css("display", "block");
                $("#rankTabUnderLine").css("margin-left", "66.66%");
            }
        }

        function more(obj) {
            $(obj).css("display", "none");
            $(obj).parent().find(".lessDetail").css("display", "block");
            $(obj).parent().find(".main_content").css("height", "");
        }
        function less(obj) {
            $(obj).css("display", "none");
            $(obj).parent().find(".moreDetail").css("display", "block");
            $(obj).parent().find(".main_content").css("height", "500px");
        }
    </script>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.6.0.js"></script>
    <script type="text/javascript">
        $(function () {
            var a = document.getElementById("hfdappid").value;
            var b = document.getElementById("hfdtimestamp").value;
            var c = document.getElementById("hfdnonceStr").value;
            var d = document.getElementById("hfdSignature").value;

            var _id = document.getElementById("hfdId").value;
            var _link = "http://www.suzhoulvtu.cn/mobile/index.aspx?id=" + _id;
            wx.config({
                beta: true, // 必须这么写，否则wx.invoke调用形式的jsapi会有问题
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: a, // 必填，企业微信的corpID
                timestamp: b, // 必填，生成签名的时间戳
                nonceStr: c, // 必填，生成签名的随机串
                signature: d, // 必填，签名，见 附录-JS-SDK使用权限签名算法
                jsApiList: ['updateAppMessageShareData', 'updateTimelineShareData'] // 必填，需要使用的JS接口列表，凡是要调用的接口都需要传进来
            });

            wx.ready(function () {
                // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，
                //所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
                wx.updateAppMessageShareData({
                    title: '“觉醒之路”首届商界精英茶马古道挑战赛', // 分享标题
                    desc: '为什么一定要到茶马古道徒步？一生至少一次，一次影响一生。', // 分享描述
                    //link: window.location.href, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                    link: "http://www.suzhoulvtu.cn/mobile/index.aspx?id=" + _id,
                    imgUrl: 'http://www.suzhoulvtu.cn/mobile/image/logo2.png', // 分享图标
                    success: function () {
                        // 设置成功
                        //alert('分享设置成功1:' + _link);
                    }
                })
                wx.updateTimelineShareData({
                    title: '“觉醒之路”首届商界精英茶马古道挑战赛', // 分享标题
                    //link: window.location.href, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                    link: "http://www.suzhoulvtu.cn/mobile/index.aspx?id=" + _id,
                    imgUrl: 'http://www.suzhoulvtu.cn/mobile/image/logo2.png', // 分享图标
                    success: function () {
                        // 设置成功
                        //alert('分享设置成功2:' + _link);
                    }
                })
            });
            wx.error(function (res) {
                alert('分享设置失败：' + res);
                // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
            });
        });

    </script>
</head>
<body style="background: #F6F6F6;">
    <img src="image/logo2.png" style="width: 80%; display: none;" />
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfdappid" runat="server" />
        <asp:HiddenField ID="hfdtimestamp" runat="server" />
        <asp:HiddenField ID="hfdnonceStr" runat="server" />
        <asp:HiddenField ID="hfdSignature" runat="server" />

        <%--<asp:HiddenField ID="hfdOpenid" runat="server" />--%>

        <asp:HiddenField ID="hfdId" runat="server" />
        <div id="mainDiv" style="background: #FFF; /* margin-top: .4rem; */">
            <%--顶部图片--%>
            <div id="manifestoWithBgDiv">
                <div style="display: flex; justify-content: space-between; margin-bottom: .05rem; width: 100%;">
                    <!-- Swiper -->
                    <div class="swiper-container" style="z-index: 0;">
                        <div class="swiper-wrapper">
                            <div class="swiper-slide">
                                <img src="images/云南茶马古道_01.gif" width="100%" />
                            </div>
                            <%--<div class="swiper-slide">
                                <img src="image/t2.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="image/t3.jpg" width="100%" />
                            </div>--%>
                        </div>
                        <!-- Add Arrows -->
                        <div class="swiper-button-next"></div>
                        <div class="swiper-button-prev"></div>
                    </div>
                    <!-- Swiper JS -->
                    <script src="dist/js/swiper.min.js"></script>
                    <!-- Initialize Swiper -->
                    <script>
                        var swiper = new Swiper('.swiper-container', {
                            navigation: {
                                nextEl: '.swiper-button-next',
                                prevEl: '.swiper-button-prev',
                            },
                        });
                    </script>
                </div>
            </div>
            <%--我的众筹信息--%>
            <div id="projectBusi">
                <div id="" style="width: 96%; margin-left: 2%;">
                    <div style="height: .4rem; line-height: .4rem; display: flex; display: -webkit-flex; flex-direction: row; position: relative;">
                        <div style="width: 30%; fon-size: .14rem; display: flex; display: -webkit-flex; align-items: center">
                            <asp:Image ID="img_face" runat="server" Style="height: .5rem; border-radius: 50%; z-index: 1; position: relative; bottom: .1rem; left: .1rem; border: 2px solid #FFF;" />
                        </div>
                        <div style="width: 40%; font-size: .14rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                            <p style="line-height: .2rem; font-size: .14rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                <asp:Label ID="lblSeedName" runat="server" Text="Label"></asp:Label>
                            </p>
                            <p style="line-height: .2rem; color: #CCC; font-size: .1rem;">
                                <asp:Label ID="lbl_join_date" runat="server" Text="2020-1-1"></asp:Label>创建
                            </p>
                        </div>
                        <div style="width: 30%; text-align: right; font-size: .14rem; color: #999;">
                            剩余<span style="color: #D24417; font-size: .14rem;"><asp:Label ID="lbl_rest_day" runat="server" Text="365"></asp:Label></span>天
                        </div>
                    </div>
                </div>
                <div style="line-height: .3rem; height: .3rem; width: 94%; margin-left: 3%; font-size: .16rem; font-weight: 700; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                    <span style="color: #587ADC;">
                        <asp:Label ID="lblTeamName" runat="server" Text="绿徒联盟"></asp:Label></span>“觉醒之路”首届商界精英茶马古道挑战赛
                </div>
                <div id="processBarDiv" style="height: .25rem; line-height: .25rem; width: 90%; margin-left: 3%; display: flex; display: -webkit-flex; flex-direction: row; padding: 0 .07rem; border-radius: .15rem; margin-top: .1rem; margin-bottom: .1rem; position: relative;">
                    <div style="width: 100%; height: .25rem; line-height: .25rem; position: relative; margin-top: .075rem; overflow-x: hidden;">
                        <div style="height: .1rem; border-radius: .05rem; width: 100%; position: absolute; left: 0; background: #CCC;"></div>
                        <div id="processBar" runat="server" style="height: 0.1rem; border-radius: 0.05rem; position: absolute; left: 0; background: rgb(88, 122, 220);"></div>
                    </div>
                    <div id="highlightPercent" runat="server" style="height: .2rem; line-height: .2rem; width: .42rem; border-radius: .08rem; position: absolute; background: #587ADC; top: .025rem; text-align: center; color: #FFF;">
                        <asp:Label ID="lbl_done_per" runat="server" Text="0%"></asp:Label>
                    </div>
                </div>
                <div style="display: flex; display: -webkit-flex; flex-direction: row; height: .6rem; line-height: .6rem; border: 1px solid #EAEAEA;">
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">￥<asp:Label ID="lblTargetMoney" runat="server" Text="13800"></asp:Label></p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">目标金额</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">￥<asp:Label ID="lbl_rest_money" runat="server" Text="0"></asp:Label>元</p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">剩余金额</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lbl_comment_count2" runat="server" Text="0"></asp:Label>人
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">支持人数</p>
                        </div>
                    </div>
                </div>
            </div>
            <%--报名人--%>
            <div id="seedJoinList">
                <div style="width: 90%; margin-left: 5%; position: relative;">
                    <div style="height: .3rem; line-height: .3rem; text-align: center; font-size: .16rem; margin-top: .1rem; position: relative;">
                        <span style="font-weight: 700;">种子队友</span>
                        <asp:LinkButton ID="lbtnAllSeed" runat="server" OnClick="lbtnAllSeed_Click" Style="position: absolute; right: 0; font-size: .12rem; color: #587adc;">查看全部&gt;</asp:LinkButton>
                    </div>
                    <div id="seedVipListDiv" style="display: flex; flex-direction: row; flex-wrap: wrap;">
                        <asp:Repeater ID="rptSeedVip" runat="server">
                            <ItemTemplate>
                                <div style="position: relative; width: 20%; height: .5rem;">
                                    <a href='index.aspx?id=<%#Eval("id") %>'>
                                        <img src='<%#Eval("people_face") %>' style="width: .4rem; height: .4rem; border-radius: 50%; position: absolute; top: 15%; left: 15%;">
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="fromTop4Supporter" style="display: flex; display: -webkit-flex; flex-wrap: wrap; margin-top: .05rem; max-height: 358.2px; overflow: hidden;">
                    </div>
                </div>
            </div>
            <%--支持者列表--%>
            <div id="seedVipList">
                <div style="width: 90%; margin-left: 5%; position: relative;">
                    <div style="height: .3rem; line-height: .3rem; text-align: left; font-size: .16rem; margin-top: .1rem; position: relative;">
                        <span style="font-weight: 700;">支持者<asp:Label ID="lbl_comment_count" runat="server" Text="0"></asp:Label>人</span>
                        <asp:LinkButton ID="lbtn_comment_list" runat="server" Style="position: absolute; right: 0; font-size: .12rem; color: #587adc;" OnClick="lbtn_comment_list_Click">查看更多支持者详情&gt;</asp:LinkButton>
                    </div>
                    <div id="seedVipListDiv" style="display: flex; flex-direction: row; flex-wrap: wrap;">
                        <asp:Repeater ID="rptComment" runat="server">
                            <ItemTemplate>
                                <div style="position: relative; width: 20%; height: 70px;">
                                    <img src='<%#Eval("support_by_faceurl") %>' style="width: 70%; height: 70%; border-radius: 50%; position: absolute; top: 15%; left: 15%;">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="fromTop4Supporter" style="display: flex; display: -webkit-flex; flex-wrap: wrap; margin-top: .05rem; max-height: 358.2px; overflow: hidden;">
                    </div>

                </div>
            </div>
            <%--活动照片--%>
            <div id="projectHeroDiv" style="display: block;">
                <div style="width: 100%;">
                    <div style="display: flex; height: .35rem; line-height: .35rem; font-size: .14rem; width: 100%;">
                        <div style="width: 75%;">
                            <span style="font-weight: bold;">&nbsp;&nbsp;项目介绍</span>
                        </div>
                    </div>
                    <div style="display: flex; justify-content: space-between; margin-bottom: .05rem; width: 100%;">
                        <!-- Swiper -->
                        <div class="swiper-container" style="z-index: 0;">
                            <div class="swiper-wrapper">
                                <div class="swiper-slide">
                                    <img src="images/云南茶马古道_02.gif" width="100%" />
                                </div>
                                <%--<div class="swiper-slide">
                                    <img src="image/m2.jpg" width="100%" />
                                </div>
                                <div class="swiper-slide">
                                    <img src="image/m3.jpg" width="100%" />
                                </div>--%>
                            </div>
                            <!-- Add Arrows -->
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
                        <!-- Swiper JS -->
                        <script src="dist/js/swiper.min.js"></script>
                        <!-- Initialize Swiper -->
                        <script>
                            var swiper = new Swiper('.swiper-container', {
                                navigation: {
                                    nextEl: '.swiper-button-next',
                                    prevEl: '.swiper-button-prev',
                                },
                            });
                        </script>
                    </div>
                    <div style="background: #EAEAEA; height: .1rem; width: 100%; position: relative; left: -5vw;"></div>
                </div>
            </div>
            <%--项目图片--%>
            <div id="projectDetailLink" style="display: none;">
                <div style="margin-top: 10px; widows: 100%; background-color: white; margin-top: 0.1rem;">
                    <div style="text-align: center; height: .4rem; line-height: .4rem;">
                        <span style="color: #D24417; font-weight: bold; font-size: .16rem">项目介绍</span>
                    </div>
                    <!-- Swiper -->
                    <div class="swiper-container" style="z-index: 0;">
                        <div class="swiper-wrapper">
                            <div class="swiper-slide">
                                <img src="img/A2.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/A3.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/A4.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/A5.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/A6.jpg" width="100%" />
                            </div>
                        </div>
                        <!-- Add Arrows -->
                        <div class="swiper-button-next"></div>
                        <div class="swiper-button-prev"></div>
                    </div>
                    <!-- Swiper JS -->
                    <script src="dist/js/swiper.min.js"></script>
                    <!-- Initialize Swiper -->
                    <script>
                        var swiper = new Swiper('.swiper-container', {
                            navigation: {
                                nextEl: '.swiper-button-next',
                                prevEl: '.swiper-button-prev',
                            },
                        });
                    </script>
                    <div style="width: 100%; text-align: center; font-size: .14rem; line-height: .4rem; display: none">
                        <a id="viewProjectTabs" style="color: #587ADC;" href="javascript:void(0);">查看项目详情</a>
                    </div>
                </div>
            </div>
            <%--菜单、项目信息--%>
            <div id="projectDetailTabs" style="display: block;">
                <div style="position: relative; margin-bottom: .1rem;">
                    <div style="width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; text-align: center; align-items: center;">
                        <div name="pDetail" seq="0" targetdiv="projectDescDivF" style="width: 25%;" onclick="show(1)">
                            <a href="javascript:void(0);" id="pDetailA" style="font-size: 0.14rem; font-weight: 600; color: rgb(88, 122, 188);">详情描述</a>
                        </div>
                        <div name="pDetail" seq="1" targetdiv="joinReadDivF" style="width: 25%" onclick="show(2)">
                            <a href="javascript:void(0);" id="pDetailB" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">报名须知</a>
                        </div>
                        <div name="pDetail" seq="2" targetdiv="projectDeptDivF" style="width: 25%;" onclick="show(3)">
                            <a href="javascript:void(0);" id="pDetailC" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">组织机构</a>
                        </div>
                        <div name="pDetail" seq="2" targetdiv="projectDeptDivF" style="width: 25%;" onclick="show(4)">
                            <a href="javascript:void(0);" id="pDetailD" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">队伍信息</a>
                        </div>
                    </div>
                </div>
                <div>
                    <div id="projectDescDivF" style="display: block;">
                        <div class="main_content" style="height: 500px; overflow: hidden;">
                            <div name="contentDiv" id="projectDescDiv" style="padding-left: 0px;">
                                <img src="image/详细-01.jpg" width="100%" />
                                <img src="images/云南茶马古道_03.gif" width="100%" />
                                <img src="images/云南茶马古道_14.jpg" width="100%" />
                                <img src="image/详细-04.jpg" width="100%" />
                                <img src="image/详细-05.jpg" width="100%" />
                                <img src="images/云南茶马古道_10.gif" width="100%" />
                                <img src="images/详细-06-1.gif" width="100%" />
                                <img src="images/详细-07.gif" width="100%" />
                                <img src="images/详细-08.gif" width="100%" />
                                <img src="images/云南茶马古道_08.gif" width="100%" />
                            </div>
                        </div>
                        <a href="javascript:void(0);" onclick="more(this)" class="moreDetail" targetdiv="projectDeptDiv" style="">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">更多详情</span>
                                </div>
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_down.png" style="width: .2rem; height: .2rem;">
                                </div>
                            </div>
                        </a>
                        <a href="javascript:void(0);" onclick="less(this)" class="lessDetail" style="display: none;">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_up.png" style="width: .16rem; height: .16rem; margin-top: .02rem; transform: scale(-1);">
                                </div>
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">收起</span>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div id="joinReadDivF" style="display: none;">
                        <div class="main_content" style="height: 500px; overflow: hidden;">
                            <div name="contentDiv" id="joinReadDiv" style="padding-left: 0px;">
                                <img src="images/行程.gif" width="100%" />
                                <img src="images/云南茶马古道_07.gif" width="100%" style="margin-top: -5px;" />
                                <img src="images/云南茶马古道_05.gif" width="100%" style="margin-top: -5px;" />
                                <img src="images/云南茶马古道_06.gif" width="100%" />
                                <img src="images/退赛.jpg" width="100%" />
                                <img src="images/参赛对象.jpg" />
                                <img src="images/注意事项.jpg" style="margin-top: -5px;" />
                            </div>
                        </div>
                        <a href="javascript:void(0);" onclick="more(this)" class="moreDetail" targetdiv="projectDeptDiv" style="">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">更多详情</span>
                                </div>
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_down.png" style="width: .2rem; height: .2rem;">
                                </div>
                            </div>
                        </a>
                        <a href="javascript:void(0);" onclick="less(this)" class="lessDetail" style="display: none;">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_up.png" style="width: .16rem; height: .16rem; margin-top: .02rem; transform: scale(-1);">
                                </div>
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">收起</span>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div id="projectDeptDivF" style="display: none;">
                        <div class="main_content" style="height: 500px; overflow: hidden;">
                            <div name="contentDiv" id="joinReadDiv" style="padding-left: 0px;">
                                <img src="img/组织机构.jpg" />
                                <img src="img/媒体支持.jpg" />
                            </div>
                        </div>
                        <a href="javascript:void(0);" onclick="more(this)" class="moreDetail" targetdiv="projectDeptDiv" style="">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">更多详情</span>
                                </div>
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_down.png" style="width: .2rem; height: .2rem;">
                                </div>
                            </div>
                        </a>
                        <a href="javascript:void(0);" onclick="less(this)" class="lessDetail" style="display: none;">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_up.png" style="width: .16rem; height: .16rem; margin-top: .02rem; transform: scale(-1);">
                                </div>
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">收起</span>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div id="teamInfoDivF" style="display: none;">
                        <div class="main_content" style="height: 500px; overflow: hidden;">
                            <div name="contentDiv" id="joinReadDiv" style="padding-left: 0px;">
                                <%--<img src="img/team1.jpg" />
                                <img src="img/team2.jpg" />
                                <img src="img/team3.jpg" />--%>
                                <img src="image/队伍信息1.jpg" width="100%" />
                                <img src="image/队伍信息2.jpg" width="100%" />
                            </div>
                        </div>
                        <a href="javascript:void(0);" onclick="more(this)" class="moreDetail" targetdiv="projectDeptDiv" style="">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">更多详情</span>
                                </div>
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_down.png" style="width: .2rem; height: .2rem;">
                                </div>
                            </div>
                        </a>
                        <a href="javascript:void(0);" onclick="less(this)" class="lessDetail" style="display: none;">
                            <div style="width: 20%; margin-left: 40%;">
                                <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                    <img src="img/arrow_up.png" style="width: .16rem; height: .16rem; margin-top: .02rem; transform: scale(-1);">
                                </div>
                                <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                    <span style="font-size: .14rem; color: #587ADC;">收起</span>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <%--项目进度--%>
            <div id="projectProcessDiv" style="">
                <div style="background: #EAEAEA; height: .1rem; width: 100vw;"></div>
                <div style="width: 100%; text-align: center; color: #D24417; height: .4rem; line-height: .4rem; font-size: .14rem;">
                    项目进度
                </div>
                <div style="display: flex; display: -webkit-flex; flex-direction: row; height: .6rem; line-height: .6rem; border: 1px solid #EAEAEA;">
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lblTeamCount" runat="server" Text="Label"></asp:Label>
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">联合发起人</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lblJoinCount" runat="server" Text="Label"></asp:Label>人
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">报名人数</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lblCommentCount" runat="server" Text="Label"></asp:Label>人
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">支持人数</p>
                        </div>
                    </div>
                </div>
            </div>
            <%--排行榜--%>
            <div id="rankDiv" style="">
                <div style="position: relative; margin-bottom: .1rem;">
                    <div style="display: flex;">
                        <div id="tabDiv1" style="width: 33.33%; text-align: center; font-size: .14rem; font-weight: 600; height: .5rem; line-height: .5rem;">
                            <a href="javascript:void(0);" type="support" name="rankA" style="" onclick="list(1)">支持榜</a>
                        </div>
                        <div id="tabDiv2" style="width: 33.33%; text-align: center; font-size: .14rem; font-weight: 600; height: .5rem; line-height: .5rem;">
                            <a href="javascript:void(0);" type="speed" name="rankB" style="" onclick="list(2)">速度榜</a>
                        </div>
                        <div id="tabDiv3" style="width: 33.33%; text-align: center; font-size: .14rem; font-weight: 600; height: .5rem; line-height: .5rem;">
                            <a href="javascript:void(0);" type="effect" name="rankC" style="" onclick="list(3)">影响力</a>
                        </div>
                    </div>
                    <div id="rankTabUnderLine" style="width: 33.33%; margin-left: 0%; height: 3px; background: rgb(88, 122, 220); position: absolute; bottom: 0px; border-radius: 2px;">
                    </div>
                </div>
                <div id="rankListDiv">
                    <div id="list1" style="margin-left: 2vw;">
                        <asp:Repeater ID="rptZhichi" runat="server">
                            <ItemTemplate>
                                <div style="display: flex; width: 96vw; height: .6rem;">
                                    <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">
                                        <img src='<%#Container.ItemIndex==0?"img/q1.png":Container.ItemIndex==1?"img/q2.png":Container.ItemIndex==2?"img/q3.png":"" %>'
                                            style='width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%); <%#Container.ItemIndex>2?"display:none;": "" %>'>
                                        <span style='<%#Container.ItemIndex>2?"": "display:none;" %>'><%# (Container.ItemIndex + 1).ToString() %></span>
                                    </div>
                                    <div style="width: 86vw; display: flex;">
                                        <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                            <img src='<%#Eval("people_face") %>' style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                        </div>
                                        <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">
                                            <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;"><%#Eval("people_name") %></span>
                                            </div>
                                            <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="margin-left: .1rem; font-size: .1rem;"><%#Eval("team_name") %></span>
                                            </div>
                                        </div>
                                        <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">
                                            <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                                <span style="font-size: .12rem; color: #D24417;"><%#Eval("comment_count") %>人支持</span>
                                            </div>
                                            <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                                <span style="font-size: .1rem;">￥<%#Eval("comment_money").ToString() %>元</span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="list2" style="margin-left: 2vw; display: none;">
                        <asp:Repeater ID="rptShousu" runat="server">
                            <ItemTemplate>
                                <div style="display: flex; width: 96vw; height: .6rem;">
                                    <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">
                                        <img src='<%#Container.ItemIndex==0?"img/q1.png":Container.ItemIndex==1?"img/q2.png":Container.ItemIndex==2?"img/q3.png":"" %>'
                                            style='width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%); <%#Container.ItemIndex>2?"display:none;": "" %>'>
                                        <span style='<%#Container.ItemIndex>2?"": "display:none;" %>'><%# (Container.ItemIndex + 1).ToString() %></span>
                                    </div>
                                    <div style="width: 86vw; display: flex;">
                                        <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                            <img src='<%#Eval("people_face") %>' style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                        </div>
                                        <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                            <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;"><%#Eval("people_name") %></span>
                                            </div>
                                            <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="margin-left: .1rem; font-size: .1rem;"><%#Eval("team_name") %></span>
                                            </div>
                                        </div>
                                        <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                            <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                                <span style="font-size: .12rem; color: #D24417;"><%#Eval("cost_time") %></span>
                                            </div>
                                            <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                                <span style="font-size: .1rem;"><%#Eval("cost_time") %>众筹</span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div id="list3" style="margin-left: 2vw; display: none;">
                        <asp:Repeater ID="rptYinxiang" runat="server">
                            <ItemTemplate>
                                <div style="display: flex; width: 96vw; height: .6rem;">
                                    <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">
                                        <img src='<%#Container.ItemIndex==0?"img/q1.png":Container.ItemIndex==1?"img/q2.png":Container.ItemIndex==2?"img/q3.png":"" %>'
                                            style='width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%); <%#Container.ItemIndex>2?"display:none;": "" %>'>
                                        <span style='<%#Container.ItemIndex>2?"": "display:none;" %>'><%# (Container.ItemIndex + 1).ToString() %></span>
                                    </div>
                                    <div style="width: 86vw; display: flex;">
                                        <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                            <img src='<%#Eval("people_face") %>' style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                        </div>
                                        <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">
                                            <div style="height: .6rem; line-height: .6rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                                <span style="margin-left: .1rem; font-size: .14rem; font-weight: 600;"><%#Eval("people_name") %></span>
                                            </div>
                                        </div>
                                        <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">
                                            <div style="height: .6rem; line-height: .6rem;">
                                                <span style="margin-left: .1rem; font-size: .14rem; color: #D24417;">影响<%#Eval("y_count") %>人</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div style="height: .6rem;">
            </div>
            <%--底部按钮--%>
            <div id="bottomDiv">
                <div style="position: fixed; left: 0; bottom: 0; width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; background: #FFF;">
                    <div style="position: relative; width: 100%; display: flex; display: -webkit-flex; z-index: 9999;">
                        <div id="alreadyJoinDiv1" style="width: 55%; background: rgb(255, 27, 27); color: rgb(255, 255, 255); font-size: 0.14rem; font-weight: 600; text-align: center;">
                            <asp:LinkButton ID="lbtnJoin" runat="server" Style="color: #FFF; padding: 10px 40px;" OnClick="lbtnJoin_Click">我要报名</asp:LinkButton>
                            <asp:HiddenField ID="hfdParentOpenid" runat="server" />
                        </div>
                        <div id="alreadyJoinDiv2" style="width: 45%; background: rgb(255, 188, 0); color: rgb(255, 255, 255); font-size: 0.14rem; font-weight: 600; text-align: center;">
                            <asp:LinkButton ID="lbtnSupport" runat="server" Style="color: #FFF; padding: 10px 40px;" OnClick="lbtnSupport_Click">我要支持</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <%--底部按钮--%>
        </div>
    </form>
</body>
</html>
