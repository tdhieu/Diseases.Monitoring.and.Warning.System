<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CallCenterControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.CallCenterControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div class="section-header">
        <div class="title">
    <img src="./Common_Img/ico-dashboard.png" alt="" />
    Phổn biến kiến thức
    </div>
    <div class="options">
        <asp:Button runat="server" Text="Save" CssClass="adminButtonBlue" ID="btnSave" 
             ToolTip="Save changes" onclick="btnSave_Click" />
    </div>
</div>
<div class="homepage">
<div class="intro">Tiếng Việt</div>
 <FCKeditorV2:FCKeditor ID="txtVN" runat="server" AutoDetectLanguage="false" Height="350">
            </FCKeditorV2:FCKeditor>
            
            <div class="intro">Tiếng Anh</div>
            <FCKeditorV2:FCKeditor ID="txtEN" runat="server" AutoDetectLanguage="false" Height="350">
            </FCKeditorV2:FCKeditor>
</div>