﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="DTcms.Web.admin.users.user_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>会员列表</title>
    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../../css/pagination.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
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

        function userRecharge(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '充值', width: 800, heght: 600,
                content: 'url:users/user_recharge.aspx?id=' + id,
                lock: true
            });
        }
        function userCost(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '消费', width: 800, heght: 600,
                content: 'url:users/user_cost.aspx?id=' + id,
                lock: true
            });
        }

        function userRechargeRecord(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '充值记录', width: 800, heght: 600,
                content: 'url:users/user_recharge_record.aspx?id=' + id,
                lock: true
            });
        }
        function userCostRecord(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '消费记录', width: 800, heght: 600,
                content: 'url:users/user_cost_record.aspx?id=' + id,
                lock: true
            });
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i class="iconfont icon-up"></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i class="iconfont icon-home"></i><span>首页</span></a>
            <i class="arrow iconfont icon-arrow-right"></i>
            <span>会员列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"><i class="iconfont icon-more"></i></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a href="user_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i class="iconfont icon-close"></i><span>新增</span></a></li>
                            <li><a href="javascript:;" onclick="checkAll(this);"><i class="iconfont icon-check"></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i class="iconfont icon-delete"></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click"><i class="iconfont icon-search"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择</th>
                            <th align="left" width="10%">会员姓名</th>
                            <th align="left" width="10%">会员卡号</th>
                            <th align="left" width="5%">性别</th>
                            <th align="left" width="10%">联系电话</th>
                            <th align="left" width="12%">添加时间</th>
                            <th align="left" width="12%">最近一次充值时间</th>
                            <th align="left" width="12%">最近一次消费时间</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("user_id")%>' runat="server" />
                        </td>
                        <td><%# Eval("user_name") %></td>
                        <td><%# Eval("user_cardnum") %></td>
                        <td><%# Eval("user_sex") %></td>
                        <td><%# Eval("user_telphone") %></td>
                        <td><%# Eval("create_time") %></td>
                        <td><%# Eval("last_pay_time") %></td>
                        <td><%# Eval("last_rechage_time") %></td>
                        <td align="center">
                            <a href="user_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("user_id")%>">修改会员信息</a>&nbsp;&nbsp;<a href="#">消费记录</a>&nbsp;&nbsp;<a href="#">充值记录</a>
                            <br />
                            <a href="javascript:;" onclick="userRecharge(this)">充值</a>&nbsp;&nbsp;<a href="javascript:;" onclick="userCost(this)">消费</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
