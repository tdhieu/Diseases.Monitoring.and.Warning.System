<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartnerAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.PartnerAdd" %>
<%@ Register Src="PartnerControl.ascx" TagName="NewsControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới Đối tác<a href="listpartner.aspx" title="Quay lại danh sách Đối tác"> (Quay lại danh sách Đối tác)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
            OnClick="SaveButton_Click" ToolTip="Save news item" />
        
    </div>
</div>
<uc1:NewsControl ID="partnel" runat="server" />