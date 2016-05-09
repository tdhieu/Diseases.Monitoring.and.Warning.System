<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoBienAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.PhoBienAdd" %>
<%@ Register Src="PhoBienControl.ascx" TagName="PhoBienControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới Phổ Biến Loại Dịch Bệnh <a href="Phobiens.aspx" title="Quay lại danh sách Phổ Biến Loại Dịch Bệnh">(Quay lại danh sách Phổ Biến Loại Dịch Bệnh)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
            OnClick="SaveButton_Click" ToolTip="Save news item" />
        
    </div>
</div>
<uc1:PhoBienControl ID="CatalogControl1" runat="server" />