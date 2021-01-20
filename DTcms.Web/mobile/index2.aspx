<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="DTcms.Web.mobile.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>李三四-第一届绿徒爱心路商界精英戈壁挑战赛</title>
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
    </script>
</head>
<body style="background: #F6F6F6;">
    <div id="mainDiv" style="background: #FFF; /* margin-top: .4rem; */">
        <%--顶部图片--%>
        <div id="manifestoWithBgDiv">
            <div style="display: flex; justify-content: space-between; margin-bottom: .05rem; width: 100%;">
                <!-- Swiper -->
                <div class="swiper-container" style="z-index: 0;">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                            <img src="img/tt3.png" width="100%" />
                        </div>
                        <div class="swiper-slide">
                            <img src="img/tt2.jpg" width="100%" />
                        </div>
                        <div class="swiper-slide">
                            <img src="img/tt1.jpg" width="100%" />
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
            </div>
            <%--<div style="width: 100%; position: relative; overflow: hidden;">
                <img src="img/t_2.jpg" style="width: 100%; height: 100%;">
            </div>--%>
        </div>
        <%--顶部图片--%>
        <%--我的众筹信息--%>
        <div id="projectBusi">
            <div id="" style="width: 96%; margin-left: 2%;">
                <div style="height: .4rem; line-height: .4rem; display: flex; display: -webkit-flex; flex-direction: row; position: relative;">
                    <div style="width: 20%; fon-size: .14rem; display: flex; display: -webkit-flex; align-items: center">
                        <img src="img/face.jpg" style="height: .5rem; border-radius: 50%; z-index: 1; position: relative; bottom: .1rem; left: .1rem; border: 2px solid #FFF;">
                    </div>
                    <div style="width: 40%; font-size: .14rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                        <p style="line-height: .2rem; font-size: .14rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">星巴鹿</p>
                        <p style="line-height: .2rem; color: #CCC; font-size: .1rem;">2019-12-06 17:07:17创建</p>
                    </div>
                    <div style="width: 40%; text-align: right; font-size: .14rem; color: #999;">
                        剩余<span style="color: #D24417; font-size: .14rem;">119</span>天
                    </div>
                </div>
            </div>
            <div style="line-height: .3rem; height: .3rem; width: 94%; margin-left: 3%; font-size: .16rem; font-weight: 700; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                <span style="color: #587ADC;"></span>第一届绿徒爱心路商界精英戈壁挑战赛
            </div>
            <div id="processBarDiv" style="height: .25rem; line-height: .25rem; width: 90%; margin-left: 3%; display: flex; display: -webkit-flex; flex-direction: row; padding: 0 .07rem; border-radius: .15rem; margin-top: .1rem; margin-bottom: .1rem; position: relative;">
                <div style="width: 100%; height: .25rem; line-height: .25rem; position: relative; margin-top: .075rem; overflow-x: hidden;">
                    <div style="height: .1rem; border-radius: .05rem; width: 100%; position: absolute; left: 0; background: #CCC;"></div>
                    <div id="processBar" style="height: 0.1rem; border-radius: 0.05rem; width: 4%; position: absolute; left: -4%; background: rgb(88, 122, 220); transform: translateX(100%); transition: all 0.5s ease;"></div>
                </div>
                <div id="highlightPercent" style="height: .2rem; line-height: .2rem; width: .42rem; border-radius: .08rem; position: absolute; background: #587ADC; top: .025rem; text-align: center; color: #FFF;">0.8%</div>
            </div>


            <div style="display: flex; display: -webkit-flex; flex-direction: row; height: .6rem; line-height: .6rem; border: 1px solid #EAEAEA;">
                <div style="width: 33%; text-align: center;">
                    <div style="height: .5rem; margin-top: .05rem;">
                        <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">￥16800</p>
                        <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">目标金额</p>
                    </div>
                </div>
                <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                <div style="width: 33%; text-align: center;">
                    <div style="height: .5rem; margin-top: .05rem;">
                        <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">￥13692.00元</p>
                        <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">剩余金额</p>
                    </div>
                </div>
                <div style="width: 1px; height: .4rem; background: #EAEAEA; position: relative; top: .1rem;"></div>
                <div style="width: 33%; text-align: center;">
                    <div style="height: .5rem; margin-top: .05rem;">
                        <p style="font-size: .16rem; color: #D24417; height: .3rem; line-height: .3rem;">1人</p>
                        <p style="font-size: .12rem; color: #999; height: .2rem; line-height: .2rem;">支持人数</p>
                    </div>
                </div>
            </div>
        </div>
        <%--我的信息--%>

        <%--支持者列表--%>
        <div id="supportList">
            <div style="width: 90%; margin-left: 5%; position: relative;">
                <div style="height: .3rem; line-height: .3rem; text-align: center; font-size: .16rem; margin-top: .1rem; position: relative;">
                    <span style="font-weight: 700;">支持者1人</span>
                    <a href="#" style="position: absolute; right: 0; font-size: .12rem; color: #587adc;">查看全部&gt;</a>

                </div>
                <div id="top3crown" style="display: flex; display: -webkit-flex; flex-direction: row; width: 66%; margin-left: 17%; height: .7rem;">
                    <div style="width: 33.33%; height: .7rem;">
                    </div>
                    <div style="width: 33.33%; height: .8rem;">
                        <div style="height: .2rem; position: relative; width: 100%;">
                        </div>
                        <div style="height: .6rem; width: 100%; position: relative;">
                            <img src="http://thirdwx.qlogo.cn/mmopen/YLf0aVAXPfSxm5z2DS0ex3AZBSo8dXGl5kEmtxibD8fK4dKqH8mXBrOuNuPJSJNNP4ISZJ4JcqOloNONvaJnQV87ZXRgn3JLe/132" style="height: .5rem; width: .5rem; position: absolute; top: 40%; left: 50%; transform: translate(-50%,-50%); border-radius: 50%;">
                        </div>

                    </div>
                    <div style="width: 33.33%; height: .7rem;">
                    </div>
                </div>
                <div id="fromTop4Supporter" style="display: flex; display: -webkit-flex; flex-wrap: wrap; margin-top: .05rem; max-height: 358.2px; overflow: hidden;">
                </div>

            </div>
        </div>
        <%--支持者列表--%>
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
                                <img src="img/mm3.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/mm4.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/mm5.jpg" width="100%" />
                            </div>
                            <%--  <div class="swiper-slide">
                                <img src="img/b5.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/b8.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/b9.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/b10.jpg" width="100%" />
                            </div>
                            <div class="swiper-slide">
                                <img src="img/b11.jpg" width="100%" />
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
                <div style="background: #EAEAEA; height: .1rem; width: 100vw; position: relative; left: -5vw;"></div>
            </div>
        </div>
        <%--活动照片--%>
        <%--项目图片--%>
        <div id="projectDetailLink" style="display: none;">
            <div style="margin-top: 10px; widows: 100%; background-color: white; margin-top: 0.1rem;">
                <div style="text-align: center; height: .4rem; line-height: .4rem;">
                    <span style="color: #D24417; font-weight: bold; font-size: .16rem">项目介绍</span>
                </div>
                <!-- Swiper -->
                <div class="swiper-container" style="z-index: 0;">
                    <div class="swiper-wrapper">
                        <%-- <div class="swiper-slide">
                            <img src="img/A1.jpg" width="100%" />
                        </div>--%>
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
        <%--项目图片--%>
        <%--菜单、项目信息--%>
        <div id="projectDetailTabs" style="display: block;">
            <div style="position: relative; margin-bottom: .1rem;">
                <div style="width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; text-align: center; align-items: center;">
                    <div name="pDetail" seq="0" targetdiv="projectDescDivF" style="width: 25%;" onclick="show(1)">
                        <a href="javascript:void(0);" id="pDetailA" style="font-size: 0.14rem; font-weight: 600; color: rgb(88, 122, 188);">详情描述</a>
                    </div>
                    <div name="pDetail" seq="1" targetdiv="joinReadDivF" style="width: 25%;" onclick="show(2)">
                        <a href="javascript:void(0);" id="pDetailB" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">报名须知</a>
                    </div>
                    <div name="pDetail" seq="2" targetdiv="projectDeptDivF" style="width: 25%;" onclick="show(3)">
                        <a href="javascript:void(0);" id="pDetailC" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">组织机构</a>
                    </div>
                    <div name="pDetail" seq="3" targetdiv="teamInfoDivF" style="width: 25%;" onclick="show(4)">
                        <a href="javascript:void(0);" id="pDetailD" style="font-size: 0.14rem; font-weight: 600; color: rgb(51, 51, 51);">队伍信息</a>
                    </div>
                </div>
                <div style="height: 1px; width: 94%; position: absolute; bottom: 0; left: 3%; background: #eaeaea; display: none;"></div>
            </div>
            <div>
                <div id="projectDescDivF" style="display: block;">
                    <div style="height: 500px; overflow: auto;">
                        <div name="contentDiv" id="projectDescDiv" style="padding-left: 10px;">
                            <img src="img/M3.png" />
                            <img src="img/M4.png" />
                            <img src="img/bb1.png" />
                            <img src="img/bb2.png" />
                            <img src="img/bb3.png" />
                            <img src="img/bb4.png" />
                            <img src="img/m5.jpg" />
                            <img src="img/m6.jpg" />
                            <img src="img/路线四天.jpg" />
                            <img src="img/people.jpg" />
                        </div>
                    </div>
                </div>
                <div id="joinReadDivF" style="display: none;">
                    <div style="height: 500px; overflow: auto;">
                        <div name="contentDiv" id="joinReadDiv" style="padding-left: 10px;">
                            <img src="img/bao1.png" />
                            <img src="img/bao2.jpg" />
                            <img src="img/bao3.jpg" />
                            <img src="img/bao4.jpg" />
                            <img src="img/bao5.jpg" />
                           <%-- <img src="img/baoming_0.png" />
                            <img src="img/baoming_1.jpg" />
                            <img src="img/baoming.png" />--%>
                        </div>
                    </div>
                </div>
                <div id="projectDeptDivF" style="display: none;">
                    <div style="height: 500px; overflow: auto;">
                        <div name="contentDiv" id="joinReadDiv" style="padding-left: 10px;">
                            <img src="img/zuzhijigou.png" />
                        </div>
                    </div>
                    <a href="javascript:void(0);" name="moreDetail" targetdiv="projectDeptDiv" style="">
                        <div id="projectDescDivMore" style="width: 20%; margin-left: 40%;">
                            <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                <span style="font-size: .14rem; color: #587ADC;">更多详情</span>
                            </div>
                            <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                <img src="/wsc/resources/images/zc/arrow_down.png" style="width: .2rem; height: .2rem;">
                            </div>
                        </div>
                    </a>
                    <a href="javascript:void(0);" name="lessDetail" targetdiv="projectDeptDiv" style="display: none;">
                        <div style="width: 20%; margin-left: 40%;">
                            <div style="text-align: center; height: .2rem; line-height: .2rem;">
                                <img src="/wsc/resources/images/zc/arrow_down.png" style="width: .16rem; height: .16rem; margin-top: .02rem; transform: scale(-1);">
                            </div>
                            <div style="height: .3rem; line-height: .3rem; text-align: center;">
                                <span style="font-size: .14rem; color: #587ADC;">收起</span>
                            </div>
                        </div>
                    </a>
                </div>
                <div id="teamInfoDivF" style="display: none;">
                    <div style="height: 500px; overflow: auto;">
                        <div name="contentDiv" id="joinReadDiv" style="padding-left: 10px;">
                            <div style="width: 100%; height: 200px;"></div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <%--菜单、项目信息--%>
        <%--评论区--%>
        <div id="joinRecordTabs" style="">
            <div>
                <div style="background: #EAEAEA; height: .1rem; width: 100vw;"></div>
                <div style="position: relative;">
                    <div style="width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; text-align: center; align-items: center;">
                        <div name="jrListTab" seq="0" targetdiv="supportListTabDiv" style="width: 33.33%;">
                            <a href="javascript:void(0);" name="jrListTabA" style="font-size: .14rem; font-weight: 600;">支持者留言(<span id="supportCnt">1</span>)</a>
                        </div>
                    </div>
                    <div id="jrListUnderLine" style="width: 21%; height: 3px; background: #587ADC; position: absolute; bottom: 0; left: 6%; border-radius: 2px;"></div>
                    <div style="height: 1px; width: 94%; position: absolute; bottom: 0; left: 3%; background: #eaeaea;"></div>
                </div>
                <div style="width: 100%; background: #DDD;">
                    <div id="supportListTabDiv" style="width: 96%; margin-left: 2%;">
                        <div name="supportBlock" style="padding-top: .3rem;" jrsid="431934">
                            <div style="width: 100%; display: flex; display: -webkit-flex; flex-direction: row; position: relative;">
                                <div style="width: 20%; text-align: center; position: relative;">
                                    <div style="position: absolute; top: .25rem; transform: translateY(-50%);">
                                        <img src="http://thirdwx.qlogo.cn/mmopen/YLf0aVAXPfSxm5z2DS0ex3AZBSo8dXGl5kEmtxibD8fK4dKqH8mXBrOuNuPJSJNNP4ISZJ4JcqOloNONvaJnQV87ZXRgn3JLe/132" style="width: .4rem; height: .4rem; margin-top: .05rem; border-radius: 50%; border: .05rem solid #FFF;">
                                    </div>
                                </div>
                                <div style="width: 80%; background: #FFF; border-radius: .05rem; position: relative;" name="supportInfoDidv">
                                    <div style="height: .12rem; width: .12rem; background: #FFF; position: absolute; transform: rotate(45deg); top: 12%; left: -.05rem;"></div>
                                    <div style="height: .3rem; line-height: .3rem; display: flex; display: -webkit-flex; flex-direction: row;">
                                        <div style="width: 65%; margin-left: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                            <span style="font-weight: 600; font-size: .12rem; color: #999;">丁丁户外</span>
                                        </div>
                                        <div style="width: 35%; text-align: right; margin-right: .1rem;">
                                            支持 <span style="font-size: .14rem; color: #D24417;">108元</span>
                                        </div>
                                    </div>
                                    <div style="display: flex; display: -webkit-flex;">
                                        <div style="width: 100%; text-align: left; padding: 0 .1rem;">
                                            <div style="line-height: .2rem;">
                                                <span style="color: #333;">有梦想的人永远值得被尊重，我用行动支持你！</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="background: #DDD; height: .1rem;">
                    </div>
                </div>
            </div>
        </div>
        <%--评论区--%>
        <div style="height: .6rem;">
        </div>
        <%--底部按钮--%>
        <div id="bottomDiv">
            <div style="position: fixed; left: 0; bottom: 0; width: 100%; height: .5rem; line-height: .5rem; display: flex; display: -webkit-flex; flex-direction: row; background: #FFF;">
                <div style="position: relative; width: 100%; display: flex; display: -webkit-flex; z-index: 9999;">
                    <div id="alreadyJoinDiv1" style="width: 55%; background: rgb(255, 27, 27); color: rgb(255, 255, 255); font-size: 0.14rem; font-weight: 600; text-align: center;">
                        <a href="javascript:void(0);" style="color: #FFF; padding: 10px 40px;" id="toMyJoinRecord">我要支持</a>
                    </div>
                    <div id="alreadyJoinDiv2" style="width: 45%; background: rgb(255, 188, 0); color: rgb(255, 255, 255); font-size: 0.14rem; font-weight: 600; text-align: center;">
                        <a href="javascript:void(0);" style="color: #FFF; padding: 10px 40px;" id="toMyJoinRecord">我要报名</a>
                    </div>
                </div>
            </div>
        </div>
        <%--底部按钮--%>
        <div style="display: flex; width: 96vw; height: .6rem;">
                            <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">
                                <img src="img/q1.png" style="width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%);">
                            </div>
                            <div style="width: 86vw; display: flex;">
                                <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                    <img src="http://thirdwx.qlogo.cn/mmopen/YLf0aVAXPfSXoicNS2Zl6V7mHFMq0WfFgJjpMglOicbiagAenLiaeUrAUNNVrEibtLx9912XwgV8x7zjf2icMAv7ic2Hknib9WibUwT1o/132" style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                </div>
                                <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;">娟娟</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .1rem;">问道联盟</span>
                                    </div>
                                </div>
                                <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                        <span style="font-size: .12rem; color: #D24417;">1320人支持</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                        <span style="font-size: .1rem;">￥1.38万元</span>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div style="display: flex; width: 96vw; height: .6rem;">
                            <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">

                                <img src="img/q2.png" style="width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%);">
                            </div>
                            <div style="width: 86vw; display: flex;">
                                <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                    <img src="http://thirdwx.qlogo.cn/mmopen/BJFOFZYwq7WibyOZSqj9wvMbaJNYpHqITf1tmQUCZu1mpP53NNudnp3QehHJIiblLmFicibDNDK5X5XFIK9pegy4IbO5C5YuI7Um/132" style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                </div>
                                <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;">刘昱麟</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .1rem;">勇者无敌-能量方舟战队</span>
                                    </div>

                                </div>
                                <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                        <span style="font-size: .12rem; color: #D24417;">1314人支持</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                        <span style="font-size: .1rem;">￥1.38万元</span>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div style="display: flex; width: 96vw; height: .6rem;">
                            <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">

                                <img src="img/q3.png" style="width: 8vw; position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%);">
                            </div>
                            <div style="width: 86vw; display: flex;">
                                <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                    <img src="http://thirdwx.qlogo.cn/mmopen/FglIwyIUjniaEBOM4ThiczHpVvicojNn6AwiaVFskia0RiamDmptSbosIV1Vs26T9S6UB1Tg2XfQdJ53qcj6MuLghIZs8aU3Riab8eY/132" style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                </div>
                                <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;">_  梦想发起人 成乐乐</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .1rem;">自由远行战队</span>
                                    </div>

                                </div>
                                <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                        <span style="font-size: .12rem; color: #D24417;">992人支持</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                        <span style="font-size: .1rem;">￥7680.48元</span>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div style="display: flex; width: 96vw; height: .6rem;">
                            <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">

                                <span style="font-size: .14rem;">4</span>

                            </div>
                            <div style="width: 86vw; display: flex;">
                                <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                    <img src="http://thirdwx.qlogo.cn/mmopen/FglIwyIUjniaEBOM4ThiczHhucrPvb9IicszZS54pBWX3naGicowqibnQy5OpGWZjc2bRRwgJHgXp02j71XcPfSFiaHFEfvPLoJC9t/132" style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                </div>
                                <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;">【 晓 升 】</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .1rem;">狂浪战队</span>
                                    </div>

                                </div>
                                <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                        <span style="font-size: .12rem; color: #D24417;">971人支持</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                        <span style="font-size: .1rem;">￥5166.22元</span>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div style="display: flex; width: 96vw; height: .6rem;">
                            <div style="width: 10vw; position: relative; text-align: center; line-height: .6rem;">

                                <span style="font-size: .14rem;">5</span>

                            </div>
                            <div style="width: 86vw; display: flex;">
                                <div style="width: 20vw; border-bottom: 1px solid #EAEAEA; position: relative;">
                                    <img src="http://thirdwx.qlogo.cn/mmopen/ajNVdqHZLLD3NQD2RqVLE0vvPeRgTI8ygYe16ByXhK1gcTMKdwtHiaWZGV6kSFzo0cHgQkQH5pyjW7a5o1amGLQ/132" style="border-radius: 50%; height: .4rem; width: .4rem; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);">
                                </div>
                                <div style="width: 36vw; position: relative; border-bottom: 1px solid #EAEAEA;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .12rem; font-weight: 600;">团座赖威</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 1;">
                                        <span style="margin-left: .1rem; font-size: .1rem;">英雄之旅队</span>
                                    </div>

                                </div>
                                <div style="width: 28vw; position: relative; border-bottom: 1px solid #EAEAEA; text-align: right;">

                                    <div style="height: .2rem; line-height: .2rem; margin-top: .1rem;">
                                        <span style="font-size: .12rem; color: #D24417;">574人支持</span>
                                    </div>
                                    <div style="height: .2rem; line-height: .2rem; margin-bottom: .1rem;">
                                        <span style="font-size: .1rem;">￥1.38万元</span>
                                    </div>

                                </div>
                            </div>
                        </div>
    </div>

</body>
</html>
