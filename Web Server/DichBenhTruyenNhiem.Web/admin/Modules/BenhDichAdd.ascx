<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhDichAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.BenhDichAdd" %>
<%@ Register src="BenhDichControl.ascx" tagname="BenhDichControl" tagprefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới Dịch Bệnh <a href="BenhDichs.aspx" title="Quay lại danh sách Dịch Bệnh">(Quay lại danh sách Dịch Bệnh)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
             ToolTip="Save news item" onclick="SaveButton_Click" />
        
    </div>
</div>

<uc1:BenhDichControl ID="BenhDichControl1" runat="server" />
