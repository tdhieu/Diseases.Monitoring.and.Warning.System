<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News.ascx.cs" Inherits="Adicom.Web.admin.Modules.News" %>
<%@ Register Src="NewsControl.ascx" TagName="NewsControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách tin
    </div>
    <div class="options">
        <input type="button" onclick="location.href='NewsAdd.aspx'" value="Tạo mới tin" id="btnAddNew"
            class="adminButtonBlue" title="Add a news entry" />
    </div>
</div>
<p>
</p>
<asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" Width="100%"
    AllowPaging="True" PageSize="15" DataSourceID="NewsDataSource"
    OnRowCommand="gvNews_RowCommand" onrowdatabound="gvNews_RowDataBound" 
    onpageindexchanging="gvNews_PageIndexChanging">
    <Columns>
        <asp:TemplateField >
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate >
                <a href='newsadd.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "id") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Loại tin" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID=dlCategory runat=server>
                    <asp:ListItem Value=1>Tin trong nước</asp:ListItem>
                    <asp:ListItem Value=2>Tin quốc tế </asp:ListItem>
                    <asp:ListItem Value=3>Tin cập nhật trong ngày</asp:ListItem>
            </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="title_vn" HeaderText="Tiêu đề tiếng Việt" 
            SortExpression="title_vn" />
        <asp:BoundField DataField="title_en" HeaderText="Tiêu đề tiếng Anh" 
            SortExpression="title_en" />
        <asp:BoundField DataField="short_vn" HeaderText="M&#244; tả ngắn gọn tiếng Anh" SortExpression="short_vn" />
        <asp:BoundField DataField="short_en" HeaderText="M&#244; tả ngắn gọn tiếng Việt"
            SortExpression="short_en" />
        <asp:TemplateField HeaderText="Ngày" SortExpression="publish_date">
            <ItemTemplate>
                <%# ((DateTime)Eval("publish_date")).ToShortDateString() %>
            </ItemTemplate>
            
        </asp:TemplateField>
       
    </Columns>
    <EmptyDataTemplate>
        Chưa có tin tức nào
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="NewsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.NewsController">
</asp:ObjectDataSource>
