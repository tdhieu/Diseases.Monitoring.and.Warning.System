<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhDich.ascx.cs" Inherits="Adicom.Web.admin.Modules.BenhDichs" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách Dịch Bệnh
    </div>
    <div class="options">
        <input type="button" onclick="location.href='BenhDịchAdd.aspx'" value="Tạo mới Dịch Bệnh" id="btnAddNew"
            class="adminButtonBlue" title="Add a news entry" />
    </div>
</div>
<p>
</p>
<p>
    <br />
    Tên bệnh viện
    <asp:DropDownList ID="DropDownList1" runat="server" Width="106px">
    </asp:DropDownList>
&nbsp;<asp:Button ID="drlBenhvien" runat="server" CssClass="adminButtonBlue" 
        onclick="Button1_Click" Text="Tìm Kiếm" />
</p>
<asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" Width="100%"
    AllowPaging="True" PageSize="15" OnRowCommand="gvNews_RowCommand" onrowdatabound="gvNews_RowDataBound" 
    onpageindexchanging="gvNews_PageIndexChanging">
    <Columns>
        <asp:TemplateField >
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdBenhDich") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate >
                <a href='BenhDịchAdd.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdBenhDich") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IdBenhDich") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="TenBenhDich" HeaderText="Tên Dịch Bệnh" SortExpression="TenBenhDich" />
        <asp:BoundField DataField="NgayBatDau" HeaderText="Thời gian bùng phát" SortExpression="DateStar" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có User nào
    </EmptyDataTemplate>
</asp:GridView>
<%--<asp:ObjectDataSource ID="NewsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.DichBenhController">
</asp:ObjectDataSource>
--%>