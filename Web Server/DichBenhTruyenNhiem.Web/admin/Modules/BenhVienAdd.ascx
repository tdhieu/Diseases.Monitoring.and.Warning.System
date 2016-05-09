<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhVienAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.BenhVienAdd" %>
<%@ Register Src="BenhVienControl.ascx" TagName="BenhVienControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới Bệnh Viện <a href="BenhViens.aspx" title="Quay lại danh sách Bệnh Viện">(Quay lại danh sách Bệnh Viện)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
             ToolTip="Save news item" onclick="SaveButton_Click"  />
        
    </div>
</div>

<uc1:BenhVienControl ID="BenhVienControl1" runat="server" />