<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="form1" runat="server">
    <div class="item">
        <div class="title">
            班级信息
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
                        名称：
                    </td>
                    <td align="left">
                        <font face="宋体">
                            <asp:TextBox ID="TextBox1" runat="server" DESIGNTIMEDRAGDROP="98" Width="232px"></asp:TextBox></font>
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
</asp:Content>

