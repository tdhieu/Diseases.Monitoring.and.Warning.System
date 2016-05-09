<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DulieudichbenhsAdmin.ascx.cs" Inherits="Adicom.Web.admin.Modules.DulieudichbenhsAdmin" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" /> Danh sách dữ liệu dịch 
        bệnh</div>
    <div class="options">
        <input type="button" onclick="location.href='DuLieuBenhDichAdd.aspx'" 
            value="Tạo mới dữ liệu dịch bệnh" id="btnAddNew"
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
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Iddulieu") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate >
                <a href='DuLieuBenhDichAdd.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Iddulieu") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Iddulieu") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="Tenbenhvien" HeaderText="Tên Bệnh Viện" SortExpression="Tenbenhvien" />
        <asp:BoundField DataField="Tendichbenh" HeaderText="Tên Dịch Bệnh" SortExpression="Tendichbenh" />
       <asp:BoundField DataField="SoCabitruyennhiem" HeaderText="Số Người Bị Truyền Nhiễm" SortExpression="SoCabitruyennhiem" />
       <asp:BoundField DataField="Socatuvong" HeaderText="Số Người Tử Vong" SortExpression="Socatuvong" />
       <asp:BoundField DataField="Dateup" HeaderText="Thời Gian" 
            SortExpression="Dateup" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có dữ liệu dịch bệnh nào
    </EmptyDataTemplate>
</asp:GridView>
<%--<asp:ObjectDataSource ID="NewsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.DulieuDichbenhController">
</asp:ObjectDataSource>--%>