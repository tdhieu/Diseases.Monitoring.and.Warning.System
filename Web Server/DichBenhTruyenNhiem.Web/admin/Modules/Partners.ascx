<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Partners.ascx.cs" Inherits="Adicom.Web.admin.Modules.Partners" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách Đối tác
    </div>
    <div class="options">
        <input type="button" onclick="location.href='partner.aspx'" value="Tạo mới tin"
            id="btnAddNew" class="adminButtonBlue" title="Add a news entry" /></div>
</div>
<p>
</p>
<asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" Width="100%"
    AllowPaging="True" PageSize="15" AllowSorting="false" 
    DataSourceID="CatalogDataSource" onrowcommand="gvNews_RowCommand" 
    onrowdatabound="gvNews_RowDataBound" 
    onpageindexchanging="gvNews_PageIndexChanging">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a href='partner.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "id") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Đối tác" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID="dlty" runat="server">
                    <asp:ListItem Value="1">Đối tác trong nước</asp:ListItem>
                    <asp:ListItem Value="2">Đối tác quốc tế</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name_vn" HeaderText="Ti&#234;u đề tiếng việt" SortExpression="title_vn" />
        <asp:BoundField DataField="Name_en" HeaderText="Ti&#234;u đề tiếng anh" SortExpression="title_en" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có đối tác nào
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="CatalogDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="getPartnerByType" 
    TypeName="Adicom.Web.Code.PartnerController">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="type" QueryStringField="type" 
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
