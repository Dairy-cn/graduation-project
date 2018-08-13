<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyKaoQin.aspx.cs" Inherits="MyKaoQin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Content/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="item">
        <div class="title">
            考勤记录
        </div>
        <div class="datagrid-pager" >
            &nbsp;
            <table>
                <tr valign="middle">
                    <td>
                     考勤课题:
                    </td>
                     <td>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                     <td>
                    &nbsp;
                    </td>
                       <td>
                   签到时间:
                    </td>
                       <td>
                    &nbsp;
                    </td>
                       <td>
                    &nbsp;&nbsp;</td>
   <td>
                 <asp:TextBox ID="txtTime" runat="server" class="txtbox Wdate" onFocus="WdatePicker()"></asp:TextBox>
                    </td>
                       <td>
                   &nbsp;
                    </td>
                       <td>
                     <asp:LinkButton ID="lbtnsave" CssClass="button" runat="server" CommandArgument="0" 
                               onclick="lbtnsave_Click" CausesValidation="False"
                ><img height=16 width=16 src="Resource/Images/icons/search.png"/>查询</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
           
           
        </div>
        <div class="ui-toolbar">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CssClass="GridViewStyle" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" Width="100%">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerSettings FirstPageText="首页&amp;nbsp;" LastPageText="&amp;nbsp;最后一页" Mode="NextPreviousFirstLast"
                    NextPageText="&amp;nbsp;下一页" PreviousPageText="&amp;nbsp;上一页" />
                <PagerStyle CssClass="GridViewPagerStyle" ForeColor="#999966" Height="30px" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="datagrid-header" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="序号" InsertVisible="False">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="mname" HeaderText="用户名称">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Name" HeaderText="考勤课题">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                         <asp:BoundField DataField="Address" HeaderText="考勤地址">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="签到时间" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</asp:Content>
