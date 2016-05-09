<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachDichBenhTinhControler.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.DanhSachDichBenhTinhControler" %>
<center>
<p>
    Danh Sách Dữ Liệu Thống kê giám sát quảng lý dịch bệnh truyền nhiễm theo Tỉnh 
    Thành
    <br />
</p>

<table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 0px" 
    width="95%">
    <tr>
        <td align="center">
            Từ Ngày&nbsp;
            <asp:TextBox ID="txtDateFrom" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="center">
            Đến Ngày&nbsp;
            <asp:TextBox ID="txtDateto" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="center">
            Tỉnh 
            <asp:DropDownList ID="cbxTinh" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
        <td align="center">
            Bệnh Dịch
            <asp:DropDownList ID="cbxBenhDich" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                Style="height: 26px" Text="Tìm Kiếm" />
        </td>
    </tr>
</table>

<p>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateFrom"
        ControlToValidate="txtDateto" Display="Dynamic" ErrorMessage="Bạn Chọn Ngày Không Hợp Lệ"
        Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
</p>

<p>

    <asp:Literal ID="ltrDanhSach" runat="server"></asp:Literal>
    </p>
    </center>
<asp:GridView ID="gvNews" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    PageSize="15" Width="100%" 
    onselectedindexchanged="gvNews_SelectedIndexChanged">
    <Columns>
        <asp:TemplateField HeaderText="Ngày" SortExpression="publish_date">
            <ItemTemplate>
                <%# ((DateTime)Eval("ThoiGian")).ToShortDateString()%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="TruyenNhiem" HeaderText="Số Người Bị Truyền Nhiễm" SortExpression="TruyenNhiem" />
        <asp:BoundField DataField="TuVong" HeaderText="Số Người Tử Vong " SortExpression="TuVong" />
    </Columns>
    <EmptyDataTemplate>
        Chưa có dữ liệu nào
    </EmptyDataTemplate>
</asp:GridView>
