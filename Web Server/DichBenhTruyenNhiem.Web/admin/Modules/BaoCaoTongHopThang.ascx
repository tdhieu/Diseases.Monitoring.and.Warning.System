<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoTongHopThang.ascx.cs" Inherits="Adicom.Web.admin.Modules.BaoCaoTongHopThang" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.2" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<style type="text/css">
    .dxeTextBox, .dxeMemo
{
    background-color: white;
    border: solid 1px #9f9f9f;
}
.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxgvControl,
.dxgvDisabled
{
	border: Solid 1px #9F9F9F;
	font: 11px Tahoma;
	background-color: #F2F2F2;
	color: Black;
	cursor: default;
}

.dxgvTable
{
	background-color: White;
	border: 0;
	border-collapse: separate!important;
	overflow: hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvHeader {
	cursor: pointer;
	white-space: nowrap;
	padding: 4px 6px 5px 6px;
	border: Solid 1px #9F9F9F;
	background-color: #DCDCDC;
	overflow: hidden;
	-moz-user-select: none;
}
.dxgvCommandColumn
{
	padding: 2px 2px 2px 2px;
}
.dxgvControl a 
{
	color: #5555FF;
}
.dxgvControl .dxpControl, .dxgvDisabled .dxpControl
{
	padding-top: 4px;    
}
.dxpControl
{
	font: 9pt Tahoma;
	color: black;
	padding: 5px 2px 5px 2px;
}
.dxpSummary
{
	font: 9pt Tahoma;
	color: black;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
	padding: 1px 4px 0px 4px;
}
.dxpDisabled
{
	color: #acacac;
	border-color: #808080;
	cursor: default;
}

.dxpDisabledButton
{
	font: 9pt Tahoma;
	color: black;
	text-decoration: none;
}
.dxpButton
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
}
.dxpCurrentPageNumber
{
	font: 9pt Tahoma;
	color: black;
	font-weight: bold;
	text-decoration: none;
	padding: 1px 3px 0px 3px;
}
.dxpPageNumber
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	text-align: center;
	vertical-align: middle;
	padding: 1px 5px 0px 5px;
}
        
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
.dxeButtonEditButton,

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
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" /> Báo cáo tổng hợp tình hình dịch bệnh (theo 
        tháng)
    </div>
    <div class="options">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="adminButtonBlue" onclick="ButtonSave_Click" />
    </div>
</div>
<br />
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; ">
<tr>
    <td align="left" colspan="2" style="padding-left: 50px; height: 35px;">
        Lưu ý : ( <font color="red">*</font> ) Bạn phải nhập thông tin !<br />
        <asp:Literal ID="lrWarning" runat="server"/><br /><br />
    </td>
</tr>
<tr>     
    <td>
        <table border="0" cellpadding="2" cellspacing="2" style="width:100%; ">
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Tháng:
            </td>
            <td align="left" style="height: 35px;">
                <asp:DropDownList ID="ddlthang" runat="server" Enabled="true" MaxLength="250" 
                    Width="100px" />
            </td>                    
            <td align="left" style="padding-left: 50px; height: 35px;">
                Năm:
            </td>
            <td align="left" style="height: 35px;">
                <asp:DropDownList ID="ddlNam" runat="server" Enabled="true" MaxLength="250" 
                    Width="100px" />
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Ngày Báo Cáo:</td>
            <td align="left" style="height: 35px;">
                <dxe:ASPxDateEdit ID="cldNgayBaoCao" runat="server" Enabled="true" Width="200px" />  
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Mã Số:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtMaBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaBaoCao"
                     Display="Dynamic" ErrorMessage="*"/>
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Nơi Báo Cáo:
            </td>
            <td align="left" style="height: 35px;">
                <asp:DropDownList ID="ddlBenhVien" runat="server" Enabled="true" MaxLength="250" Width="200px" />                            
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Người Lập Báo Cáo:
            </td>
            <td align="left" colspan="5" style="height: 35px;">
                <asp:TextBox ID="txtNguoiBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>            
        </tr>    
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Nhận Xét / Đề Nghị:
            </td>
            <td colspan="6" class="adminData">
                <fckeditorv2:fckeditor ID="txtDeNghi" runat="server" AutoDetectLanguage="false" Height="350" />                    
            </td>        
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Biện Pháp Triển Khai:        
            </td>
            <td colspan="6" class="adminData">
                <fckeditorv2:fckeditor ID="txtBienPhapTrienKhai" runat="server" AutoDetectLanguage="false" Height="350" />                    
            </td>        
        </tr>         
        </table>
    </td>    
</tr>
<tr>
    <td align="left" style="padding-left: 50px; height: 35px;">
        <br /><br />
        Bảng Số Liệu Chi Tiết:
        <br /><br />
    </td>
</tr>
<tr>
    <td>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" >
        <tr>
        <td colspan="4">
          <asp:GridView ID="grvDuLieu" runat="server" align="center" 
                AutoGenerateColumns="False" Width="100%" BackColor="White" 
                BorderColor="#CCCCCC" CellPadding="3" 
                onrowdeleting="grvDuLieu_RowDeleting">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:BoundField DataField="TenDiaPhuong" HeaderText="Tên Địa Phương" /> <%--field dùng để đổ dữ liệu vào--%>
                    <asp:BoundField DataField="TenDichBenh" HeaderText="Tên Dịch Bệnh" />                    
                    <asp:TemplateField HeaderText="Số Ca Mắc">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSoCaMac" runat="server" Text='<%# Bind("SoCaMac") %>' Width="60%"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Ca Tử Vong">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSoCaChet" runat="server" Text='<%# Bind("SoCaChet") %>' Width="60%" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelRow" runat="server" Enabled="true" CausesValidation="True" 
                                     CommandName="Delete" Text="Xóa"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
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
        </td>        
        </tr>  
        <tr><td><br /></td></tr>
        <tr>            
            <td align="left" style="height: 40px; width:25%; padding-left:50px">Địa phương cần khai báo: </td>
            <td style="width:25%"><asp:DropDownList ID="ddlDiaPhuong" 
                    Enabled="true" runat="server" Width="100%" Height="60%"/></td>
            <td style="width:25%"></td>
            <td align="right" style="height:40px; width:25%; padding-right:50px"><asp:Button ID="ButtonAdd" 
                runat="server" Enabled="true" Text="Thêm Vào Bảng" CssClass="adminButtonBlue" onclick="ButtonAdd_Click"/></td>
        </tr>        
        <tr>
            <td colspan="4" style="padding-left:50px">(Lưu ý: nên chọn hết các địa phương cần khai báo để thêm vào bảng trước khi nhập số liệu)</td>
        </tr>
        </table>
    </td>    
</tr>
</table>
