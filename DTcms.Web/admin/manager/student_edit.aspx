<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_edit.aspx.cs" Inherits="DTcms.Web.admin.manager.student_edit" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>学员设置</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <i class="arrow"></i>
            <span>编辑学员信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">学员信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content" style="height: 500px;">
            <dl>
                <dt>所属教练</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_teacher" runat="server">
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>学员姓名</dt>
                <dd>
                    <asp:TextBox ID="txt_name" runat="server" CssClass="input normal" sucmsg=" " datatype="*"></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txt_tel" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>学历</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_education" runat="server">
                            <asp:ListItem Value="小学">小学</asp:ListItem>
                            <asp:ListItem Value="学龄前">学龄前</asp:ListItem>
                            <asp:ListItem Value="初中">初中</asp:ListItem>
                            <asp:ListItem Value="高中">高中</asp:ListItem>
                            <asp:ListItem Value="大学">大学</asp:ListItem>
                            <asp:ListItem Value="其他">其他</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>性别</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_sex" runat="server">
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>民族</dt>
                <dd>
                    <asp:TextBox ID="txt_nation" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>籍贯</dt>
                <dd>
                    <asp:TextBox ID="txt_native" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>年龄</dt>
                <dd>
                    <asp:TextBox ID="txt_age" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>身高</dt>
                <dd>
                    <asp:TextBox ID="txt_long" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>体重</dt>
                <dd>
                    <asp:TextBox ID="txt_weight" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>所属班级</dt>
                <dd>
                    <asp:TextBox ID="txt_class" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>有无病史</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_disease" runat="server">
                            <asp:ListItem Value="无">无</asp:ListItem>
                            <asp:ListItem Value="有">有</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>所在学校</dt>
                <dd>
                    <asp:TextBox ID="txt_school" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>身份证号码</dt>
                <dd>
                    <asp:TextBox ID="txt_idcard" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>小篮球年龄段</dt>
                <dd>
                    <asp:TextBox ID="txt_ballage" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>介绍人</dt>
                <dd>
                    <asp:TextBox ID="txt_introducer" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txt_remark" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: window.location.href = 'student_list.aspx';" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
