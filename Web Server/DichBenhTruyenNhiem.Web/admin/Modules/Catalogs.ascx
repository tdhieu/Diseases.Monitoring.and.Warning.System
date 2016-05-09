<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Catalogs.ascx.cs" Inherits="Adicom.Web.admin.Modules.Catalogs" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách cảnh báo dịch bệnh
    </div>
    <div class="options">
        <input type="button" onclick="location.href='catalog.aspx'" value="Tạo mới tin" id="btnAddNew"
            class="adminButtonBlue" title="Add a news entry" /></div>
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
                <a href='catalog.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "id") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dịch bệnh | Phòng chống" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID="dlCategorys" runat="server">
                    <asp:ListItem Value="1">Dịch bệnh </asp:ListItem>
                    <asp:ListItem Value="2">Phòng chống</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Lĩnh Vực" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID="dlCategory" runat="server">
                    <asp:ListItem Value="1">Thông tin về dịch bệnh</asp:ListItem>
                    <asp:ListItem Value="2">Biện pháp phòng chống</asp:ListItem>
                    <asp:ListItem Value="3">Các câu hỏi thường gặp</asp:ListItem>
                    <asp:ListItem Value="4">Lời Khuyên Bác Sỹ</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name_vn" HeaderText="Tiêu đề tiếng Việt" 
            SortExpression="title_vn" />
        <asp:BoundField DataField="Name_en" HeaderText="Tiêu đề tiếng Anh" 
            SortExpression="title_en" />
        <asp:BoundField DataField="short_vn" HeaderText="Mô tả ngắn gọn tiếng Việt" 
            SortExpression="short_vn" />
        <asp:BoundField DataField="short_en" HeaderText="Mô tả ngắn gọn tiếng Anh"
            SortExpression="short_en" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có Danh Sách Cảnh Báo Dịch Bệnh nào
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="CatalogDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="getServiceByType" TypeName="Adicom.Web.Code.ProductController"
    DeleteMethod="Delete" UpdateMethod="Update">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="type" QueryStringField="type" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
