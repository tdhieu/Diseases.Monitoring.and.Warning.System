<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhViens.ascx.cs" Inherits="Adicom.Web.admin.Modules.BenhViens" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Bệnh Viện" />
        Danh sách Bênh Viện
    </div>
    <div class="options">
        <input type="button" onclick="location.href='BenhVienAdd.aspx'" 
            value="Tạo mới Bệnh Viện" id="btnAddNew"
            class="adminButtonBlue" title="Add a news entry" />
    </div>
</div>
<p>
</p>
<p>
    Tên bệnh viện
    <asp:DropDownList ID="DropDownList1" runat="server" Width="106px">
    </asp:DropDownList>
&nbsp;<asp:Button ID="drlBenhvien" runat="server" CssClass="adminButtonBlue" 
        onclick="Button1_Click" Text="Tìm Kiếm" />
</p>
<asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" Width="100%"
    AllowPaging="True" PageSize="15" 
    OnRowCommand="gvNews_RowCommand" onrowdatabound="gvNews_RowDataBound" 
    onpageindexchanging="gvNews_PageIndexChanging">
    <Columns>
        <asp:TemplateField >
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Idbenhvien") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate >
                <a href='BenhVienAdd.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Idbenhvien") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Idbenhvien") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="Tenbenhvien" HeaderText="Tên Bệnh Viện" SortExpression="Tenbenhvien" />
        <asp:BoundField DataField="Tenbenhvien" HeaderText="Người Đại Diện" SortExpression="Tenbenhvien" />
        <asp:BoundField DataField="dichchi" HeaderText="Địa Chỉ " SortExpression="dichchi" />
        <asp:BoundField DataField="telephone" HeaderText="Số Điện Thoại" SortExpression="telephone" />
       
    </Columns>
    <EmptyDataTemplate>
        Chưa có User nào
    </EmptyDataTemplate>
</asp:GridView>
<%--<asp:ObjectDataSource ID="NewsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.BenhVienController">
</asp:ObjectDataSource>--%>