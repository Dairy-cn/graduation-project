<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KaoQinEdit.aspx.cs" Inherits="KaoQinEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="Content/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <div class="item">
        <div class="title">
            考勤信息
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
                        <span style="color:Red">*</span>考勤课程：
                    </td>
                    <td align="left">
                            <asp:TextBox ID="TextBox1" runat="server" DESIGNTIMEDRAGDROP="98" Width="307px"></asp:TextBox><font face="宋体">(必填)</font>
                    </td>
                </tr>
                <tr class="tr">
                    <td align="center">
                        <span style="color:Red">*</span><span class="auto-style1">实验课地址</span>：
                    </td>
                    <td align="left">
                            <asp:TextBox ID="TextBox2" runat="server" DESIGNTIMEDRAGDROP="98" Width="307px"></asp:TextBox><font face="宋体">(必填)</font>
                    </td>
                </tr>
                <tr class="tr">
                    <td align="center">
                        <span style="color:Red">*</span>截至时间：
                    </td>
                    <td align="left">
                       <input class="Wdate" type="text" id="BeginTime" runat="server" onfocus="WdatePicker({startDate:'%y-%M-01 00:00',dateFmt:'yyyy-MM-dd HH:mm',alwaysUseStartDate:true})" />
                                ~
                                <input class="Wdate" type="text" id="EndTime" runat="server" onfocus="WdatePicker({startDate:'%y-%M-01 00:00',dateFmt:'yyyy-MM-dd HH:mm',alwaysUseStartDate:true})" /><font face="宋体">(必填)</font>
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

