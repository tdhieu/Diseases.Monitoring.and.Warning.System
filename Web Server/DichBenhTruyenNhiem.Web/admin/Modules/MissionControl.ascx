<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MissionControl.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.MissionControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-content.png" alt="" />
        Mục tiêu
    </div>
    <div class="options">
        <asp:Button runat="server" Text="Save" CssClass="adminButtonBlue" ID="btnSave" ToolTip="Save changes"
            OnClick="btnSave_Click" />
    </div>
</div>
<div class="homepage">
    <div class="intro">
        Tiếng Việt</div>
    <FCKeditorV2:FCKeditor ID="txtVN" runat="server" AutoDetectLanguage="false" Height="350">
    </FCKeditorV2:FCKeditor>
    <div class="intro">
        Tiếng Anh
    </div>
    <FCKeditorV2:FCKeditor ID="txtEN" runat="server" AutoDetectLanguage="false" Height="350">
    </FCKeditorV2:FCKeditor>
</div>
