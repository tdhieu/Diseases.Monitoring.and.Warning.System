<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="Adicom.Web.admin.Modules.Users" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" />
        Danh sách User
    </div>
    <div class="options">
        <input type="button" onclick="location.href='Useradd.aspx'" value="Tạo mới User" id="btnAddNew"
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
    AllowPaging="True" PageSize="15" 
    OnRowCommand="gvNews_RowCommand" onrowdatabound="gvNews_RowDataBound" 
    onpageindexchanging="gvNews_PageIndexChanging">
    <Columns>
        <asp:TemplateField >
            <ItemTemplate>
                <asp:LinkButton ID="cmddel" runat="server" CssClass="adminis" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "user_name") %>'>Xóa</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate >
                <a href='Useradd.aspx?Name=<%# DataBinder.Eval(Container.DataItem, "user_name") %>'>Chi tiết
                </a>
            </ItemTemplate>
            <ItemStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT" Visible="false">
            <ItemTemplate>
                <asp:Literal ID="ltrId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="user_name" HeaderText="Tên Đăng Nhập" SortExpression="user_name" />
        <asp:BoundField DataField="tenbenhvien" HeaderText="Tên bệnh viện" SortExpression="tenbenhvien" />
       <asp:TemplateField HeaderText="Quyền" Visible="true">
            <ItemTemplate>
                <asp:DropDownList ID="dlquyen" runat="server" Enabled=false>
                    <asp:ListItem Value=1>Administrator</asp:ListItem>
                    <asp:ListItem Value=2>Admin Tin tức </asp:ListItem>
                    <asp:ListItem Value=3>Admin Bệnh Viện</asp:ListItem>
                    <asp:ListItem Value=4>Admin Phổ Biến</asp:ListItem>
                    <asp:ListItem Value=5>Admin Dịch Bệnh</asp:ListItem>
            </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        Chưa có User nào
    </EmptyDataTemplate>
</asp:GridView>
<%--<asp:ObjectDataSource ID="NewsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="Adicom.Web.Code.UsersController">
</asp:ObjectDataSource>--%>
