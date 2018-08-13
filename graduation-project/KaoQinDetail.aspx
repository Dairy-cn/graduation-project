
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="KaoQinDetail.aspx.cs" Inherits="KaoQinDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script src="Content/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div ="item">
        <div ="title">
            考勤记录
        </div>
        <div ="datagrid-pager">
            &nbsp;
          
                   <table>
                <tr valign="middle">
                <td>
                  <asp:LinkButton ID="lbtnsave0" Css="button" runat="server" CommandArgument="0"
                OnClick="lbtnsave0_Click"><img height=16 width=16 src="Resource/Images/icons/workflow.png"/>返回</asp:LinkButton>
                </td>
                    <td>
                     用户名称:
                    </td>
                     <td>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td ="td-header">
                        班级:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddllist" Height="23px" Width="112px"
                          >
                        </asp:DropDownList>
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
                   ~
                    </td>
                     <td>
                 <asp:TextBox ID="txtendTime" runat="server" class="txtbox Wdate" onFocus="WdatePicker()"></asp:TextBox>
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
                        &nbsp; &nbsp;
                           <asp:LinkButton ID="LinkButton2" CssClass="button" runat="server" 
                             CommandArgument="0" onclick="LinkButton2_Click"
               ><img height=16 width=16 src="../Resource/Images/icons/reset.png"/>刷新</asp:LinkButton>
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
                      <asp:BoundField DataField="flmc" HeaderText="所属班级">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="签到时间" />
                      <asp:ButtonField ButtonType="Button" CommandName="Del" ControlStyle-CssClass="button"
                        HeaderText="操作" Text="删除">
                        <ControlStyle CssClass="button"></ControlStyle>
                        <ItemStyle Width="36px" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</asp:Content>
