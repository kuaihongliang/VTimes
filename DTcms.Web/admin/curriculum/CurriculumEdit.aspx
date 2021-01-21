<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurriculumEdit.aspx.cs" Inherits="DTcms.Web.admin.curriculum.CurriculumEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>课程设置页</title>
    <script src="../../Scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:;" class="home"><i></i><span>课程设置页</span></a>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">
                        <asp:Literal ID="litNowPosition2" runat="server" Text="课程设置页"></asp:Literal></a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>课程日期：</dt>
            <dd>
                <asp:Label ID="labDate" runat="server" Text="Label"></asp:Label>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>课程名称：</dt>
            <dd>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:TextBox ID="txtCurriculumName" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="1" MaxLength="100"></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>课程时间：</dt>
            <dd>
                <asp:TextBox ID="txtCurriculumDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm:ss'})"
                    datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
            </dd>
        </dl>
       
        <dl>
            <dt>授课老师：</dt>
            <dd><asp:HiddenField ID="hdfTeacherID" runat="server" />
               <asp:TextBox ID="txtTeacher" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="" MaxLength="100"></asp:TextBox>
               <%-- <div class="rule-single-select">
                <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="input"></asp:DropDownList>
                </div>--%>
            </dd>
        </dl>
       
        <dl>
            <dt>备注：</dt>
            <dd>
               <asp:TextBox ID="txtCurriculumRemark" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="" MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
    </div>
    <!--/内容-->
    <!--工具栏-->

    <div class="page-footer" runat="server" id="div_gongju">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn" 
                onclick="btnSubmit_Click"  />
            <asp:Button ID="btnClose" runat="server" Text="关闭" CssClass="btn" 
                onclick="btnClose_Click"  />
            <asp:Label ID="lblError" runat="server" Text="" Style="color: Red;"></asp:Label>
        </div>
        <div class="clear">
        </div>
    </div>
         <div class="table-container" style="padding-bottom:5px">
        <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th style="width: 10%" align="center">课程名称
                                </th>
                                <th style="width: 10%" align="center">课程时间
                                </th>
                                 <th style="width: 10%" align="center">授课老师
                                </th>
                                <th align="center">备注
                                </th>
                                <th align="center" style="width: 10%">操作
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><asp:HiddenField ID="hfdID" runat="server" Value='<%#Eval("ID") %>' />
                                <%#Eval("CurriculumName") %>
                            </td>
                            <td align="center">
                               <%#Eval("CurriculumDate") %>
                            </td>
                            <td align="center">
                               <%#Eval("Teacher") %>
                            </td>
                             <td align="center">
                               <%#Eval("CurriculumRemark") %>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnEditColumn" runat="server" 
                             CommandArgument='<%#Eval("ID") %>' OnClick="lbtnEditColumn_Click">修改</asp:LinkButton>
                                <asp:LinkButton ID="lbtnDelColumn" runat="server" OnClientClick="return confirm('确认删除？')"
                                    CommandArgument='<%#Eval("ID") %>' OnClick="lbtnDelColumn_Click">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
                </table>
                    </FooterTemplate>
                </asp:Repeater>
                </div>
    <!--/工具栏-->
    </form>
</body>
</html>



