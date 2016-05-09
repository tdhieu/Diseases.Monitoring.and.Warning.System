<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XemDanhSachBaoCao.ascx.cs" Inherits="Adicom.Web.admin.Modules.XemDanhSachBaoCao" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<style type="text/css">


.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxeButtonEditButton,
.dxeSpinIncButton, .dxeSpinDecButton, .dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3px;
	background-image: url('edtDropDownBack.gif');
    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxeButtonEditButton, .dxeCalendarButton,
.dxeSpinIncButton, .dxeSpinDecButton,
.dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
    </style>
<center>
    <p>
        <font style="font-weight:bold; font-size:large">Danh Sách Các Báo Cáo Thống Kê Tình Hình Dịch Bệnh</font>
    </p>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 0px" width="100%">
        <tr>
            <td align="center"><font style="font-size:medium">Từ Ngày:</font></td>
            <td align="center">
                <dxe:ASPxDateEdit ID="cldFromDay" runat="server" Enabled="true" Width="250px" />
            </td>
            <td align="center"><font style="font-size:medium">Đến Ngày:</font></td>
            <td align="center">
                <dxe:ASPxDateEdit ID="cldToDay" runat="server" Enabled="true" Width="250px" />
            </td>
            <td align="center"><font style="font-size:medium">Bệnh Dịch:</font></td>
            <td align="center">    
                <asp:DropDownList ID="ddlBenhDich" runat="server" Width="250px" />
            </td>            
        </tr>
        <tr>
            <td align="center"><font style="font-size:medium">Tỉnh:</font></td>
            <td align="center">
                <asp:DropDownList ID="ddlTinh" runat="server" Width="250px" 
                    AutoPostBack="False" />
            </td>
            <td align="center"><font style="font-size:medium">Quận/Huyện:</font></td>
            <td align="center">                
                <asp:DropDownList ID="ddlHuyen" runat="server" Width="250px" 
                    AutoPostBack="False" />        
            </td>
            <td align="center"><font style="font-size:medium">Bệnh Viện:</font></td>
            <td align="center">
                <asp:DropDownList ID="ddlBenhVien" runat="server" Width="250px" 
                    AutoPostBack="False" />
            </td>
            <td align="center">
                <asp:Button ID="ButtonSearch" runat="server" CssClass="button" Style="height: 26px" 
                Text="Tìm Báo Cáo" onclick="ButtonSearch_Click" />
            </td>
        </tr>        
    </table>
    <p>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="cldFromDay"
            ControlToValidate="cldToDay" Display="Dynamic" ErrorMessage="Bạn Chọn Ngày Không Hợp Lệ"
            Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
    </p>
    <p>
        <asp:Literal ID="ltrDanhSach" runat="server"></asp:Literal>
    </p>
    <p>
        <asp:GridView ID="grvDuLieu" runat="server" align="center" 
                AutoGenerateColumns="False" Width="100%" BackColor="White" 
                BorderColor="#CCCCCC" CellPadding="3" >
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField ShowHeader="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" Enabled="true" CausesValidation="True" Text="Xem" OnClick="lnkView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:BoundField DataField="TenBaoCao" HeaderText="Tên Báo Cáo" /> <%--field dùng để đổ dữ liệu vào--%>
                    <asp:BoundField DataField="NgayBaoCao" HeaderText="Ngày Báo Cáo" />                    
                    <asp:BoundField DataField="BenhVien" HeaderText="Nơi Báo Cáo" /> 
                    <asp:BoundField DataField="NguoiLapBaoCao" HeaderText="Người Báo Cáo" />                                        
                </Columns>
                <EmptyDataTemplate>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Chưa có dữ liệu dịch bệnh
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <RowStyle HorizontalAlign="Center" /> 
          </asp:GridView>
     </p>
</center>