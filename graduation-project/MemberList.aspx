<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="MemberList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form id="form1" runat="server">
    <div id="div1" class="item">
        <div class="title">
            列表
        </div>
        <div class="datagrid-pager">
         <table>
                <tr>
                  <td class="td-header">
                        班级:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddllist" Height="23px" Width="112px" AutoPostBack="True"
                          >
                        </asp:DropDownList>
                    </td>
                   
                    <td>
                        &nbsp; &nbsp;
                           <asp:LinkButton ID="LinkButton1" CssClass="button" runat="server" CommandArgument="0"
                OnClick="LinkButton1_Click"><img height=16 width=16 src="../Resource/Images/icons/search.png"/>查询</asp:LinkButton>
                    </td>
                     <td>
                        &nbsp; &nbsp;
                           <asp:LinkButton ID="LinkButton2" CssClass="button" runat="server" 
                             CommandArgument="0" onclick="LinkButton2_Click"
               ><img height=16 width=16 src="../Resource/Images/icons/reset.png"/>刷新</asp:LinkButton>
                    </td>
                    <td>
                     <asp:LinkButton ID="lbtnsave" CssClass="button" runat="server" CommandArgument="0"
                OnClick="lbtnsave_Click"><img height=16 width=16 src="Resource/Images/icons/add.png"/>添加</asp:LinkButton>
                    </td>
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
               <PagerSettings FirstPageText="首页&amp;nbsp;" LastPageText="&amp;nbsp;最后一页" 
                    Mode="NextPreviousFirstLast" NextPageText="&amp;nbsp;下一页" 
                    PreviousPageText="&amp;nbsp;上一页" />
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
                     <asp:BoundField DataField="musername" HeaderText="学号">
                        <HeaderStyle Height="40px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mname" HeaderText="姓名">
                        <HeaderStyle Height="40px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    
                     <asp:BoundField DataField="msex" HeaderText="性别">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="memail" HeaderText="邮箱">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="mcard" HeaderText="身份证号">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="mqq" HeaderText="联系QQ">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="mmobile" HeaderText="联系手机">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                       <asp:BoundField DataField="maddress" HeaderText="家庭住址">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="flmc" HeaderText="所在班级">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                     
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" ControlStyle-CssClass="button"
                        HeaderText="操作" Text="修改">
                        <ControlStyle CssClass="button"></ControlStyle>
                        <ItemStyle Width="36px" />
                    </asp:ButtonField>
                  
                     <asp:TemplateField HeaderText="删除" FooterStyle-CssClass="datagrid-header">
                        <ItemTemplate>
                            <a class="button" style=" height:18px" href='SQLdel.aspx?Id=<%#Eval("Id")%>&action=delMember' onclick="javascript:return confirm('确认删除吗？删除后不可恢复！')">
                                删除</a></ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</asp:Content>

