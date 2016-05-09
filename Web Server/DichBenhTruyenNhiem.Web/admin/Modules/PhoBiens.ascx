<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoBiens.ascx.cs" Inherits="Adicom.Web.admin.Modules.PhoBiens" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách phổ biến loại dịch bệnh
    </div>
    <div class="options">
        <input type="button" onclick="location.href='PhoBienAdd.aspx'" value="Tạo mới tin"
            id="btnAddNew" class="adminButtonBlue" title="Add a news entry" /></div>
</div>
<p>
</p>
<asp:GridView ID="gvCatalogs" runat="server" AutoGenerateColumns="False" Width="100%"
    AllowPaging="True" PageSize="15" DataSourceID="CatalogDataSource"
    OnRowCommand="gvCatalogs_RowCommand" 
    OnRowDataBound="gvCatalogs_RowDataBound" 
    onpageindexchanging="gvCatalogs_PageIndexChanging">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a href='PhoBienAdd.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Thể loại bệnh" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID="dlCategory" runat="server">
                    <asp:ListItem Value="1">Bệnh Nhi</asp:ListItem>
                    <asp:ListItem Value="2">Bệnh Da Liễu</asp:ListItem>
                    <asp:ListItem Value="3">Các bệnh chuyên khoa</asp:ListItem>
                    <asp:ListItem Value="4">Bệnh Tim mạch</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name_vn" HeaderText="Tiêu đề tiếng Việt" 
            SortExpression="Name_vn" />
        <asp:BoundField DataField="Name_en" HeaderText="Tiêu đề tiếng Anh" 
            SortExpression="Name_en" />
        <asp:BoundField DataField="Short_vn" HeaderText="Mô tả ngắn gọn tiếng Việt" 
            SortExpression="Short_vn" />
        <asp:BoundField DataField="Short_en" HeaderText="Mô tả ngắn gọn tiếng Anh"
            SortExpression="Short_en" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có Danh Sách Cảnh Báo Dịch Bệnh nào
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="CatalogDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.PhoBienController"></asp:ObjectDataSource>
