<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>打卡签到系统</title>
    <link href="Resource/login/images/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <div id="top">
            <div id="top_left">
                </div>
            <div id="top_center">
            </div>
        </div>
        <div id="center">
            <div id="center_left">
            </div>
            <div id="center_middle">
                <div id="user">
                    用 户:
                    <asp:TextBox ID="txtLoginName" runat="server" MaxLength="18" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLoginName"
                        Display="Static" ErrorMessage="*"></asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div id="password">
                    密 码:
                    <asp:TextBox ID="txtPwd" runat="server" MaxLength="16" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                        Display="Static" ErrorMessage="*"></asp:RequiredFieldValidator>
                    &nbsp;</div>
                  <div id="role">
                    角 色:
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" 
                          Width="86px">
                          <asp:ListItem Value="1">教师</asp:ListItem>
                          <asp:ListItem Value="2">学生</asp:ListItem>
                      </asp:DropDownList>
                </div>
                <div id="btn">
                    <asp:LinkButton ID="lbtnlogin" runat="server" CssClass="login_button" OnClick="lbtnlogin_Click">登 录</asp:LinkButton>
                </div>
            </div>
            <div id="center_right">
            </div>
        </div>
        <div id="down">
            <div id="down_left">
                <div id="inf">
                    <span class="inf_text">毕业设计作品</span> <span class="copyright"> 基于IC卡考勤签到系统的设计与开发</span>
                </div>
            </div>
            <div id="down_center">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
