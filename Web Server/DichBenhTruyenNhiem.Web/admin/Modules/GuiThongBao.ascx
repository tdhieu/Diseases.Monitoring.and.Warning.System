<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GuiThongBao.ascx.cs" Inherits="Adicom.Web.admin.Modules.GuiThongBao" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<style type="text/css">


.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
        
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
.dxeButtonEditButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
    .dxeButtonEditButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
    .style4
    {
        width: 145px;
    }
</style>

<div class="section-header">
    <div class="title">
        <img alt="Tin tức" src="Common_Img/ico-news.gif" /> 
        Gửi Thông Báo
    </div>
    <div class="options">
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
            CssClass="adminButtonBlue" onclick="ButtonSubmit_Click"/>
    </div>    
</div>
<asp:Panel ID="Panel1" runat="server" Enabled="true" BorderWidth="1" BorderStyle="Double" Width="100%" Height="100%">
<table class="adminContent" border="0">
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Chủ đề:</font>
        </td>
        <td class="style4" colspan="5">
            <asp:TextBox runat="server" ID="txtSubject" CssClass="adminInput" Width="100%" Height="25px" />                
        </td>
    </tr>
    <tr>
        <td class="adminTitle" >
            <font style="font-size:medium;">Ngày thông báo:</font>
        </td>
        <td class="adminData">
            <dxe:ASPxDateEdit ID="cldNgayThongBao" runat="server" Enabled="true" 
                CssClass="adminInput" Width="200px" Height="16px"/>
        </td> 
        <td class="adminTitle" style="padding-left:50px">
            <font style="font-size:medium;">Độ ưu tiên:
        </td>
        <td class="adminData">
            <asp:DropDownList ID="ddlPriority" CssClass="adminInput" runat="server" 
                Enabled="true" Height="25px" Width="200px" />                     
        </td>               
    </tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Nơi gửi:</font>
        </td>
        <td class="style4">
            <asp:TextBox runat="server" ID="txtNoiGui" CssClass="adminInput" 
                Enabled="false" Width="200px" Height="25px" />                
        </td>
        <td class="adminTitle" style="padding-left:50px">
            <font style="font-size:medium;">Nơi nhận:</font>
        </td>
        <td class="adminData">
            <asp:DropDownList ID="ddlBenhVien" CssClass="adminInput" runat="server" 
                Enabled="true" Height="25px" Width="200px"/>             
        </td> 
    </tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Tập tin đính kèm:</font>
        </td>
        <td class="adminData">
            <asp:FileUpload ID="FileUpload" runat="server" Enabled="true" Width="200px" 
                Height="25px" Font-Names="Times New Roman" Font-Size="Medium"/>
        </td>         
    </tr>
    <tr><td><br /></td></tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Nội dung:</font>
        </td>
 
        <td class="style4" colspan="6">
            <FCKeditorV2:FCKeditor ID="txtNoiDung" runat="server" AutoDetectLanguage="false" Height="350px" Width="100%"/>
        </td>
    </tr>
</table>
</asp:Panel>