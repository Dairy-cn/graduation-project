<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="AdminList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resource/css/gray/ui-page.css" rel="stylesheet" type="text/css" />
    <link href="Resource/css/Info.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" class="item">
        <div class="title">
            列表
        </div>
        <div class="datagrid-pager">
            <asp:LinkButton ID="lbtnsave" CssClass="button" runat="server" CommandArgument="0"
                OnClick="lbtnsave_Click"><img height=16 width=16 src="Resource/Images/icons/add.png"/>添加</asp:LinkButton>
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
                    <asp:BoundField DataField="dlm" HeaderText="管理员名">
                        <HeaderStyle Height="30px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mm" HeaderText="密码" />
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" ControlStyle-CssClass="button"
                        HeaderText="操作" Text="修改">
                        <ControlStyle CssClass="button"></ControlStyle>
                        <ItemStyle Width="36px" />
                    </asp:ButtonField>
                      <asp:ButtonField ButtonType="Button" CommandName="Del" ControlStyle-CssClass="button"
                        HeaderText="操作" Text="删除">
                        <ControlStyle CssClass="button"></ControlStyle>
                        <ItemStyle Width="36px" />
                    </asp:ButtonField>
                   <%-- <asp:TemplateField HeaderText="删除" FooterStyle-CssClass="datagrid-header">
                        <ItemTemplate>
                            <a class="button" style=" height:18px" href='SQLdel.aspx?Id=<%#Eval("Id")%>&action=Default' onclick="javascript:return confirm('确认删除吗？删除后不可恢复！')">
                                删除</a></ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
