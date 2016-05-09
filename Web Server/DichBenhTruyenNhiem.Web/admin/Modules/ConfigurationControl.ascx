<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.ConfigurationControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<div class="section-header">
        <div class="title">
    <img src="./Common_Img/ico-dashboard.png" alt="" />
   Cài đặt
    </div>
    <div class="options">
        <asp:Button runat="server" Text="Save" CssClass="adminButtonBlue" ID="btnSave" 
             ToolTip="Save changes" onclick="btnSave_Click" />
    </div>
</div>
<div class="homepage">
<div class="intro">
Vui lòng nhập các thông tin chung của trang web
</div>
<div>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Tên Hệ Thống Cảnh Báo Dịch Bệnh - tiếng việt
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtNameVn runat=server></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Tên Hệ Thống Cảnh Báo Dịch Bệnh - tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtNameEn runat=server></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            Slogan - tiếng việt
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtSloganVn runat=server></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Slogan - tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtSloganEn runat=server></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="adminTitle">
            Điện thoại
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtTelephone runat=server></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="adminTitle">
            Fax
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtFax runat=server></asp:TextBox>
        </td>
    </tr>
      <tr>
        <td class="adminTitle">
            Email
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtEmail runat=server></asp:TextBox>
        </td>
    </tr>
        
      <tr>
        <td class="adminTitle">
            Người liên hệ
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtContactPerson runat=server></asp:TextBox>
        </td>
    </tr>

         
</table>
</div>
<div class="intro">
Vui lòng nhập các thông tin cho các trang tìm kiếm (SEO)
</div>
<div>

<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Keyword - tiếng Việt
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtKeywordVn runat=server TextMode=MultiLine Height=100px></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Keyword- tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtKeywordEn runat=server TextMode=MultiLine Height=100px></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            Mô tả - tiếng việt
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtDescriptionVn runat=server TextMode=MultiLine Height=100px></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Mô tả - tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox ID=txtDescriptionEn runat=server TextMode=MultiLine Height=100px></asp:TextBox>
        </td>
    </tr>
         
</table>
    </div>
</div>