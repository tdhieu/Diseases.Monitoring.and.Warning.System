<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.HomeControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div class="section-header">
        <div class="title">
    <img src="./Common_Img/ico-dashboard.png" alt="" />
    Trang chủ
    </div>
    <div class="options">
        <asp:Button runat="server" Text="Save" CssClass="adminButtonBlue" ID="btnSave" ValidationGroup="NewsSettings"
             ToolTip="Save changes to news" OnClick="btnSave_Click" />
    </div>
</div>
<div class="homepage">
<div class="intro">Tiếng việt
</div>
 <FCKeditorV2:FCKeditor ID="txtContentVn" runat="server" AutoDetectLanguage="false" Height="350">
            </FCKeditorV2:FCKeditor>
<div class="intro">
Tiếng Anh          
</div>  
            <FCKeditorV2:FCKeditor ID="txtContentEn" runat="server" AutoDetectLanguage="false" Height="350">
            </FCKeditorV2:FCKeditor>
</div>