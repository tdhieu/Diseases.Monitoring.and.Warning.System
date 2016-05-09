﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XemBaoCaoChiTietThang.ascx.cs" Inherits="Adicom.Web.admin.Modules.XemBaoCaoChiTietThang" %>
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
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" /> Báo cáo chi tiết tình hình dịch bệnh (theo 
        tháng)
    </div>
    <div class="options">
        <asp:Button ID="ButtonBack" runat="server" Text="Trở về" 
            CssClass="adminButtonBlue" onclick="ButtonBack_Click"/>
    </div>
</div>
<br />
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; ">
<tr>     
    <td>
        <table border="0" cellpadding="2" cellspacing="2" style="width:100%; ">
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Ngày Báo Cáo:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtNgayBaoCao" runat="server" Enabled="true" MaxLength="250" 
                    Width="200px" />
            </td>                    
            <td align="left" style="padding-left: 50px; height: 35px;">
                Từ Ngày:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtNgayBatDau" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Đến Ngày:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtNgayKetThuc" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Mã Số:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtMaBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Nơi Báo Cáo
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtNoiBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
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
                Tên Dịch Bệnh:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtDichBenh" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>                    
        </tr>     
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Nhận Xét / Đề Nghị:
            </td>
            <td colspan="6" class="adminData">
                <asp:Panel ID="Panel1" runat="server" Enabled="true" BorderStyle="Solid" BorderWidth="1" Width="100%" Height="300px">
                    <asp:Literal ID="ltNhanXet" runat="server" />
                </asp:Panel>
            </td>        
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Biện Pháp Triển Khai:        
            </td>
            <td colspan="6" class="adminData">
                <asp:Panel ID="Panel2" runat="server" Enabled="true" BorderStyle="Solid" BorderWidth="1" Width="100%" Height="300px">
                    <asp:Literal ID="ltTrienKhai" runat="server" />
                </asp:Panel>
            </td>        
        </tr>                         
        </table>
    </td>    
</tr>
<tr>
    <td align="left" style="padding-left: 50px; height: 35px;">
        <br />
        Bảng Số Liệu Chi Tiết:
        <br /><br />
    </td>
</tr> 
<tr>
    <td>
         <asp:GridView ID="grvDuLieu" runat="server" AutoGenerateColumns="False" 
             Width="100%" HorizontalAlign="Center" >                         
             <Columns>
                <asp:BoundField DataField="TenDiaPhuong" HeaderText="Tên Địa Phương" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="SoBenhNhanNhiem" HeaderText="Số Bệnh Nhân Nhiễm" />                    
                <asp:BoundField DataField="SoCaAcTinh" HeaderText="Số Ca Ác Tính" /> 
                <asp:BoundField DataField="SoCaTuVong" HeaderText="Số Ca Tử Vong" />                                        
                <asp:BoundField DataField="SoCaXetNghiem" HeaderText="Số Ca Xét Nghiệm" />                                                         
                <asp:BoundField DataField="SoCaDuongTinh" HeaderText="Số Ca Dương Tính" />                                                                         
             </Columns>
             <RowStyle HorizontalAlign="Center" />             
            <EmptyDataTemplate>
                Chưa nhập dữ liệu dịch bệnh
            </EmptyDataTemplate>
             <EditRowStyle HorizontalAlign="Center" />
        </asp:GridView>    
     </td>
</tr>
</table>