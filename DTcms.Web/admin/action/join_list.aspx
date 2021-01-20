<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="join_list.aspx.cs" Inherits="DTcms.Web.admin.action.join_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>报名人员列表</title>
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
        function change_team(id) {
            $.dialog({
                title: '更改队伍', width: 800, heght: 600,
                content: 'url:action/dialog_change_team.aspx?id=' + id,
                lock: true
            });
        }
        function create_team(id) {
            $.dialog({
                title: '创建新队伍', width: 800, heght: 600,
                content: 'url:action/dialog_create_team.aspx?id=' + id,
                lock: true
            });
        }
        function bind() {
            var btn = document.getElementById("btnSearch");
            btn.click();
        }
        function recommend(id) {
            $.dialog({
                title: '查看他推荐了谁', width: 800, heght: 600,
                content: 'url:action/dialog_recommend_list.aspx?id=' + id,
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
            <span>队伍联盟列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"><i class="iconfont icon-more"></i></a>
                    <div class="l-list">
                        所属队伍：
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlTeam" runat="server">
                            </asp:DropDownList>
                        </div>
                        姓名：
                        <asp:TextBox ID="txtName" runat="server" CssClass="input" />
                        电话：
                        <asp:TextBox ID="txtTel" runat="server" CssClass="input" />
                        微信昵称：
                        <asp:TextBox ID="txtNickName" runat="server" CssClass="input" />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Style="padding-right: 25px; padding-left: 25px; margin-left: 10px;" CssClass="btn" />
                        <asp:Label ID="lblInfo" runat="server" Text="" Visible="true" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="r-list">
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
                            <th width="50">选择</th>
                            <th align="center">姓名</th>
                            <th align="center">微信昵称</th>
                            <th align="center">电话号码</th>
                            <th align="center">所属队伍</th>
                            <th align="center">报名日期</th>
                            <th align="center">已筹集金额</th>
                            <th align="center">是否已筹集完成</th>
                            <th align="center">推荐人</th>
                            <th width="300">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td align="center"><%#Eval("people_name")%></td>
                        <td align="center"><%#Eval("people_nickname")%></td>
                        <td align="center"><%#Eval("mobile_phonenum")%></td>
                        <td align="center"><%#Eval("team_name")%></td>
                        <td align="center"><%#Eval("careate_date")%></td>
                        <td align="center"><%#Eval("support_mney").ToString()!=""?Eval("support_mney").ToString():"0.00"%></td>
                        <td align="center">
                            <div class='<%#Eval("is_done").ToString()=="1"?"Validform_right":"Validform_wrong" %>' style="width: 20px; height: 20px; padding-left: 0px;"></div>
                        </td>
                        <td align="center"><%#Eval("parent_name")%></td>
                        <td align="center">
                            <a href="javascript:;" onclick='create_team(<%#Eval("id")%>)'>创建新队伍</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="javascript:;" onclick='change_team(<%#Eval("id")%>)'>变更队伍</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="javascript:;" onclick='recommend(<%#Eval("id")%>)'>查看他推荐了谁</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnRefund" runat="server" CommandArgument='<%#Eval("id")%>' ForeColor="Red" OnClick="lbtnRefund_Click" OnClientClick="return confirm('确认将该报名人的所有支持者的众筹订单作退款处理？')">退款</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
      </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="当前页:%CurrentPageIndex%/%PageCount% 共有%RecordCount%条记录 %PageCount%/页"
            FirstPageText="首页" HorizontalAlign="Center" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
            LastPageText="末页" NextPageText="下一页" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
            PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
        <!--/内容底部-->
    </form>
</body>
</html>
