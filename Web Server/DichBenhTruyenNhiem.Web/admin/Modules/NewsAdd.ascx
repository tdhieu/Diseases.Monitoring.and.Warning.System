<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.NewsAdd" %>
<%@ Register Src="NewsControl.ascx" TagName="NewsControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới tin <a href="listnews.aspx" title="Quay lại danh sách tin">(Quay lại danh sách tin)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
            OnClick="SaveButton_Click" ToolTip="Save news item" />
        
    </div>
</div>

<uc1:NewsControl ID="NewsControl1" runat="server" />