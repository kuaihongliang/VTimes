<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SigninEdit.aspx.cs" Inherits="DTcms.Web.admin.signin.SigninEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>课程签到页</title>
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
        <a href="javascript:;" class="home"><i></i><span>课程签到页</span></a>
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
                        <asp:Literal ID="litNowPosition2" runat="server" Text="课程签到页"></asp:Literal></a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>课程日期：</dt>
            <dd>
                <asp:Label ID="labCurriculumDate" runat="server" Text="Label"></asp:Label>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>课程名称：</dt>
            <dd>
                <asp:HiddenField ID="hdfCurriculumID" runat="server" />
                <asp:Label ID="labCurriculumName" runat="server" Text="Label"></asp:Label>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>授课教练：</dt>
            <dd><asp:HiddenField ID="hdfTeacherID" runat="server" />
               <asp:Label ID="labTeacher" runat="server" Text="Label"></asp:Label>
            
            </dd>
        </dl>
       
        <dl>
            <dt>签到学员：</dt>
            <dd>
                <table >
                    <tr>
                        <td>
                            <asp:ListBox ID="listAllStudent" runat="server" Height="200px" Width="135px" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td style="padding:10px">
                            <asp:Button ID="btnChoose" Width="50px" runat="server" Text=">>" OnClick="btnChoose_Click" /><br /><br />
                            <asp:Button ID="btnAll" Width="50px" runat="server" Text="全选" OnClick="btnAll_Click" /><br /><br />
                            <asp:Button ID="btnBack" Width="50px" runat="server" Text="<<" OnClick="btnBack_Click" />
                        </td>
                        <td>
                            <asp:ListBox ID="listSignin" runat="server" Height="200px" Width="135px" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                </table>
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
             
        
                </div>
    <!--/工具栏-->
    </form>
</body>
</html>
