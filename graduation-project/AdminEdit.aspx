<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="AdminEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resource/css/gray/ui-page.css" rel="stylesheet" type="text/css" />
    <link href="Resource/css/Info.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="item">
        <div class="title">
            管理员信息
        </div>
        <div class="ui-toolbar">
            <table id="Table1" cellspacing="1" class="Tab" width="728" align="center">
                <tr class="tr">
                    <td id="TErr" align="left" colspan="2" runat="server">
                        <font face="宋体"></font>
                    </td>
                </tr>
               
                <tr class="tr">
                    <td align="center">
                        管理员帐号：
                    </td>
                    <td align="left">
                        <font face="宋体">
                            <asp:TextBox ID="TextBox1" runat="server" DESIGNTIMEDRAGDROP="98" Width="232px"></asp:TextBox></font>
                    </td>
                </tr>
                <tr class="tr">
                    <td align="center">
                        密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="Textbox5" runat="server" Width="232px" DESIGNTIMEDRAGDROP="98" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr">
                    <td align="center">
                        确认密码：
                    </td>
                    <td align="left">
                        <font face="宋体">
                            <asp:TextBox ID="Textbox6" runat="server" Width="232px" DESIGNTIMEDRAGDROP="98" TextMode="Password"></asp:TextBox></font>
                    </td>
                </tr>
                <tr class="tr" style="height:50px">
                      <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Button1_Click"
                            Text="保存" Width="62px" />
                        <asp:Button ID="Button2" CssClass="button" runat="server" Text="返回" Width="62px"
                            OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
