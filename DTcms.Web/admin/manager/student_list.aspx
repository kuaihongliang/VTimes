<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_list.aspx.cs" Inherits="DTcms.Web.admin.manager.student_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>学员列表</title>
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
        function bindWX(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '绑定学员', width: 500, heght: 500,
                content: 'url:manager/student_bind_qr.aspx?id=' + id,
                lock: true
            });
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <i class="arrow iconfont icon-arrow-right"></i>
            <span>学员列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"><i class="iconfont icon-more"></i></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a href="student_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i class="iconfont icon-close"></i><span>添加学员</span></a></li>
                            <li><a href="javascript:;" onclick="checkAll(this);"><i class="iconfont icon-check"></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i class="iconfont icon-delete"></i><span>删除学员</span></asp:LinkButton></li>
                        </ul>
                        所属教练：
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="input">
                                <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        学员姓名：
                        <asp:TextBox ID="txtName" runat="server" CssClass="input" />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Style="padding-right: 25px; padding-left: 25px; margin-left: 10px;" CssClass="btn" />&nbsp;
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
                            <th width="5%">选择</th>
                            <th align="left">姓名</th>
                            <th align="left" width="9%">联系电话</th>
                            <th align="left" width="9%">学历</th>
                            <th align="left" width="9%">性别</th>
                            <th align="left" width="9%">民族</th>
                            <th align="left" width="9%">籍贯</th>
                            <th align="left" width="9%">年龄</th>
                            <th align="left" width="9%">身份证号</th>
                            <th align="left" width="9%">介绍人</th>
                            <th width="190">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("st_id")%>' runat="server" />
                        </td>
                        <td><%#Eval("st_name")%></td>
                        <td><%#Eval("st_telphone")%></td>
                        <td><%#Eval("st_education")%></td>
                        <td><%#Eval("st_sex")%></td>
                        <td><%#Eval("st_nation")%></td>
                        <td><%#Eval("st_native")%></td>
                        <td><%#Eval("st_age")%></td>
                        <td><%#Eval("st_idcard")%></td>
                        <td><%#Eval("st_introducer")%></td>
                        <td align="center">
                            <a href="student_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("st_id")%>">修改信息</a>&nbsp;&nbsp;
                            <a href="#">添加课时</a>&nbsp;&nbsp;
                            <a href='student_bind_qr.aspx?id=<%#Eval("st_id") %>' target="_blank">绑定微信</a>
                            <%--<a style="cursor: pointer;" href="javascript:;" onclick="bindWX(this)">绑定微信</a>--%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
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
