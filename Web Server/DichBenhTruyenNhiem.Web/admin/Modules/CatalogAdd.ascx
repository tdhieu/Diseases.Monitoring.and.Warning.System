<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.CatalogAdd" %>
<%@ Register Src="CatalogControl.ascx" TagName="NewsControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới Cảnh Báo Dịch Bệnh <a href="listcatalog.aspx" title="Quay lại danh sách Cảnh Báo Dịch Bệnh">(Quay lại danh sách Cảnh Báo Dịch Bệnh)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
            OnClick="SaveButton_Click" ToolTip="Save news item" />
        
    </div>
</div>
<uc1:NewsControl ID="CatalogControl1" runat="server" />