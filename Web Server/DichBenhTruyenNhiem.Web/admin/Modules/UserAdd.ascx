<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.UserAdd" %>
<%@ Register Src="UsersControl.ascx" TagName="UserControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới tin <a href="Users.aspx" title="Quay lại danh sách User">(Quay lại danh sách User)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
             ToolTip="Save news item" onclick="SaveButton_Click" />
        
    </div>
</div>

<uc1:UserControl ID="UserControl1" runat="server" />