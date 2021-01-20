<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DTcms.Web.mobile._default" %>

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
        function jrList(id) {
            if (id == 1) {
                $("#jrListUnderLine").css("transform", "");
                $("#jrListAllDiv").css("display", "block");
                $("#jrListIngDiv").css("display", "none");
                $("#jrListSuccessDiv").css("display", "none");
            }
            else if (id == 2) {
                $("#jrListUnderLine").css("transform", "translateX(1.25rem");
                $("#jrListAllDiv").css("display", "none");
                $("#jrListIngDiv").css("display", "block");
                $("#jrListSuccessDiv").css("display", "none");
            }
            else if (id == 3) {
                $("#jrListUnderLine").css("transform", "translateX(2.5rem");
                $("#jrListAllDiv").css("display", "none");
                $("#jrListIngDiv").css("display", "none");
                $("#jrListSuccessDiv").css("display", "block");

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
</head>
<body style="background: #F6F6F6;">
    <form id="form1" runat="server">
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
                                <img src="img/tt2.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/tt1.jpg" width="100%" />
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
            <%--众筹信息--%>
            <div id="projectBusi">
                <div style="line-height: .3rem; height: .3rem; width: 94%; margin-left: 3%; font-size: .16rem; font-weight: 700; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                    <span style="color: #587ADC;">
                        <asp:Label ID="lblTeamName" runat="server" Text="绿徒联盟"></asp:Label></span>
                    “觉醒之路”首届商界精英茶马古道挑战赛
                </div>
                <div style="display: flex; display: -webkit-flex; flex-direction: row; height: .6rem; line-height: .6rem; border: 1px solid #EAEAEA;">
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">￥13800</p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">报名费用</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lblJoinCount" runat="server" Text="0"></asp:Label>人
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">报名人数</p>
                        </div>
                    </div>
                    <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                    <div style="width: 33%; text-align: center;">
                        <div style="height: .5rem; margin-top: .05rem;">
                            <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">
                                <asp:Label ID="lblCommentCount" runat="server" Text="0"></asp:Label>人
                            </p>
                            <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">支持人数</p>
                        </div>
                    </div>
                </div>
            </div>
            <%--报名人列表--%>
            <div id="seedVipList">
                <div style="width: 90%; margin-left: 5%; position: relative;">
                    <div style="height: .3rem; line-height: .3rem; text-align: center; font-size: .16rem; margin-top: .1rem; position: relative;">
                        <span style="font-weight: 700;">种子队友</span>
                        <asp:LinkButton ID="lbtnAllSeed" runat="server" OnClick="lbtnAllSeed_Click" Style="position: absolute; right: 0; font-size: .12rem; color: #587adc;">查看全部&gt;</asp:LinkButton>
                    </div>
                    <div id="seedVipListDiv" style="display: flex; flex-direction: row; flex-wrap: wrap;">
                        <asp:Repeater ID="rptSeedVip" runat="server">
                            <ItemTemplate>
                                <div style="position: relative; width: 20%; height: .5rem;">
                                    <%--<svg name="svgForStroke" sbase="300.084930270897" percent="28.5" xmlns="http://www.w3.org/2000/svg" style="position: absolute; top: 0px; left: 0px; width: 119.4px; height: 119.4px; stroke-dasharray: 300.085, 300.085; stroke-dashoffset: 216.061px; stroke-linecap: round; fill: none; transform: rotate(-90deg);" render="1" stroke="yellow">
                                <circle cx="50%" cy="50%" r="40%" stroke-width="5%"></circle>
                            </svg>--%>
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
                                    <img src="img/mm4.jpg" width="100%" />
                                </div>
                                <div class="swiper-slide">
                                    <img src="img/mm5.jpg" width="100%" />
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
                                d
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
                        <div name="pDetail" seq="0" targetdiv="projectDescDivF" style="width: 33%;" onclick="show(1)">
                            <a href="javascript:void(0);" id="pDetailA" style="font-size: 0.14rem; font-weight: 600; color: rgb(88, 122, 188);">详情描述</a>
                        </div>
                        <div name="pDetail" seq="1" targetdiv="joinReadDivF" style="width: 33%;" onclick="show(2)">
                            <a href="javascript:void(0);" id="pDetailB" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">报名须知</a>
                        </div>
                        <div name="pDetail" seq="2" targetdiv="projectDeptDivF" style="width: 33%;" onclick="show(3)">
                            <a href="javascript:void(0);" id="pDetailC" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">组织机构</a>
                        </div>
                    </div>
                </div>
                <div style="">
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
                </div>
            </div>
            <%--队伍情况--%>
            <div style="position: relative; margin-bottom: .1rem;">
                <div style="width: 100%; height: .5rem; line-height: .5rem; display: flex; flex-direction: row; text-align: center; align-items: center;">
                    <div name="jrListTab" onclick="jrList(1)" seq="0" targetdiv="jrListAllDiv" style="width: 33.33%;">
                        <a href="javascript:void(0);" name="jrListTabA" style="font-size: .14rem; font-weight: 600;">全部(<span id="allJrCnt"><asp:Label ID="lblAllcount" runat="server" Text="Label"></asp:Label></span>)</a>
                    </div>
                    <div name="jrListTab" onclick="jrList(2)" seq="1" targetdiv="jrListIngDiv" style="width: 33.33%;">
                        <a href="javascript:void(0);" name="jrListTabA" style="font-size: .14rem; font-weight: 600;">众筹中(<span id="jrIngCnt"><asp:Label ID="lblIngcount" runat="server" Text="Label"></asp:Label></span>)</a>
                    </div>
                    <div name="jrListTab" onclick="jrList(3)" seq="2" targetdiv="jrListSuccessDiv" style="width: 33.33%;">
                        <a href="javascript:void(0);" name="jrListTabA" style="font-size: .14rem; font-weight: 600;">已筹满(<span id="jrSuccessCnt"><asp:Label ID="lblSuccesscount" runat="server" Text="Label"></asp:Label></span>)</a>
                    </div>
                </div>
                <div id="jrListUnderLine" style="width: 21%; height: 3px; background: #587ADC; position: absolute; bottom: 0; left: 6%; border-radius: 2px;"></div>
                <div style="height: 1px; width: 94%; position: absolute; bottom: 0; left: 3%; background: #eaeaea;"></div>
            </div>
            <div style="width: 90%; margin-left: 5%; margin-bottom: .5rem;">
                <div id="jrListAllDiv">
                    <asp:Repeater ID="rptSeedAll" runat="server">
                        <ItemTemplate>
                            <div name="joinReacordBlock" style="border-bottom: 1px solid #EAEAEA;">
                                <a href='index.aspx?id=<%#Eval("id") %>'>
                                    <div style="width: 100%; height: .5rem; display: flex;">
                                        <div style="width: 15%;">
                                            <asp:HiddenField ID="hfdid" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:HiddenField ID="hfdopenid" runat="server" Value='<%#Eval("people_openid") %>' />
                                            <img src='<%#Eval("people_face") %>' style="width: .4rem; height: .4rem; margin-top: .05rem; border-radius: 50%;">
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 45%; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                            <span style="color: #333; font-size: .12rem; margin-left: .1rem;"><%#Eval("people_name") %> </span>
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 40%;">
                                            <span style="color: #999; font-size: .1rem; margin-left: .1rem;"><%#Eval("careate_date") %></span>
                                        </div>
                                    </div>
                                    <div style="height: .4rem; line-height: .4rem; width: 80%; text-align: left; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="padding-left: .1rem; color: #999;">来吧，去茶马古道，以天为幕，地为席，与企业家一起混帐，共处96小时，放下，坚持，超越，重生！</span>
                                    </div>
                                    <div name="supportHeadImgs" supportcnt="32" joinrecordid="16938" render="1" style="height: 0.4rem; line-height: 0.4rem; position: relative; text-overflow: ellipsis; overflow: hidden; white-space: nowrap;">
                                        <asp:Repeater ID="rptChild" runat="server">
                                            <ItemTemplate>
                                                <img src='<%#Eval("support_by_faceurl") %>' style='height: .3rem; width: .3rem; border-radius: 50%; position: absolute; top: .05rem; left: <%#(Container.ItemIndex*0.25) %>rem; border: 2px solid #FFF;'>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div style="height: .3rem; line-height: .3rem; position: relative;">
                                        <span style="position: absolute; left: 5px; color: #999; font-size: .1rem;">支持者 <span style="font-size: .14rem; color: #333;"><%#Eval("support_count") %></span> 人</span>
                                        <span style="position: absolute; right: 0; color: #999; font-size: .1rem;">已筹 <span style="font-size: .14rem; color: #333;"><%#Eval("support_money").ToString()!=""?Eval("support_money"):"0" %></span> 元</span>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="jrListIngDiv" style="display: none;">
                    <asp:Repeater ID="rptSeedIng" runat="server">
                        <ItemTemplate>
                            <div name="joinReacordBlock" style="border-bottom: 1px solid #EAEAEA;">
                                <a href='index.aspx?id=<%#Eval("id") %>'>
                                    <div style="width: 100%; height: .5rem; display: flex;">
                                        <div style="width: 15%;">
                                            <asp:HiddenField ID="hfdid" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:HiddenField ID="hfdopenid" runat="server" Value='<%#Eval("people_openid") %>' />
                                            <img src='<%#Eval("people_face") %>' style="width: .4rem; height: .4rem; margin-top: .05rem; border-radius: 50%;">
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 45%; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                            <span style="color: #333; font-size: .12rem; margin-left: .1rem;"><%#Eval("people_name") %> </span>
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 40%;">
                                            <span style="color: #999; font-size: .1rem; margin-left: .1rem;"><%#Eval("careate_date") %></span>
                                        </div>
                                    </div>
                                    <div style="height: .4rem; line-height: .4rem; width: 80%; text-align: left; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="padding-left: .1rem; color: #999;">来吧，去茶马古道，以天为幕，地为席，与企业家一起混帐，共处96小时，放下，坚持，超越，重生！</span>
                                    </div>
                                    <div name="supportHeadImgs" supportcnt="32" joinrecordid="16938" render="1" style="height: 0.4rem; line-height: 0.4rem; position: relative; text-overflow: ellipsis; overflow: hidden; white-space: nowrap;">
                                        <asp:Repeater ID="rptChild" runat="server">
                                            <ItemTemplate>
                                                <img src='<%#Eval("support_by_faceurl") %>' style='height: .3rem; width: .3rem; border-radius: 50%; position: absolute; top: .05rem; left: <%#(Container.ItemIndex*0.25) %>rem; border: 2px solid #FFF;'>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div style="height: .3rem; line-height: .3rem; position: relative;">
                                        <span style="position: absolute; left: 5px; color: #999; font-size: .1rem;">支持者 <span style="font-size: .14rem; color: #333;"><%#Eval("support_count") %></span> 人</span>
                                        <span style="position: absolute; right: 0; color: #999; font-size: .1rem;">已筹 <span style="font-size: .14rem; color: #333;"><%#Eval("support_money").ToString()!=""?Eval("support_money"):"0" %></span> 元</span>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="jrListSuccessDiv" style="display: none;">
                    <asp:Repeater ID="rptSeedSuccess" runat="server">
                        <ItemTemplate>
                            <div name="joinReacordBlock" style="border-bottom: 1px solid #EAEAEA;">
                                <a href='index.aspx?id=<%#Eval("id") %>'>
                                    <div style="width: 100%; height: .5rem; display: flex;">
                                        <div style="width: 15%;">
                                            <asp:HiddenField ID="hfdid" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:HiddenField ID="hfdopenid" runat="server" Value='<%#Eval("people_openid") %>' />
                                            <img src='<%#Eval("people_face") %>' style="width: .4rem; height: .4rem; margin-top: .05rem; border-radius: 50%;">
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 45%; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                            <span style="color: #333; font-size: .12rem; margin-left: .1rem;"><%#Eval("people_name") %> </span>
                                        </div>
                                        <div style="line-height: .5rem; height: .5rem; width: 40%;">
                                            <span style="color: #999; font-size: .1rem; margin-left: .1rem;"><%#Eval("careate_date") %></span>
                                        </div>
                                    </div>
                                    <div style="height: .4rem; line-height: .4rem; width: 80%; text-align: left; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="padding-left: .1rem; color: #999;">来吧，去茶马古道，以天为幕，地为席，与企业家一起混帐，共处96小时，放下，坚持，超越，重生！</span>
                                    </div>
                                    <div name="supportHeadImgs" supportcnt="32" joinrecordid="16938" render="1" style="height: 0.4rem; line-height: 0.4rem; position: relative; text-overflow: ellipsis; overflow: hidden; white-space: nowrap;">
                                        <asp:Repeater ID="rptChild" runat="server">
                                            <ItemTemplate>
                                                <img src='<%#Eval("support_by_faceurl") %>' style='height: .3rem; width: .3rem; border-radius: 50%; position: absolute; top: .05rem; left: <%#(Container.ItemIndex*0.25) %>rem; border: 2px solid #FFF;'>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div style="height: .3rem; line-height: .3rem; position: relative;">
                                        <span style="position: absolute; left: 5px; color: #999; font-size: .1rem;">支持者 <span style="font-size: .14rem; color: #333;"><%#Eval("support_count") %></span> 人</span>
                                        <span style="position: absolute; right: 0; color: #999; font-size: .1rem;">已筹 <span style="font-size: .14rem; color: #333;"><%#Eval("support_money").ToString()!=""?Eval("support_money"):"0" %></span> 元</span>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div style="height: .6rem;">
            </div>
            <%--底部按钮--%>
            <div id="bottomDiv">
                <div style="position: fixed; left: 0; bottom: 0; width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; background: #FFF;">
                    <div style="position: relative; width: 100%; display: flex; display: -webkit-flex; z-index: 9999;">
                        <div id="alreadyJoinDiv1" style="width: 100%; background: rgb(255, 27, 27); color: rgb(255, 255, 255); font-size: 0.14rem; font-weight: 600; text-align: center;">
                            <asp:LinkButton ID="lbtnJoin" runat="server" Style="color: #FFF; padding: 10px 40px;" OnClick="lbtnJoin_Click">我要报名</asp:LinkButton>
                            <asp:HiddenField ID="hfdParentOpenid" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%--底部按钮--%>
        </div>
    </form>
</body>
</html>
